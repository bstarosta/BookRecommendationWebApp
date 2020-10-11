using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRecommendationWebApp.Models
{
    public class RecommendationsViewModel
    {
        public List<Book> RecommendedBooks { get; set; }
        public bool ProvidedEnoughReviews { get; set; }
    }
}
