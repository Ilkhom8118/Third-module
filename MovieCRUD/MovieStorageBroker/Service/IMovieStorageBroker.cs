using MovieCRUD.DataAccess.Entity;

namespace MovieStorageBroker.Service;

public interface IMovieStorageBroker
{
    Movie AddMovie(Movie obj);
    void DeleteMovie(Guid id);
    void UpdateMovie(Movie obj);
    List<Movie> GetAllMovie();
    Movie GetById(Guid id);
}