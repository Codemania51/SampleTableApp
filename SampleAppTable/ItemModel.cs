using System;
using System.Collections.Generic;

namespace SampleAppTable
{
	public class ItemModel
	{
        public List<string> genres { get; set; }
        public List<MovieCategoriesList> CatetoriesMoviesList { get; set; }

        public List<Movie> movies { get; set; }
    }

    public class MovieCategoriesList
    {
        public List<Movie> movieList;

        public MovieCategoriesList(string genres, List<Movie> movieList)
        {
            this.genres = genres;
            this.movieList = movieList;
        }

        public string genres { get; set; }

    }
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public string year { get; set; }
        public string runtime { get; set; }
        public List<string> genres { get; set; }
        public string director { get; set; }
        public string actors { get; set; }
        public string plot { get; set; }
        public string posterUrl { get; set; }

    }
}

