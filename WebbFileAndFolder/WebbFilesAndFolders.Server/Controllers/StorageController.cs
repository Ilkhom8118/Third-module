using Microsoft.AspNetCore.Mvc;
using WebbFilesAndFolders.Service.Service;

namespace WebbFilesAndFolders.Server.Controllers
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
        public async Task CreateFolder(string directoryPath)
        {
            await _storageBrokerService.CreateFolderAysnc(directoryPath);
        }


        [HttpDelete("deleteFile")]
        public async Task DeleteFile(string filePath)
        {
            await _storageBrokerService.DeleteFileAysnc(filePath);
        }


        [HttpGet("downloadFile")]
        public async Task<FileStreamResult> DownloadFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new Exception("Not file");
            }
            var fileName = Path.GetFileName(filePath);
            var stream = await _storageBrokerService.DownloadFileAysnc(filePath);
            var res = new FileStreamResult(stream, "applacation/octet-stream")
            {
                FileDownloadName = fileName,
            };
            return res;
        }


        [HttpPost("uploadFile")]
        public async Task UploadFile(IFormFile file, string? filePath)
        {
            filePath = filePath ?? string.Empty;
            filePath = Path.Combine(filePath, file.FileName);
            using (Stream stm = file.OpenReadStream())
            {
                await _storageBrokerService.UploadFileAsync(filePath, stm);
            }
        }


        [HttpGet("getAllFolder/{directoryPath}")]
        public async Task<List<string>> GetAllAsync(string directoryPath)
        {
            directoryPath = directoryPath ?? string.Empty;
            return await _storageBrokerService.GetAllAsync(directoryPath);
        }


        [HttpGet("downloadFolderAsZipAsync")]
        public async Task<FileStreamResult> DownloadFolderAsZipAsync(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                throw new Exception("Not Found");
            }
            var directoryName = Path.GetFileName(directoryPath);
            var stream = await _storageBrokerService.DownloadFolderAsZipAsync(directoryPath);
            var res = new FileStreamResult(stream, "applacation/octet-stream")
            {
                FileDownloadName = directoryName,
            };
            return res;

        }
    }
}
