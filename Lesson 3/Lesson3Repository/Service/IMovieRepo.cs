using Lesson3DataAccess.Entity;

namespace Lesson3Repository.Service;

public interface IMovieRepo
{
    Movie AddMoviee(Movie obj);
    void DeleteMovie(Guid id);
    Movie GetById(Guid id);
    void UpdateMovie(Movie obj);
    List<Movie> GetAll();
}