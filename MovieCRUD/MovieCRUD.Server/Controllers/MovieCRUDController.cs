using Microsoft.AspNetCore.Mvc;
using MovieCRUD.DataAccess.Entity;
using MovieCRUD.Service.DTOs;
using MovieCRUD.Service.Service;

namespace MovieCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCRUDController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieCRUDController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpPost("addMovie")]
        public Movie AddMovie(MovieDto obj)
        {
            return _movieService.AddMovie(obj);
        }
    }
}
