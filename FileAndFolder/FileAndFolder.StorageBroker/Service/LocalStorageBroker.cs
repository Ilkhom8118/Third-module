

using System.IO.Compression;

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

    public async Task CreateDirectory(string directory)
    {
        directory = Path.Combine(_dataPath, directory);
        ValidateDirectoryPath(directory);
        Directory.CreateDirectory(directory);
    }

    public async Task DeleteFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception($"Not found : {filePath}");
        }
        File.Delete(filePath);
    }

    public async Task<Stream> DownloadDirecotryAsZip(string direcotry)
    {
        direcotry = Path.Combine(_dataPath, direcotry);
        var parent = Directory.GetParent(direcotry);
        if (!Directory.Exists(parent.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
        var zip = direcotry + ".zip";
        ZipFile.CreateFromDirectory(direcotry, zip);
        var stream = new FileStream(zip, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public async Task<Stream> DownloadFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("not Found");
        }
        var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public async Task<List<string>> GetAll(string path)
    {
        path = Path.Combine(_dataPath, path);
        var parent = Directory.GetParent(path);
        if (!Directory.Exists(parent?.FullName))
        {
            throw new Exception("Parent folder path not found");
        }
        var all = Directory.GetFileSystemEntries(path).ToList();
        all = all.Select(a => a.Remove(0, path.Length + 1)).ToList();
        return all;
    }

    public async Task GetTextOfTxtFile(string filePath, string textToUpdate)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("Not found");
        }
        var infoInFile = string.Empty;
        using (var res = new StreamReader(filePath))
        {
            infoInFile = await res.ReadToEndAsync();
        }
        await UpdateTextOfTxtFile(filePath, textToUpdate, infoInFile);
    }

    public async Task UpdateTextOfTxtFile(string filePath, string newFile, string info)
    {
        info.ToUpper();

        using (var sw = new StreamWriter(filePath))
        {
            sw.Write(info);
        }
    }

    public async Task UploadFile(string filePath, Stream stream)
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
            throw new Exception("Bunday file mavjud");
        }
        var parentPath = Directory.GetParent(path);
        if (!Directory.Exists(parentPath.FullName))
        {
            var i = 1;
            while (true)
            {
                var directory = Path.GetDirectoryName(path) + $"{++i}";
                Directory.CreateDirectory(directory);
                break;
            }
        }
    }
}
