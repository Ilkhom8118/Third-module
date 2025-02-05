using System.IO.Compression;

namespace WebManagement.StorageBroker.Services;

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
    public async Task CreateDirectory(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        if (Directory.Exists(directoryPath))
        {
            throw new Exception("Folder has ready created");
        }
        var parent = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parent?.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
        Directory.CreateDirectory(directoryPath);
    }

    public async Task DeleteDirectory(string directory)
    {
        directory = Path.Combine(_dataPath, directory);
        var parent = Directory.GetParent(directory);
        if (!Directory.Exists(parent.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
        Directory.Delete(directory);
    }

    public async Task DeleteFile(string file)
    {
        file = Path.Combine(_dataPath, file);
        if (!File.Exists(file))
        {
            throw new Exception("Parent folder path not found");
        }
        File.Delete(file);
    }

    public async Task<Stream> DownloadDirecotyAsZip(string directory)
    {
        directory = Path.Combine(_dataPath, directory);

        if (Path.GetExtension(directory) != string.Empty)
        {
            throw new Exception("DirectoryPath is not directory");
        }
        
        var zip = directory + ".zip";
        ZipFile.CreateFromDirectory(directory, zip);
        var fs = new FileStream(zip, FileMode.Open, FileAccess.Read);
        return fs;
    }


    public async Task<Stream> DownloadFile(string directory)
    {
        directory = Path.Combine(_dataPath, directory);
        if (!File.Exists(directory))
        {
            throw new Exception("not found");
        }
        var stream = new FileStream(directory, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public async Task<List<string>> GetAllFilesAndDirectories(string directory)
    {
        directory = Path.Combine(_dataPath, directory);
        var parent = Directory.GetParent(directory);
        if (!Directory.Exists(parent.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
        var all = Directory.GetFileSystemEntries(directory).ToList();
        all = all.Select(g => g.Remove(0, directory.Length + 1)).ToList();
        return all;
    }

    public async Task UploadFile(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath, filePath);
        var parent = Directory.GetParent(filePath);
        if (!Directory.Exists(parent.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
        using (var stm = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            await stream.CopyToAsync(stm);
        }
    }
}
