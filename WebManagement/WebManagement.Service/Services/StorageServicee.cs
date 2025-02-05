
using WebManagement.StorageBroker.Services;

namespace WebManagement.Service.Services
{
    public class StorageServicee : IStorageService
    {
        private readonly IStorageBrokerService _storageBrokerService;

        public StorageServicee(IStorageBrokerService storageBrokerService)
        {
            _storageBrokerService = storageBrokerService;
        }

        public async Task CreateDirectory(string directoryPath)
        {
            await _storageBrokerService.CreateDirectory(directoryPath);
        }

        public async Task DeleteDirectory(string directory)
        {
            await _storageBrokerService.DeleteDirectory(directory);
        }

        public async Task DeleteFile(string file)
        {
            await _storageBrokerService.DeleteFile(file);
        }

        public async Task<Stream> DownloadDirecotyAsZip(string directory)
        {
            return await _storageBrokerService.DownloadDirecotyAsZip(directory);
        }

        public async Task<Stream> DownloadFile(string directory)
        {
            return await _storageBrokerService.DownloadFile(directory);
        }

        public async Task<List<string>> GetAllFilesAndDirectories(string directory)
        {
            return await _storageBrokerService.GetAllFilesAndDirectories(directory);
        }

        public async Task UploadFile(string filePath, Stream stream)
        {
            await _storageBrokerService.UploadFile(filePath, stream);
        }
    }
}
