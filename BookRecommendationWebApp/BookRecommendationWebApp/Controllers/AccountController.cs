﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookRecommendationWebApp.Data;
using BookRecommendationWebApp.Models;
using BookRecommendationWebApp.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookRecommendationWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public AccountController(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginModel);
            }
            var result = await _signInManager.PasswordSignInAsync(userLoginModel.UserName, userLoginModel.Password, userLoginModel.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationModel userRegistrationModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegistrationModel);
            }
            var user = _mapper.Map<User>(userRegistrationModel);
            var result = await _userManager.CreateAsync(user, userRegistrationModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(userRegistrationModel);
            }

            List<Category> categories = _dbContext.Categories.ToList();
            User newUser = await _userManager.FindByNameAsync(userRegistrationModel.UserName);
            foreach (var category in categories)
            {
              await _dbContext.UserPreferences.AddAsync(new UserPreference
                    {User = newUser , Category = category, Preference = 0});
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Login),"Account");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(BooksController.Browse), "Books");

        }
    }
}
