using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BookRecommendationWebApp.Data;
using BookRecommendationWebApp.Models;
using BookRecommendationWebApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using static System.String;

namespace BookRecommendationWebApp.Controllers
{
    public class BooksController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BooksController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Browse(int? categoryId, string? searchInput)
        {
            List<Book> bookList = null;
            Category selectedCategory = null;
            if (categoryId==null)
            {
                bookList = _dbContext.Books.ToList();
            }
            else
            {
                bookList = _dbContext.Books
                    .Where(x => x.BookCategories.Any(c => c.CategoryId == categoryId)).ToList();
                selectedCategory = _dbContext.Categories.Find(categoryId);

            }

            if (!IsNullOrEmpty(searchInput))
            {
                bookList = bookList.Where(x => x.Title.ToUpper().Contains(searchInput.ToUpper()) || x.Author.ToUpper().Contains(searchInput.ToUpper())).ToList();
            }

            var browseBooksViewModel = new BrowseBooksViewModel()
            {
                Categories = _dbContext.Categories.ToList(),
                BooksToDisplay = bookList,
                SelectedCategory = selectedCategory,
                SearchInput = searchInput
            };
            return View(browseBooksViewModel);
        }



        public IActionResult AddBook()
        {
            var addBookViewModel = new AddBookViewModel {Categories = _dbContext.Categories.ToList()};
            return View(addBookViewModel);
        }

        [HttpPost]
        public IActionResult AddBook(AddBookViewModel addBookViewModel)
        {
            if (!ModelState.IsValid)
                return View(addBookViewModel);
            else
            {
                string coverImageFileName = UploadCoverImage(addBookViewModel); ;
                var book = new Book
                {
                    Author = addBookViewModel.Author,
                    Title = addBookViewModel.Title,
                    Isbn = addBookViewModel.Isbn,
                    ImageFile = coverImageFileName,
                    Description = addBookViewModel.Description
                };
                
                List<Category> categories = _dbContext.Categories.Where(x => addBookViewModel.SelectedCategories.Contains(x.CategoryId)).ToList();
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
                foreach (var category in categories)
                {
                    _dbContext.BookCategories.Add(new BookCategory
                    {
                        Category = category,
                        Book = book
                    });
                }
                _dbContext.SaveChanges();

                return RedirectToAction("AddBook");
            }
        }

        public IActionResult BookDetails(int bookId)
        {
            Book book = _dbContext.Books.Find(bookId);
            if (book==null)
            {
                return NotFound();
            }

            List<Category> categories = _dbContext.Categories
                .Where(c => c.BookCategories.Any(bc => bc.BookId == bookId)).ToList();

            BookDetailsViewModel bookDetailsView = new BookDetailsViewModel
            {
                Title = book.Title,
                Author = book.Author,
                Isbn = book.Isbn,
                Description = book.Description,
                ImageFileName = book.ImageFile,
                Categories = categories
            };

            return View(bookDetailsView);
        }

        private string UploadCoverImage(AddBookViewModel addBookViewModel)
        {
            string fileName = null;

            if (addBookViewModel.ImageFile != null)
            {
                fileName = addBookViewModel.Isbn + "_" + addBookViewModel.ImageFile.FileName;
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/covers", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    addBookViewModel.ImageFile.CopyTo(fileStream);
                }
            }

            return fileName;
        }
    }
}
