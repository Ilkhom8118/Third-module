
using FileAndFolder.StorageBroker.Service;

namespace FileAndFolder.Service.Service;

public class StorageBrokerService : IStorageBrokerService
{
    private readonly IStorageBroker _storageBroker;

    public StorageBrokerService(IStorageBroker storageBroker)
    {
        _storageBroker = storageBroker;
    }

    public void CreateDirectory(string directory)
    {
        _storageBroker.CreateDirectory(directory);
    }

    public void UploadFile(string filePath, Stream stream)
    {
        _storageBroker.UploadFile(filePath, stream);
    }
}
