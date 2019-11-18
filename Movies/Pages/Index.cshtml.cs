using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        public List<Movie> Movies { get; set; }
        public MovieDatabase MovieDatabase = new MovieDatabase();

        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }

        public void OnPost(string search, List<string> ratings)
        {
            Movies = MovieDatabase.SearchAndFilter(search, ratings);
        }
    }
}