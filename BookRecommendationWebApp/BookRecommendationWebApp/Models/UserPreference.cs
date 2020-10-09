using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRecommendationWebApp.Models.Accounts;

namespace BookRecommendationWebApp.Models
{
    public class UserPreference
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Preference { get; set; }
    }
}
