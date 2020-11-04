using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookRecommendationWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace BookRecommendationWebApp.ViewModels
{
    public class EditBookViewModel
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        public string Isbn { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IEnumerable<int> SelectedCategories { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
