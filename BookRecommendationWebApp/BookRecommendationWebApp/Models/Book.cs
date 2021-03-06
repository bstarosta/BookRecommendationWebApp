﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookRecommendationWebApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public string ImageFile { get; set; }
        public string Description { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }

        [NotMapped]
        public double UserPreferenceValue { get; set; }
    }
}
