using Microsoft.AspNetCore.Mvc;
using WebFileDirectory.Service.Service;

namespace WebFileDirectory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageBrokerService _storageBrokerService;

        public StorageController(IStorageBrokerService storageBrokerService)
        {
            _storageBrokerService = storageBrokerService;
        }

        [HttpPost("createFolder")]
        public async Task CreateDirectory(string directoryPath)
        {
            await _storageBrokerService.CreateDirectoryAysnc(directoryPath);
        }
        [HttpDelete("deleteFile")]
        public async Task DeleteFile(string filePath)
        {
            await _storageBrokerService.DeleteFileAysnc(filePath);
        }
        [HttpGet("getAllFolder")]
        public async Task<List<string>> GetAllFolder(string? directory)
        {
            directory = directory ?? string.Empty;
            return await _storageBrokerService.GetAllAysnc(directory);
        }
    }
}
