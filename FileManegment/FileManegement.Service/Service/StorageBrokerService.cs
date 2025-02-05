
using FileManegement.StorageBroker.Service;

namespace FileManegement.Service.Service;

public class StorageBrokerService : IStorageBrokerService
{
    private readonly IStorageBroker _storageBroker;

    public StorageBrokerService(IStorageBroker storageBroker)
    {
        _storageBroker = storageBroker;
    }

    public async Task CreateDirectory(string directroy)
    {
        await _storageBroker.CreateDirectory(directroy);
    }

    public async Task DeleteFile(string filePath)
    {
        await _storageBroker.DeleteFile(filePath);
    }

    public async Task<Stream> DownloadFile(string filePath)
    {
        return await _storageBroker.DownloadFile(filePath); ;
    }

    public async Task<Stream> DownloadFolderAsZip(string directoryPath)
    {
        return await _storageBroker.DownloadFolderAsZip(directoryPath);
    }

    public async Task<List<string>> GetAllDirectory(string directory)
    {
        return await _storageBroker.GetAllDirectory(directory);
    }

    public async Task UploadFile(Stream stream, string path)
    {
        await _storageBroker.UploadFile(stream, path);
    }
}
