
using WebManagement.StorageBroker.Services;

namespace WebManagement.Service.Services
{
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
            ValidateDirectory(directory);
            var filesAndDirectoreis = _storageBrokerService.GetAllFilesAndDirectories(directory);
            return filesAndDirectoreis;
        }

        public void UploadFile(string filePath, Stream stream)
        {
            var parentPath = Directory.GetParent(filePath);
            ValidateDirectory(parentPath.FullName);
            _storageBrokerService.UploadFile(filePath, stream);
        }
        private void ValidateDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                throw new Exception("Folder has already created");
            }
            var parentPath = Directory.GetParent(directoryPath);
            if (!Directory.Exists(parentPath.FullName))
            {
                throw new Exception("Parent folder path not found");
            }
        }
    }
}
