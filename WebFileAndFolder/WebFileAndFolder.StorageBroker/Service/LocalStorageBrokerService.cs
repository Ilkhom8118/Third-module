namespace WebFileAndFolder.StorageBroker.Service;

public class LocalStorageBrokerService : IStorageBrokerService
{
    private readonly string _dataPath;
    public LocalStorageBrokerService()
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
        ValidateDirectory(directory);
        Directory.CreateDirectory(directory);
    }

    public List<string> GetAllFilesAndDirectories(string directory)
    {
        directory = Path.Combine(_dataPath, directory);
        var parentPath = Directory.GetParent(directory);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
        var allFileAndDirectory = Directory.GetFileSystemEntries(directory).ToList();
        allFileAndDirectory = allFileAndDirectory.Select(f => f.Remove(0, directory.Length + 1)).ToList();
        return allFileAndDirectory;
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
    private void ValidateDirectory(string directory)
    {
        if (Directory.Exists(directory))
        {
            throw new Exception("Folder has already create");
        }
        var parentPath = Directory.GetParent(directory);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
    }
}
