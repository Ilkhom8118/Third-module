using FileManegement.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace FileManegment.Controllers
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
        public async Task CreateDirectory(string directory)
        {
            await _storageBrokerService.CreateDirectory(directory);
        }

        [HttpGet("getAllFolder")]
        public async Task<List<string>> GetAllDirectory(string? path)
        {
            path = path ?? string.Empty;
            return await _storageBrokerService.GetAllDirectory(path);
        }
        [HttpDelete("deleteFile")]
        public async Task DeleteFile(string filePath)
        {
            await _storageBrokerService.DeleteFile(filePath);
        }
        [HttpPost("uploadFile")]
        public async Task UploadFile(string? directory, IFormFile file)
        {
            directory = directory ?? string.Empty;
            directory = Path.Combine(directory, file.FileName);
            using (Stream stream = file.OpenReadStream())
            {
                await _storageBrokerService.UploadFile(stream, directory);
            }
        }
        [HttpGet("downloadFile")]
        public async Task<FileStreamResult> DownloadFile(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new Exception("Not found");
            }
            var namePath = Path.GetFileName(path);
            var stream = await _storageBrokerService.DownloadFile(path);
            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = namePath
            };
            return res;
        }
        [HttpGet("downloadFolderAsZip")]
        public async Task<FileStreamResult> DownloadFolderAsZip(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                throw new Exception("Not found");
            }
            var nameDirectory = Path.GetFileName(directory);
            var stream = await _storageBrokerService.DownloadFolderAsZip(directory);
            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = nameDirectory + ".zip"
            };
            return res;
        }
    }
}
