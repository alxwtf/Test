using System.Linq;
using Backend.Model;
using Backend.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly Context _db;

        public MovieController(Context db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet("GetMovies")]
        public ActionResult GetMovies()
        {
            var result = _db.Movies.Select(_ => new
            {
                _.id,
                _.Name,
                _.Poster
            });
            return Ok(result);
        }
        [HttpGet("GetMovies/{id}")]
        public ActionResult GetMovies(int id)
        {
            var result = _db.Movies
                            .Where(_ => _.id == id)
                            .Select(_ => new
                            {
                                _.Name,
                                _.Poster,
                                _.Description,
                                Director = _.Director.Name,
                                Genres = _.MovieGenres.OrderBy(i=>i.GenreId).Select(g => new { g.Genre.Name }).ToList(),
                                Actors = _.MovieActors.OrderBy(i=>i.ActorId).Select(a => new { a.Actor.Name }).ToList(),
                                Reviews = _.Reviews.Select(r => new
                                {
                                    User = $"{r.User.FirstName} {r.User.LastName}",
                                    r.Text
                                })
                            }).FirstOrDefault();
            return Ok(result);
        }
        [HttpGet("GetList/{id}")]
        [Authorize]
        public ActionResult GetList(int id)
        {
            var UserId = _userManager.GetUserId(User);
            if (UserId != null)
            {
                var list = _db.UserMoviesLists.Where(_ => _.UserId == int.Parse(UserId) && _.MovieId == id).FirstOrDefault();
                if (list != null)
                    return Ok(list.List);
                else return Ok("null");
            }
            else return BadRequest("Пользователь не найден");

        }
        [HttpGet("ReviewStatus/{id}")]
        [Authorize]
        public ActionResult ReviewStatus(int id)
        {
            var UserId = _userManager.GetUserId(User);
            if (UserId != null)
            {
                var list = _db.Reviews.Where(_ => _.UserId == int.Parse(UserId) && _.MovieId == id).Count();
                if (list > 0)
                    return Ok(true);
                else return Ok(false);
            }
            else return BadRequest("Пользователь не найден");
        }
        [HttpGet("FavStatus/{id}")]
        [Authorize]
        public ActionResult FavouriteStatus(int id)
        {
            var UserId = _userManager.GetUserId(User);
            if (UserId != null)
            {
                var fav = _db.UserFavourites.Where(_ => _.UserId == int.Parse(UserId) && _.MovieId == id).Count();
                if (fav > 0)
                    return Ok(true);
                else return Ok(false);
            }
            else return BadRequest("Пользователь не найден");
        }
        [HttpGet("GetGenres")]
        public ActionResult GetGenres()
        {
            var result = _db.Genres.Select(_ =>
                new
                {
                    _.id,
                    _.Name
                }
            );
            return Ok(result);
        }
        [HttpGet("GetActors")]
        public ActionResult GetActors()
        {
            var result = _db.Actors.Select(_ =>
                new
                {
                    _.id,
                    _.Name
                }
            );
            return Ok(result);
        }
        [HttpGet("GetDirectors")]
        public ActionResult GetDirectors()
        {
            var result = _db.Directors.Select(_ =>
                new
                {
                    _.id,
                    _.Name
                }
            );
            return Ok(result);
        }
        [HttpGet("filter")]
        public ActionResult Filter([FromQuery]FilterViewModel model)
        {
            var result = _db.Movies.AsQueryable();
            if (model.directorId.HasValue)
                result = result.Where(_ => _.DirectorId == model.directorId);
            if (model.genreId.HasValue)
                result = result.Where(_ => _.MovieGenres.Any(g => g.GenreId == model.genreId));
            if (model.actorId.HasValue)
                result = result.Where(_ => _.MovieActors.Any(a => a.ActorId == model.actorId));
            return Ok(result);
        }
        [HttpPost("AddToList")]
        [Authorize]
        public ActionResult AddToList(ListViewModel model)
        {
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {
                UserMoviesList moviesList;
                moviesList = _db.UserMoviesLists.Where(_ => _.UserId == int.Parse(userId) && _.MovieId == model.MovieId).FirstOrDefault();
                if (moviesList == null)
                {
                    moviesList = new UserMoviesList
                    {
                        UserId = int.Parse(userId),
                        MovieId = model.MovieId,
                        List = (Lst)model.ListId
                    };
                    _db.UserMoviesLists.Add(moviesList);
                }
                else
                {
                    moviesList.List = (Lst)model.ListId;
                    _db.UserMoviesLists.Update(moviesList);
                }
                _db.SaveChanges();
                return Ok("Выполнено успешно");
            }
            else return BadRequest("Пользователь не найден");
        }
        [HttpPost("AddReview")]
        [Authorize]
        public ActionResult AddReview(ReviewViewModel model)
        {
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {
                Review Review;
                Review = _db.Reviews.Where(_ => _.UserId == int.Parse(userId) && _.MovieId == model.MovieId).FirstOrDefault();
                if (Review == null)
                {
                    Review = new Review
                    {
                        UserId = int.Parse(userId),
                        MovieId = model.MovieId,
                        Text = model.Text
                    };
                    _db.Reviews.Add(Review);
                    _db.SaveChanges();
                }
                else BadRequest("Ваш обзор уже опубликован");
                return Ok("Выполнено успешно");
            }
            else return BadRequest("Пользователь не найден");
        }
        [HttpPost("AddToFavourite")]
        [Authorize]
        public ActionResult AddToFavourite(int id)
        {
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {
                var fav = new UserFavourite
                {
                    MovieId = id,
                    UserId = int.Parse(userId)
                };
                _db.UserFavourites.Add(fav);
                _db.SaveChanges();
                return Ok(true);
            }
            else return BadRequest("Пользователь не найден");
        }
        [HttpPost("RemoveFromFavourite")]
        [Authorize]
        public ActionResult RemoveFromFavourite(int id)
        {
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {
                var fav = _db.UserFavourites.FirstOrDefault(_ => _.MovieId == id && _.UserId == int.Parse(userId));
                _db.UserFavourites.Remove(fav);
                _db.SaveChanges();
                return Ok(false);
            }
            else return BadRequest("Пользователь не найден");
        }
    }
}