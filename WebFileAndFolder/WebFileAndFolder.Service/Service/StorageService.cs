
using WebFileAndFolder.StorageBroker.Service;

namespace WebFileAndFolder.Service.Service;

public class StorageService : IStorageService
{
    private readonly IStorageBrokerService _storageBrokerService;

    public StorageService(IStorageBrokerService storageBrokerService)
    {
        _storageBrokerService = storageBrokerService;
    }

    public void CreateDirectory(string directory)
    {
        _storageBrokerService.CreateDirectory(directory);
    }

    public Stream DownloadFile(string filePaht)
    {
        return _storageBrokerService.DownloadFile(filePaht);
    }

    public Stream DownloadFolderAsZip(string directoryPath)
    {
        return _storageBrokerService.DownloadFolderAsZip(directoryPath);
    }

    public List<string> GetAllFilesAndDirectories(string directory)
    {
        var res = _storageBrokerService.GetAllFilesAndDirectories(directory);
        return res;
    }

    public void UploadFile(string filePath, Stream stream)
    {
        var parentPath = Directory.GetParent(filePath);
        _storageBrokerService.UploadFile(filePath, stream);
    }
}
