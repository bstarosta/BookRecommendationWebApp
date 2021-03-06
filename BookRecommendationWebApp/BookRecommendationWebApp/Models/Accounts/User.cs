﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookRecommendationWebApp.Models.Accounts
{
    public class User : IdentityUser
    {
        public ICollection<Review> Reviews { get; set; }
        public ICollection<UserPreference> UserPreferences { get; set; }
    }
}
