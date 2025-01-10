using MusicCRUD.DataAccess.DataAccess.Entity;
using System.Text.Json;

namespace MusicCRUD.Repository.Service;

public class MusicRepository : IMusicRepository
{
    private readonly string _Path;
    private List<Music> _musics;
    public MusicRepository()
    {
        _Path = Path.Combine(Directory.GetCurrentDirectory(), "Music.json");
        _musics = new List<Music>();
        if (!File.Exists(_Path))
        {
            File.WriteAllText(_Path, "[]");
        }
        _musics = GetAllMusic();
    }
    private void SaveInformation(List<Music> obj)
    {
        var json = JsonSerializer.Serialize(obj);
        File.WriteAllText(_Path, json);
    }
    private List<Music> GetAllMusic()
    {
        var json = File.ReadAllText(_Path);
        var file = JsonSerializer.Deserialize<List<Music>>(json);
        return file;
    }
    public Music AddMusic(Music obj)
    {
        _musics.Add(obj);
        SaveInformation(_musics);
        return obj;
    }

    public void DeleteMusic(Guid id)
    {
        var guId = GetById(id);
        _musics.Remove(guId);
        SaveInformation(_musics);
    }

    public List<Music> GetAll()
    {
        return GetAllMusic();
    }

    public Music GetById(Guid id)
    {
        var musicById = GetAll().FirstOrDefault(ms => ms.Id == id);
        return null == musicById ? throw new Exception($"Not Find id: {id}!") : musicById;
    }

    public void UpdateMusic(Music obj)
    {
        var id = GetById(obj.Id);
        _musics[_musics.IndexOf(id)] = obj;
        SaveInformation(_musics);
    }
}
