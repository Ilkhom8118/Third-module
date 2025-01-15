using Lesson3DataAccess.Entity;
using Lesson3Service.DTOs;

namespace Lesson3Service.Service;

public interface IMovieService
{
    Movie AddMovie(MovieDto obj);
    void DeleteMovie(Guid id);
    void UpdateMovie(MovieDto obj);
    List<MovieDto> GetAll();
    MovieDto GetById(Guid id);
    MovieDto GetTopRatedMovie();
    MovieDto GetHighestGrossingMovie();
    List<MovieDto> GetMoviesSortedByRating();
    List<MovieDto> GetRecentMovies(int years);
    List<MovieDto> SearchMoviesByTitle(string keyword);
    List<MovieDto> GetMoviesReleasedAfterYear(int year);
    List<MovieDto> GetAllMoviesByDirector(string director);
    long GetTotalBoxOfficeEarningsByDirector(string director);
    List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes);
}