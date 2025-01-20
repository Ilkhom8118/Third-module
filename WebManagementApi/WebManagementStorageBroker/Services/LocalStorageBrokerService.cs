namespace WebManagementStorageBroker.Services;

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
        directoryPath = Path.Combine(_dataPath, directoryPath);
        ValidateDirectory(directoryPath);
        Directory.CreateDirectory(directoryPath);
    }

    public List<string> GetAllFilesAndDirectories(string directory)
    {
        directory = Path.Combine(_dataPath, directory);
        var parentPath = Directory.GetParent(directory);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
        var allFileAndFolder = Directory.GetFileSystemEntries(directory).ToList();
        allFileAndFolder = allFileAndFolder.Select(p => p.Remove(0, directory.Length + 1)).ToList();
        return allFileAndFolder;
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

    private void ValidateDirectory(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            throw new Exception("Folder has already created");
        }
        var parentPath = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
    }
}
