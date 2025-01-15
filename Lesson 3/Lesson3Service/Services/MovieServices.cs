using Lesson3DataAccess.Entity;
using Lesson3Repository.Service;
using Lesson3Service.DTOs;

namespace Lesson3Service.Service;

public class MovieServices : IMovieService
{
    private readonly IMovieRepo movies;
    public MovieServices()
    {
        movies = new MovieRepo();
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
        movies.AddMoviee(convert);
        return convert;
    }

    public void DeleteMovie(Guid id)
    {
        GetAll().FirstOrDefault(m => m.Id == id);
    }

    public List<MovieDto> GetAll()
    {
        return movies.GetAll().Select(m => ConvertToDto(m)).ToList();
    }

    public List<MovieDto> GetAllMoviesByDirector(string director)
    {
        return GetAll().Where(m => m.Director == director).ToList();
    }

    public MovieDto GetById(Guid id)
    {
        var res = GetAll().FirstOrDefault(m => m.Id == id);
        if (res == null)
        {
            throw new Exception($"Not Find id: {id}");
        }
        return res;
    }

    public MovieDto GetHighestGrossingMovie()
    {
        var res = GetAll().OrderByDescending(m => m.BoxOfficeEarnings).FirstOrDefault();
        if (res == null)
        {
            throw new Exception("Eng qimmati mavjud emas!");
        }
        return res;
    }

    public List<MovieDto> GetMoviesReleasedAfterYear(int year)
    {
        return GetAll().Where(m => m.ReleaseDate.Year > year).ToList();
    }

    public List<MovieDto> GetMoviesSortedByRating()
    {
        return GetAll().OrderBy(m => m).ToList();
    }

    public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        return GetAll().Where(m => m.DurationMinutes > minMinutes && m.DurationMinutes < maxMinutes).ToList();
    }

    public List<MovieDto> GetRecentMovies(int years)
    {
        return GetAll().Where(m => m.ReleaseDate.Year > years).ToList();
    }

    public MovieDto GetTopRatedMovie()
    {
        var res = GetAll().OrderByDescending(m => m.Rating).FirstOrDefault();
        if (res == null)
        {
            throw new Exception($"Retingda turgan movie yo'q");
        }
        return res;
    }

    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        return GetAll().Where(m => m.Director == director).Sum(m => m.BoxOfficeEarnings);
    }

    public List<MovieDto> SearchMoviesByTitle(string keyword)
    {
        return GetAll().Where(m => m.Title.Contains(keyword)).ToList();
    }

    public void UpdateMovie(MovieDto obj)
    {
        movies.UpdateMovie(ConvertToEntity(obj));
    }
}
