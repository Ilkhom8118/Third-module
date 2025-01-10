using MusicCRUD.DataAccess.DataAccess.Entity;
using MusicCRUD.Service.DTOs;

namespace MusicCRUD.Service.Service
{
    public interface IMusicService
    {
        Music AddMusic(MusicDto obj);
        void DeleteMusic(Guid id);
        void UpdateMusic(Music obj);
        List<MusicDto> GetAll();
        MusicDto GetById(Guid id);
        List<MusicDto> GetAllMusicByAuthorName(string name);
        MusicDto GetMostLikedMusic();
        MusicDto GetMusicByName(string name);
        List<MusicDto> GetAllMusicAboveSize(double minSize);
        List<MusicDto> GetTopMostLikedMusic(int count);
        List<MusicDto> GetMusicByDescriptionKeyword(string keyword);
        List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes);
        List<string> GetAllUniqueAuthors();
        double GetTotalMusicSizeByAuthor(string authorName);
    }
}