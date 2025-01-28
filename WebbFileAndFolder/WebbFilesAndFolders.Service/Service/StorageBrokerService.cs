
using WebbFilesAndFolders.StorageBroker.Service;

namespace WebbFilesAndFolders.Service.Service;

public class StorageBrokerService : IStorageBrokerService
{
    private readonly IStorageBroker _storageBroker;

    public StorageBrokerService(IStorageBroker storageBroker)
    {
        _storageBroker = storageBroker;
    }

    public async Task CreateFolderAysnc(string directoryPath)
    {
        await _storageBroker.CreateFolderAsync(directoryPath);
    }

    public async Task DeleteFileAysnc(string filePath)
    {
        await _storageBroker.DeleteFileAsync(filePath);
    }

    public async Task<Stream> DownloadFileAysnc(string filePath)
    {
        return await _storageBroker.DownloadFileAsync(filePath);
    }

    public async Task<Stream> DownloadFolderAsZipAsync(string directoryPath)
    {
        return await _storageBroker.DownloadFolderAsZipAsync(directoryPath);
    }

    public async Task<List<string>> GetAllAsync(string directoryPath)
    {
        return await _storageBroker.GetAllAsync(directoryPath);
    }

    public async Task UploadFileAsync(string filePath, Stream stream)
    {
        await _storageBroker.UploadFileAsync(filePath, stream);
    }
}
