using MusicCRUD.DataAccess.DataAccess.Entity;

namespace MusicCRUD.Repository.Service
{
    public interface IMusicRepository
    {
        Music AddMusic(Music obj);
        void DeleteMusic(Guid id);
        void UpdateMusic(Music obj);
        List<Music> GetAll();
        Music GetById(Guid id);
    }
}