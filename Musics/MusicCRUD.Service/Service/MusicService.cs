using MusicCRUD.DataAccess.DataAccess.Entity;
using MusicCRUD.Repository.Service;
using MusicCRUD.Service.DTOs;

namespace MusicCRUD.Service.Service
{
    public class MusicService : IMusicService
    {
        private readonly IMusicRepository _musicRepo;

        public MusicService()
        {
            _musicRepo = new MusicRepository();
        }

        private Music ConvertToEntity(MusicBaseDto obj)
        {
            return new Music()
            {
                MB = obj.MB,
                Name = obj.Name,
                AuthorName = obj.AuthorName,
                Description = obj.Description,
                QuentityLikes = obj.QuentityLikes,
            };
        }

        private MusicDto ConvertToDto(Music obj)
        {
            return new MusicDto()
            {
                Id = obj.Id,
                MB = obj.MB,
                Name = obj.Name,
                AuthorName = obj.AuthorName,
                Description = obj.Description,
                QuentityLikes = obj.QuentityLikes,
            };
        }
        private Music ConvertEntity(MusicDto obj)
        {
            return new Music()
            {
                Id = obj.Id,
                MB = obj.MB,
                Name = obj.Name,
                AuthorName = obj.AuthorName,
                Description = obj.Description,
                QuentityLikes = obj.QuentityLikes,
            };
        }
        private Music ConvertToEntity(MusicDto obj)
        {
            return new Music()
            {
                Id = obj.Id,
                MB = obj.MB,
                Name = obj.Name,
                AuthorName = obj.AuthorName,
                Description = obj.Description,
                QuentityLikes = obj.QuentityLikes,
            };
        }
        public Music AddMusic(MusicDto obj)
        {
            var convert = ConvertToEntity(obj);
            _musicRepo.AddMusic(convert);
            return convert;
        }

        public void DeleteMusic(Guid id)
        {
            _musicRepo.DeleteMusic(id);
        }

        public List<MusicDto> GetAll()
        {
            return _musicRepo.GetAll().Select(m => ConvertToDto(m)).ToList();
        }

        public List<MusicDto> GetAllMusicAboveSize(double minSize)
        {
            return GetAll().Where(m => m.MB > minSize).ToList();
        }

        public List<MusicDto> GetAllMusicByAuthorName(string name)
        {
            return GetAll().Where(a => a.AuthorName == name).ToList();
        }

        public List<string> GetAllUniqueAuthors()
        {
            return GetAll().GroupBy(m => m.AuthorName).Select(g => g.Key).ToList();
        }

        public MusicDto GetById(Guid id)
        {
            var byId = GetAll().SingleOrDefault(m => m.Id == id);
            if (null == byId)
            {
                throw new Exception($"Not Find id : {id}");
            }
            return byId;
        }

        public MusicDto GetMostLikedMusic()
        {
            var res = GetAll().OrderByDescending(m => m.QuentityLikes).FirstOrDefault();
            if (res == null)
            {
                throw new Exception("No music found");
            }
            return res;
        }

        public List<MusicDto> GetMusicByDescriptionKeyword(string keyword)
        {
            return GetAll().Where(m => m.Description.Contains(keyword)).ToList();
        }

        public MusicDto GetMusicByName(string name)
        {
            var res = GetAll().FirstOrDefault(m => m.Name == name);
            if (null == res)
            {
                throw new Exception($"No Name {name}");
            }
            return res;
        }

        public List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes)
        {
            return GetAll().Where(m => m.QuentityLikes >= minLikes && m.QuentityLikes <= maxLikes).ToList();
        }

        public List<MusicDto> GetTopMostLikedMusic(int count)
        {
            return GetAll().OrderByDescending(m => m.QuentityLikes).Take(count).ToList();
        }

        public double GetTotalMusicSizeByAuthor(string authorName)
        {
            return GetAll().Where(m => m.AuthorName == authorName).Sum(m => m.MB);
        }

        public void UpdateMusic(Music obj)
        {
            _musicRepo.UpdateMusic(obj);
        }
    }
}
