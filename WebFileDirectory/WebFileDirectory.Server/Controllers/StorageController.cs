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
            directory = string.IsNullOrWhiteSpace(directory) ? "./" : directory;
            return await _storageBrokerService.GetAllAysnc(directory);
        }

        [HttpGet("downloadFile")]
        public async Task<FileStreamResult> DownloadFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new Exception("This not found");
            }
            var fileName = Path.GetFileName(filePath);
            var stream = await _storageBrokerService.DownloadFileAysnc(filePath);
            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = fileName
            };
            return res;
        }
        [HttpPost("uploadFile")]
        public async Task UploadFile(string? filePath, IFormFile file)
        {

            filePath = filePath ?? string.Empty;
            filePath = Path.Combine(filePath, file.FileName);
            using (Stream stm = file.OpenReadStream())
            {
                await _storageBrokerService.UploadFileAysnc(filePath, stm);
            }
        }
        [HttpGet("downloadFolderAsZipAysnc")]
        public async Task<FileStreamResult> DownloadFolderAsZip(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                throw new Exception("This not found");
            }
            var directoryName = Path.GetFileName(directoryPath);
            var stream = await _storageBrokerService.DownloadFolderAsZipAysnc(directoryPath);
            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = $"{directoryPath}.zip"
            };
            return res;
        }
    }
}
