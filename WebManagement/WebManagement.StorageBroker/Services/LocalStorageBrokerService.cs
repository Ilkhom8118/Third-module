
namespace WebManagement.StorageBroker.Services;

public class LocalStorageBrokerService : IStorageBrokerService
{
    private readonly string _dataPath;
    public LocalStorageBrokerService()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
        }
    }
    public void CreateDirectory(string directoryPath)
    {   
        Directory.CreateDirectory(directoryPath);
    }

    public List<string> GetAllFilesAndDirectories(string directory)
    {
        var res = Directory.GetFileSystemEntries(directory).ToList();
        return res;
    }

    public void UploadFile(string filePath, Stream stream)
    {
        using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            fileStream.CopyTo(stream);
        }
    }
}
