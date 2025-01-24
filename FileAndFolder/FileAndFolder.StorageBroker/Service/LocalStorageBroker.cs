
namespace FileAndFolder.StorageBroker.Service;

public class LocalStorageBroker : IStorageBroker
{
    private readonly string _dataPath;
    public LocalStorageBroker()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
        }
    }

    public void CreateDirectory(string directory)
    {
        directory = Path.Combine(_dataPath, directory);
        ValidateDirectoryPath(directory);
        Directory.CreateDirectory(directory);
    }

    public void UploadFile(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath, filePath);
        var parentPath = Directory.GetParent(filePath);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
        using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            stream.CopyTo(fileStream);
        }

    }
    private void ValidateDirectoryPath(string path)
    {
        if (Directory.Exists(path))
        {
            throw new Exception("Folder has already created");
        }
        var parentPath = Directory.GetParent(path);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
    }
}
