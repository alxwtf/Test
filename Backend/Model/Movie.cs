using System.Collections.Generic;

namespace Backend.Model
{
    public class Movie
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public string Description { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public List<Review> Reviews { get; set; }
        public List<UserMoviesList> UserMovies { get; set; }
        public List<UserFavourite> UserFavMovies { get; set; }
        public List<MovieGenres> MovieGenres { get; set; }
        public List<MovieActors> MovieActors { get; set; }
        public Movie()
        {
            MovieGenres = new List<MovieGenres>();
            MovieActors = new List<MovieActors>();
        }
    }
}