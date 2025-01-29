
using WebFileDirectory.StorageBroker.Service;

namespace WebFileDirectory.Service.Service;

public class StorageBrokerService : IStorageBrokerService
{
    private readonly IStorageBrokers _storageBroker;

    public StorageBrokerService(IStorageBrokers storageBroker)
    {
        _storageBroker = storageBroker;
    }

    public async Task CreateDirectoryAysnc(string directoryPath)
    {
        await _storageBroker.CreateDirectoryAysnc(directoryPath);
    }

    public async Task DeleteFileAysnc(string filePath)
    {
        await _storageBroker.DeleteFileAysnc(filePath);
    }

    public async Task<Stream> DownloadFileAysnc(string filePath)
    {
        return await _storageBroker.DownloadFileAysnc(filePath);
    }

    public async Task<Stream> DownloadFolderAsZipAysnc(string directoryPath)
    {
        return await _storageBroker.DownloadFolderAsZipAysnc(directoryPath);
    }

    public async Task<List<string>> GetAllAysnc(string directoryPath)
    {
        return await _storageBroker.GetAllAysnc(directoryPath);
    }

    public async Task UploadFileAysnc(string filePath, Stream stream)
    {
        await _storageBroker.UploadFileAysnc(filePath, stream);
    }
}
