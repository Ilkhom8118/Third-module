using WebManagementStorageBroker.Services;

namespace WebManagementService.Services;

public class StorageService : IStorageService
{
    private readonly IStorageBrokerService _storageBrokerService;

    public StorageService(IStorageBrokerService storageBrokerService)
    {
        _storageBrokerService = storageBrokerService;
    }

    public void CreateDirectory(string directoryPath)
    {
        _storageBrokerService.CreateDirectory(directoryPath);
    }

    public List<string> GetAllFilesAndDirectories(string directory)
    {
        var filesAndDirectoreis = _storageBrokerService.GetAllFilesAndDirectories(directory);
        return filesAndDirectoreis;
    }

    public void UploadFile(string filePath, Stream stream)
    {
        var parentPath = Directory.GetParent(filePath);
        _storageBrokerService.UploadFile(filePath, stream);
    }

}
