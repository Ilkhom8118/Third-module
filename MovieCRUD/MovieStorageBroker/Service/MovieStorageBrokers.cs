using MovieCRUD.DataAccess.Entity;
using System.Text.Json;

namespace MovieStorageBroker.Service;

public class MovieStorageBrokers : IMovieStorageBroker
{
    private readonly string _path;
    private readonly string _directory;
    private readonly List<Movie> _movies;
    public MovieStorageBrokers()
    {
        _directory = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Music.json");
        _movies = new List<Movie>();
        if (!Directory.Exists(_directory))
        {
            Directory.CreateDirectory(_directory);
        }
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

    }
    private void SaveInformation(List<Movie> obj)
    {
        var json = JsonSerializer.Serialize(obj);
        File.WriteAllText(_path, json);
    }
    private List<Movie> GetAll()
    {
        var json = File.ReadAllText(_path);
        var file = JsonSerializer.Deserialize<List<Movie>>(json);
        return file;
    }
    public Movie AddMovie(Movie obj)
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

    public List<Movie> GetAllMovie()
    {
        return GetAll();
    }

    public Movie GetById(Guid id)
    {
        var res = GetAll().FirstOrDefault(m => m.Id == id);
        if (res == null)
        {
            throw new Exception($"Find not id : {id}");
        }
        return res;
    }

    public void UpdateMovie(Movie obj)
    {
        var id = GetById(obj.Id);
        _movies[_movies.IndexOf(id)] = obj;
        SaveInformation(_movies);
    }
}
