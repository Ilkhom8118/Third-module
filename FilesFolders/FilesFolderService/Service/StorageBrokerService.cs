using FilesFodersStorageBroker.Service;

namespace FilesFolderService.Service;

public class StorageBrokerService : IStorageBrokerService
{
    private readonly IStorageBroker _storageBroker;

    public StorageBrokerService(IStorageBroker storageBroker)
    {
        _storageBroker = storageBroker;
    }

    public void CreateFolder(string filePath)
    {
        _storageBroker.CreateFolder(filePath);
    }

    public void DeleteFile(string filePath)
    {
        _storageBroker.DeleteFile(filePath);
    }

    public Stream DownloadFile(string filePath)
    {
        return _storageBroker.DownloadFile(filePath);
    }

    public Stream DownloadFolderAsZip(string directory)
    {
        return _storageBroker.DownloadFolderAsZip(directory);
    }

    public List<string> GetAllDirectory(string directory)
    {
        return _storageBroker.GetAllDirectory(directory);
    }

    public void GetTextOfTxtfile(string file)
    {
        _storageBroker.GetTextOfTxtFile(file);
    }

    public void UpdateTextOfTextFile(string file, string oldText, string newText)
    {
        _storageBroker.UpdateTextOfTextFile(file, oldText, newText);
    }

    public void UploadFile(string filePath, Stream stream)
    {
        _storageBroker.UploadFile(filePath, stream);
    }
}
