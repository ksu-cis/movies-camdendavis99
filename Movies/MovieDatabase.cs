using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public static class MovieDatabase
    {
        private static List<Movie> movies;

        /// <summary>
        /// Loads the movie database from the JSON file
        /// </summary>
        public static List<Movie> All {
            get
            {
                if (movies == null)
                {
                    using (StreamReader file = System.IO.File.OpenText("movies.json"))
                    {
                        string json = file.ReadToEnd();
                        movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                    }
                }
                return movies;
            }
        }

        public static List<Movie> Search(List<Movie> movies, string term)
        {
            List<Movie> results = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if (movie.Title != null && movie.Title.Contains(term, StringComparison.OrdinalIgnoreCase))
                    results.Add(movie);
            }

            return results;
        }

        public static List<Movie> FilterByMPAA(List<Movie> movies, List<string> mpaa)
        {
            List<Movie> results = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if (mpaa.Contains(movie.MPAA_Rating))
                    results.Add(movie);
            }

            return results;
        }

        public static List<Movie> FilterByMinIMDB(List<Movie> movies, float rating)
        {
            List<Movie> results = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if (movie.IMDB_Rating != null && movie.IMDB_Rating >= rating)
                    results.Add(movie);
            }

            return results;
        }

        public static List<Movie> FilterByMaxIMDB(List<Movie> movies, float rating)
        {
            List<Movie> results = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if (movie.IMDB_Rating != null && movie.IMDB_Rating <= rating)
                    results.Add(movie);
            }

            return results;
        }
    }
}
