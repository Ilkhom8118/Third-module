using System.IO.Compression;

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

    public async Task<Stream> DownloadFolderAsZipAsync(string directoryPath)
    {
        if (Path.GetExtension(directoryPath) != string.Empty)
        {
            throw new Exception("DirectoryPath is not directory");
        }
        directoryPath = Path.Combine(_dataPath, directoryPath);
        var zip = directoryPath + ".zip";
        ZipFile.CreateFromDirectory(directoryPath, zip);
        var stream = new FileStream(zip, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public async Task<List<string>> GetAllAsync(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        var parentPath = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parentPath?.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
        var all = Directory.GetFileSystemEntries(directoryPath).ToList();
        all = all.Select(d => d.Remove(0, directoryPath.Length + 1)).ToList();
        return all;
    }

    public async Task UploadFileAsync(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath, filePath);
        var parentPath = Directory.GetParent(filePath);
        if (!Directory.Exists(parentPath?.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            stream.CopyTo(fs);
        }
    }
}
