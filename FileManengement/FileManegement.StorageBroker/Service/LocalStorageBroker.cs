
namespace FileManegement.StorageBroker.Service;

public class LocalStorageBroker : IStorageBroker
{
    private string _dataPath;
    public LocalStorageBroker()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
        }
    }
    public async Task CreateDirectory(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        if (Directory.Exists(directoryPath))
        {
            throw new Exception("Folder has already created");
        }
        var parentPath = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parentPath?.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
        Directory.CreateDirectory(directoryPath);
    }

}
