using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRecommendationWebApp.Models;

namespace BookRecommendationWebApp.ViewModels
{
    public class BrowseBooksViewModel
    {
        public Category SelectedCategory { get; set; }
        public List<Book> BooksToDisplay { get; set; }
        public List<Category> Categories { get; set; }
        public string SearchInput { get; set; }
    }
}
