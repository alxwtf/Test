using System.Collections.Generic;

namespace Backend.Model
{
    public class Actor
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<MovieActors> MovieActors { get; set; }

        public Actor()
        {
            MovieActors = new List<MovieActors>();
        }
    }
}