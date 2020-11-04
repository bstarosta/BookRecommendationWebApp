using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRecommendationWebApp.API.GoogleBooksAPI;

namespace BookRecommendationWebApp.API
{
    public class GoogleBooksApiResponse
    {
        public List<GoogleBooksBook> Items { get; set; }
    }
}
