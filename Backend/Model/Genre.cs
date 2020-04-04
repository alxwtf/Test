using System.Collections.Generic;

namespace Backend.Model
{
    public class Genre
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<MovieGenres> MovieGenres { get; set; }

        public Genre()
        {
            MovieGenres = new List<MovieGenres>();
        }
    }
}