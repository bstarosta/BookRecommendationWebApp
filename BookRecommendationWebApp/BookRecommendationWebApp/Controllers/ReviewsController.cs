using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRecommendationWebApp.Data;
using BookRecommendationWebApp.Models;
using BookRecommendationWebApp.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookRecommendationWebApp.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        public ReviewsController(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public IActionResult UserReviews()
        {
            List<Review> reviews = _dbContext.Reviews.Where(r =>
                r.User.Id == _userManager.GetUserId(this.User)).Include(r=>r.Book).OrderByDescending(r=>r.Date).ToList();
            return View(reviews);
        }
    }
}
