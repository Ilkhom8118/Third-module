using MovieCRUD.DataAccess.Entity;
using MovieCRUD.Service.DTOs;

namespace MovieCRUD.Service.Service;

public interface IMovieService
{
    Movie AddMovie(MovieDto obj);
    void DeleteMovie(Guid id);
    void UpdataMovie(MovieDto obj);
    List<MovieDto> GetAllMovie();
    MovieDto GetById(Guid id);
    List<MovieDto> GetAllMoviesByDirector(string director);
    MovieDto GetTopRatedMovie();
    List<MovieDto> GetMoviesReleasedAfterYear(int year);
    MovieDto GetHighestGrossingMovie();
    List<MovieDto> SearchMoviesByTitle(string keyword);
    List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes);
    long GetTotalBoxOfficeEarningsByDirector(string director);
    List<MovieDto> GetMoviesSortedByRating();
    List<MovieDto> GetRecentMovies(int years);
}