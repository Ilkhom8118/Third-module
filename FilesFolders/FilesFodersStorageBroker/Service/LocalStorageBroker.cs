using System.IO.Compression;

namespace FilesFodersStorageBroker.Service;

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
    private void ValidateDirectory(string direcory)
    {
        if (Directory.Exists(direcory))
        {
            throw new Exception("Folder has already create");
        }
        var parentPath = Directory.GetParent(direcory);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
    }
    public void CreateFolder(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        ValidateDirectory(filePath);
        Directory.CreateDirectory(filePath);
    }

    public void DeleteFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("Not file");
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
        var zip = directoryPath + ".zip";
        ZipFile.CreateFromDirectory(directoryPath, zip);

        var stream = new FileStream(zip, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public List<string> GetAllDirectory(string directory)
    {
        directory = Path.Combine(_dataPath, directory);
        var parentPath = Directory.GetParent(directory);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
        var all = Directory.GetFileSystemEntries(directory).ToList();
        all = all.Select(f => f.Remove(0, directory.Length + 1)).ToList();

        return all;
    }

    public void UploadFile(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath, filePath);
        var parentPath = Directory.GetParent(filePath);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            stream.CopyTo(fs);
        }
    }
}
