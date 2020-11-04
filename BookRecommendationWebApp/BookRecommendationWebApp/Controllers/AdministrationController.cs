using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRecommendationWebApp.Data;
using BookRecommendationWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using static System.String;

namespace BookRecommendationWebApp.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public AdministrationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult AdminPanel(string? searchInput)
        {
            List<Book> books = _dbContext.Books.ToList();
            if (!IsNullOrEmpty(searchInput))
            {
                books = books.Where(x => x.Title.ToUpper().Contains(searchInput.ToUpper()) || x.Author.ToUpper().Contains(searchInput.ToUpper()) || x.Isbn.Contains(searchInput)).ToList();
            }
            return View(books);
        }
    }
}
