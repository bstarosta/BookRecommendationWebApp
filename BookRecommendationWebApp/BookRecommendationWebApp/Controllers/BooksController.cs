using System;
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
                string coverImageFileName = addBookViewModel.Isbn;
                UploadCoverImage(addBookViewModel);
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

        private void UploadCoverImage(AddBookViewModel addBookViewModel)
        {
            if (addBookViewModel.ImageFile != null)
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/covers", addBookViewModel.Isbn);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    addBookViewModel.ImageFile.CopyTo(fileStream);
                }
            }
        }
    }
}
