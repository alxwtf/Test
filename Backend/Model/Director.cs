using System.Collections.Generic;

namespace Backend.Model
{
    public class Director
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movie { get; set;}
    }
}