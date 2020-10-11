using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookRecommendationWebApp.API
{
    public class GoogleBooksApiProcessor
    {
        public static async Task<GoogleBooksApiResponse> GetBookByIsbn(string isbn)
        {

            string url = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    GoogleBooksApiResponse books =
                        JsonConvert.DeserializeObject<GoogleBooksApiResponse>(responseString);
                    return books;
                }
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
