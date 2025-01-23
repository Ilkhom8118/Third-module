using System.IO.Compression;

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

    public void DeleteDirectory(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        if (!Path.Exists(directoryPath))
        {
            throw new Exception("Directory not found to delete");
        }
        Directory.Delete(directoryPath, true);
    }

    public void DeleteFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("File not found to delete");
        }
        File.Delete(filePath);
    }

    public Stream DownloadFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("File not found to download");
        }
        var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public Stream DownloadFolderAsZip(string directoryPath)
    {
        if (Path.GetExtension(directoryPath) != string.Empty)
        {
            throw new Exception("DirectoryPath is not directory");
        }
        directoryPath = Path.Combine(_dataPath, directoryPath);
        if (!Directory.Exists(directoryPath))
        {
            throw new Exception("Directory not found to download");
        }
        var zipPath = directoryPath + ".zip";
        ZipFile.CreateFromDirectory(directoryPath, zipPath);
        var stream = new FileStream(zipPath, FileMode.Open, FileAccess.Read);
        return stream;

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
