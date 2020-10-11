using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Threading.Tasks;
using BookRecommendationWebApp.API;
using BookRecommendationWebApp.Data;
using BookRecommendationWebApp.Models;
using BookRecommendationWebApp.Models.Accounts;
using BookRecommendationWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
                Categories = _dbContext.Categories.OrderBy(c=>c.CategoryName).ToList(),
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

        public async Task<IActionResult> BookDetails(int bookId)
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
                BwaRating = GetBwaRating(bookId),
                GoogleBooksRating = await GetGoogleBooksRating(book.Isbn)

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
            List<Category> categories = _dbContext.Categories
                .Where(c => c.BookCategories.Any(bc => bc.BookId == bookID)).ToList();

            List<UserPreference> userPreferences = _dbContext.UserPreferences.Where(up =>
                categories.Contains(up.Category) && up.UserId == _userManager.GetUserId(this.User)).ToList();

            for (int i = 0; i < userPreferences.Count; i++)
            {
                userPreferences[i].Preference += 0.1 *(rating - 3) + 0.05;
            }

            _dbContext.SaveChanges();
            return RedirectToAction("BookDetails", new { bookId = bookID});
        }

        [Authorize]
        public async Task<IActionResult> Recommendations()
        {
            User user = await _userManager.GetUserAsync(this.User);
            List<UserPreference> userPreferences = _dbContext.UserPreferences
                .Where(up => up.UserId == _userManager.GetUserId(this.User)).ToList();
            List<Book> books = _dbContext.Books.Where(b => b.Reviews.All(r => r.User != user)).ToList();

            for(int i=0; i<books.Count; i++)
            {
                List<Category> categories = _dbContext.Categories
                    .Where(c => c.BookCategories.Any(bc => bc.BookId == books[i].BookId)).ToList();
                books[i].UserPreferenceValue =
                    CalculatePreference(userPreferences.Where(up => categories.Contains(up.Category)).ToList());

            }

            RecommendationsViewModel recommendationsViewModel = new RecommendationsViewModel
            {
                RecommendedBooks = books.OrderByDescending(b => b.UserPreferenceValue).Take(10).ToList(),
                ProvidedEnoughReviews = _dbContext.Reviews.Count(r => r.User == user) >= 3
            };

            return View(recommendationsViewModel);
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

        private Rating GetBwaRating(int bookId)
        {
            var allRatingsQuery = _dbContext.Reviews.Where(r => r.Book.BookId == bookId);

            return new Rating
            {
                AverageRating = allRatingsQuery.Any() ? CalculateAverageRating(allRatingsQuery.ToList()) : 0,
                RatingsCount = allRatingsQuery.Count()
            };
        }

        private async Task<Rating> GetGoogleBooksRating(string isbn)
        {

            GoogleBooksApiResponse response = await GoogleBooksApiProcessor.GetBookByIsbn(isbn);

            return new Rating
            {
                AverageRating = response.Items?[0].VolumeInfo.AverageRating ?? 0,
                RatingsCount = response.Items?[0].VolumeInfo.RatingsCount ?? 0
            };
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

        private double CalculatePreference(List<UserPreference> preferences)
        {
            double sum = 0;
            foreach (var preference in preferences)
            {
                sum += preference.Preference;
            }

            return sum / preferences.Count;
        }
    }
}
