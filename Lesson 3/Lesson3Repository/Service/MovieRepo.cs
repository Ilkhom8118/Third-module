using Lesson3DataAccess.Entity;
using System.Text.Json;

namespace Lesson3Repository.Service;

public class MovieRepo : IMovieRepo
{
    private readonly string _path;
    private readonly string _directory;
    private List<Movie> _movies;
    public MovieRepo()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Movie.json");
        _directory = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(_directory))
        {
            Directory.CreateDirectory(_directory);
        }
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _movies = GetAllMovie();

    }
    private void SaveInformation(List<Movie> obj)
    {
        var json = JsonSerializer.Serialize(obj);
        File.WriteAllText(_path, json);
    }
    private List<Movie> GetAllMovie()
    {
        var json = File.ReadAllText(_path);
        var file = JsonSerializer.Deserialize<List<Movie>>(json);
        return file;
    }
    public Movie AddMoviee(Movie obj)
    {
        _movies.Add(obj);
        SaveInformation(_movies);
        return obj;
    }

    public void DeleteMovie(Guid id)
    {
        var guId = GetById(id);
        _movies.Remove(guId);
        SaveInformation(_movies);
    }

    public List<Movie> GetAll()
    {
        return GetAllMovie();
    }

    public Movie GetById(Guid id)
    {
        var res = GetAllMovie().FirstOrDefault(m => m.Id == id);
        if (res == null)
        {
            throw new Exception($"Not Find id: {id}");
        }
        return res;
    }

    public void UpdateMovie(Movie obj)
    {
        _movies[_movies.IndexOf(GetById(obj.Id))] = obj;
        SaveInformation(_movies);
    }
}
