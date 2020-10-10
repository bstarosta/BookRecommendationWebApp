using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookRecommendationWebApp.Models.Accounts;

namespace BookRecommendationWebApp.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }

    }
}
