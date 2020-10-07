using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRecommendationWebApp.Models
{
    public class BookDetailsViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public List<Category> Categories { get; set; }
        public int UserRating { get; set; }
        public float AverageRating { get; set; }
        public int RatingsCount { get; set; }
    }
}
