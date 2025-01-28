using MovieCRUD.DataAccess.Entity;
using MovieCRUD.Service.DTOs;
using MovieStorageBroker.Service;

namespace MovieCRUD.Service.Service;

public class MovieService : IMovieService
{
    private readonly IMovieStorageBroker _moive;

    public MovieService()
    {
        _moive = new MovieStorageBrokers();
    }
    private Movie ConvertToEntity(MovieDto obj)
    {
        return new Movie()
        {
            Title = obj.Title,
            Rating = obj.Rating,
            Director = obj.Director,
            Id = obj.Id ?? Guid.NewGuid(),
            ReleaseDate = obj.ReleaseDate,
            DurationMinutes = obj.DurationMinutes,
            BoxOfficeEarnings = obj.BoxOfficeEarnings,
        };
    }

    private MovieDto ConvertToDto(Movie obj)
    {
        return new MovieDto()
        {
            Id = obj.Id,
            Title = obj.Title,
            Rating = obj.Rating,
            Director = obj.Director,
            ReleaseDate = obj.ReleaseDate,
            DurationMinutes = obj.DurationMinutes,
            BoxOfficeEarnings = obj.BoxOfficeEarnings,
        };
    }
    public Movie AddMovie(MovieDto obj)
    {
        var convert = ConvertToEntity(obj);
        return _moive.AddMovie(convert);
    }

    public void DeleteMovie(Guid id)
    {
        _moive.DeleteMovie(id);
    }

    public List<MovieDto> GetAllMovie()
    {
        return _moive.GetAllMovie().Select(m => ConvertToDto(m)).ToList();
    }

    public List<MovieDto> GetAllMoviesByDirector(string director)
    {
        return GetAllMovie().Where(m => m.Director == director).ToList();
    }

    public MovieDto GetById(Guid id)
    {
        var res = GetAllMovie().FirstOrDefault(m => m.Id == id);
        if (res == null)
        {
            throw new Exception("Find not id");
        }
        return res;
    }

    public MovieDto GetHighestGrossingMovie()
    {
        var movies = GetAllMovie();
        var movie = movies.Max(mv => mv.BoxOfficeEarnings);
        var result = movies.FirstOrDefault(mv => mv.BoxOfficeEarnings == movie);

        if (result is null)
        {
            throw new Exception("No any movie here!");
        }

        return result;
    }

    public List<MovieDto> GetMoviesReleasedAfterYear(int year)
    {
        return GetAllMovie().Where(m => m.ReleaseDate.Year > year).ToList();
    }

    public List<MovieDto> GetMoviesSortedByRating()
    {
        return GetAllMovie().OrderBy(m => m.Rating).ToList();
    }

    public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        return GetAllMovie().Where(m => m.DurationMinutes > minMinutes && m.DurationMinutes < maxMinutes).ToList();
    }

    public List<MovieDto> GetRecentMovies(int years)
    {
        return GetAllMovie().Where(m => m.ReleaseDate.Year == years).ToList();
    }

    public MovieDto GetTopRatedMovie()
    {
        var res = GetAllMovie().OrderByDescending(m => m.Rating).FirstOrDefault();
        if (res == null)
        {
            throw new Exception("Rentingdagi filmlar mavjud emas");
        }
        return res;
    }


    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        return GetAllMovie().Where(m => m.Director == director).Sum(m => m.BoxOfficeEarnings);
    }

    public List<MovieDto> SearchMoviesByTitle(string keyword)
    {
        return GetAllMovie().Where(m => m.Title.Contains(keyword)).ToList();
    }

    public void UpdataMovie(MovieDto obj)
    {
        _moive.UpdateMovie(ConvertToEntity(obj));
    }
}
