using Lesson3DataAccess.Entity;
using Lesson3Service.DTOs;
using Lesson3Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lesson3CRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movies;
        public MovieController()
        {
            movies = new MovieServices();
        }
        [HttpPost("addMovie")]
        public Movie AddMovie(MovieDto obj)
        {
            return movies.AddMovie(obj);
        }
        [HttpDelete("deleteMovie")]
        public void DeleteMovie(Guid id)
        {
            movies.DeleteMovie(id);
        }
        [HttpPut("updateMovie")]
        public void UpdateMovie(MovieDto obj)
        {
            movies.UpdateMovie(obj);
        }
        [HttpGet("getAll")]
        public List<MovieDto> GetAll()
        {
            return movies.GetAll();
        }
        [HttpGet("getById")]
        public MovieDto GetById(Guid id)
        {
            return movies.GetById(id);
        }
        [HttpGet("getTopRatedMovie")]
        public MovieDto GetTopRatedMovie()
        {
            return movies.GetTopRatedMovie();
        }
        [HttpGet("getHighestGrossingMovie")]
        public MovieDto GetHighestGrossingMovie()
        {
            return movies.GetHighestGrossingMovie();
        }
        [HttpGet("getMoviesSortedByRating")]
        public List<MovieDto> GetMoviesSortedByRating()
        {
            return movies.GetMoviesSortedByRating();
        }
        [HttpGet("getRecentMovies")]
        public List<MovieDto> GetRecentMovies(int years)
        {
            return movies.GetRecentMovies(years);
        }
        [HttpGet("searchMoviesByTitle")]
        public List<MovieDto> SearchMoviesByTitle(string keyword)
        {
            return movies.SearchMoviesByTitle(keyword);
        }
        [HttpGet("getMoviesReleasedAfterYear")]
        public List<MovieDto> GetMoviesReleasedAfterYear(int year)
        {
            return movies.GetMoviesReleasedAfterYear(year);
        }
        [HttpGet("getAllMoviesByDirector")]
        public List<MovieDto> GetAllMoviesByDirector(string director)
        {
            return movies.GetAllMoviesByDirector(director);
        }
        [HttpGet("getTotalBoxOfficeEarningsByDirector")]
        public long GetTotalBoxOfficeEarningsByDirector(string director)
        {
            return movies.GetTotalBoxOfficeEarningsByDirector(director);
        }
        [HttpGet("getMoviesWithinDurationRange")]
        public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
        {
            return movies.GetMoviesWithinDurationRange(minMinutes, maxMinutes);
        }
    }
}
