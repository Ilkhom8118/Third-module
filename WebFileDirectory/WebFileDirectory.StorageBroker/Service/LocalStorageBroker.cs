using System.IO.Compression;

namespace WebFileDirectory.StorageBroker.Service;

public class LocalStorageBroker : IStorageBrokers
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
    private void ValidateDirectory(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            throw new Exception("Folder has already create");
        }
        var parentPath = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parentPath?.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
    }
    public async Task CreateDirectoryAysnc(string? directoryPath)
    {
        directoryPath = directoryPath ?? string.Empty;
        ValidateDirectory(directoryPath);
        Directory.CreateDirectory(directoryPath);
    }

    public async Task<List<string>> GetAllAysnc(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        var parentPath = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent Folder path not found");
        }
        var all = Directory.GetFileSystemEntries(directoryPath).ToList();
        all = all.Select(d => d.Remove(0, directoryPath.Length + 1)).ToList();
        return all;
    }

    public async Task UploadFileAysnc(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath, filePath);
        var parentPath = Directory.GetParent(filePath);
        if (!Directory.Exists(filePath))
        {
            throw new Exception("Parent folder path not found");
        }
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            await stream.CopyToAsync(fs);
        }
    }

    public async Task DeleteFileAysnc(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("This not found");
        }
        File.Delete(filePath);
    }

    public async Task<Stream> DownloadFileAysnc(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("This not found");
        }
        var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public async Task<Stream> DownloadFolderAsZipAysnc(string directoryPath)
    {
        if (Path.GetExtension(directoryPath) != string.Empty)
        {
            throw new Exception("DirectoryPath is not directory");
        }
        directoryPath = Path.Combine(_dataPath, directoryPath);
        if (!Directory.Exists(directoryPath))
        {
            throw new Exception("Directory not found not download");
        }
        var zip = directoryPath + ".zip";
        ZipFile.CreateFromDirectory(directoryPath, zip);
        var stream = new FileStream(zip, FileMode.Create, FileAccess.Write);
        return stream;
    }
}
