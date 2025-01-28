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
    }
}
