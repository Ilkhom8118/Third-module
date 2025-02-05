using Microsoft.AspNetCore.Mvc;
using WebManagement.Service.Services;

namespace WebManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }
        [HttpPost("createDirectory")]
        public async Task CreateDirectory(string directory)
        {
            await _storageService.CreateDirectory(directory);
        }
        [HttpPost("uploadFile")]
        public async Task UploadFile(string directory, IFormFile file)
        {
            directory = directory ?? string.Empty;
            directory = Path.Combine(directory, file.FileName);
            using (var fs = file.OpenReadStream())
            {
                await _storageService.UploadFile(directory, fs);
            }
        }
        [HttpDelete("deleteFile")]
        public async Task DeleteFile(string file)
        {
            await _storageService.DeleteFile(file);
        }
        [HttpDelete("DeleteFolder")]
        public async Task DeleteDirectory(string directory)
        {
            await _storageService.DeleteDirectory(directory);
        }
        [HttpGet("getAll")]
        public async Task<List<string>> GetAll(string? directory)
        {
            directory = directory ?? string.Empty;
            return await _storageService.GetAllFilesAndDirectories(directory);
        }
        [HttpGet("downloadFile")]
        public async Task<FileStreamResult> DownloadFile(string? directory)
        {
            directory = directory ?? string.Empty;
            var fileName = Path.GetFileName(directory);
            var stream = await _storageService.DownloadFile(directory);
            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = fileName
            };
            return res;
        }
        [HttpGet("downloadFolderAsZip")]
        public async Task<FileStreamResult> DownloadDirectoryAsZip(string? directory)
        {
            directory = directory ?? string.Empty;
            var directoryName = Path.GetFileName(directory);
            var stream = await _storageService.DownloadDirecotyAsZip(directory);
            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = directoryName + ".zip"
            };
            return res;
        }
    }
}
