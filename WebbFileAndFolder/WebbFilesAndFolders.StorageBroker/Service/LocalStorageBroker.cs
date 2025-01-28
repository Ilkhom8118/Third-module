namespace WebbFilesAndFolders.StorageBroker.Service;

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

    public async Task CreateFolderAsync(string directoryPath)
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

    public async Task DeleteFileAsync(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("Not file");
        }
        File.Delete(filePath);
    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("File not found to download");
        }
        var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public Task<Stream> DownloadFolderAsZipAsync(string directoryPath)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> GetAllAsync(string directoryPath)
    {
        throw new NotImplementedException();
    }

    public Task UploadFileAsync(string filePath, Stream stream)
    {
        throw new NotImplementedException();
    }
}
