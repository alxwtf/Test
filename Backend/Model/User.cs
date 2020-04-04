using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Backend.Model
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<UserMoviesList> MoviesLists { get; set; }
        public List<UserFavourite> FavMovies { get; set; }
        public List<Review> Reviews { get; set; }
    }
}