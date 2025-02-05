
using FileAndFolder.StorageBroker.Service;

namespace FileAndFolder.Service.Service;

public class StorageBrokerService : IStorageBrokerService
{
    private readonly IStorageBroker _storageBroker;

    public StorageBrokerService(IStorageBroker storageBroker)
    {
        _storageBroker = storageBroker;
    }

    public async Task CreateDirectory(string directory)
    {
        await _storageBroker.CreateDirectory(directory);
    }

    public async Task DeleteFile(string filePath)
    {
        await _storageBroker.DeleteFile(filePath);
    }

    public async Task<Stream> DownloadDirecotryAsZip(string direcotry)
    {
        return await _storageBroker.DownloadDirecotryAsZip(direcotry);
    }

    public async Task<Stream> DownloadFile(string filePath)
    {
        return await _storageBroker.DownloadFile(filePath);
    }

    public async Task<List<string>> GetAll(string path)
    {
        return await _storageBroker.GetAll(path);
    }

    public async Task UploadFile(string filePath, Stream stream)
    {
        await _storageBroker.UploadFile(filePath, stream);
    }
}
