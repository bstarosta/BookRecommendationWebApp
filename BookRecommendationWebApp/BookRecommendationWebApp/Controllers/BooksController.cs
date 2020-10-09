using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Threading.Tasks;
using BookRecommendationWebApp.Data;
using BookRecommendationWebApp.Models;
using BookRecommendationWebApp.Models.Accounts;
using BookRecommendationWebApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;

        public BooksController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
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

            var ratingQuery = _dbContext.Reviews.Where(r =>
                r.User.Id == _userManager.GetUserId(this.User) && r.Book.BookId == bookId);

            var allRatingsQuery = _dbContext.Reviews.Where(r => r.Book.BookId == bookId);

            BookDetailsViewModel bookDetailsView = new BookDetailsViewModel
            {
                BookId = bookId,
                Title = book.Title,
                Author = book.Author,
                Isbn = book.Isbn,
                Description = book.Description,
                ImageFileName = book.ImageFile,
                Categories = categories,
                UserRating = ratingQuery.Any() ? ratingQuery.First().Rating : 0,
                AverageRating = allRatingsQuery.Any() ? CalculateAverageRating(allRatingsQuery.ToList()) : 0,
                RatingsCount = allRatingsQuery.Count()
            };
            return View(bookDetailsView);
        }

        [HttpPost]
        public IActionResult BookDetails(int rating, int bookID)
        {
            var review = new Review()
            {
                Book = _dbContext.Books.Find(bookID),
                User = _dbContext.Users.Find(_userManager.GetUserId(this.User)),
                Rating = rating,
                Date = DateTime.Now
            };
            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
            return RedirectToAction("BookDetails", new { bookId = bookID});
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

        private double CalculateAverageRating(List<Review> reviews)
        {
            double ratingSum = 0;
            foreach (var review in reviews)
            {
                ratingSum += review.Rating;
            }

            return Math.Round(ratingSum / reviews.Count, 2);
        }
    }
}
