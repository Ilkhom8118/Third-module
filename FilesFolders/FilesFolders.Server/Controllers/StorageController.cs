using FilesFodersStorageBroker.Service;
using Microsoft.AspNetCore.Mvc;

namespace FilesFolders.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageBroker _storageBroker;

        public StorageController(IStorageBroker storageBroker)
        {
            _storageBroker = storageBroker;
        }

        [HttpPost("createFolder")]
        public void CreateFolder(string folderPath)
        {
            _storageBroker.CreateFolder(folderPath);
        }
        [HttpPost("uploadFile")]
        public void UploadFile(IFormFile file, string directory)
        {
            directory = directory ?? string.Empty;
            directory = Path.Combine(directory, file.FileName);
            using (Stream stm = file.OpenReadStream())
            {
                _storageBroker.UploadFile(directory, stm);
            }
        }
        [HttpGet("downloadFile")]
        public FileStreamResult DownloadFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new Exception("File Empty");
            }
            var fileName = Path.GetFileName(filePath);

            var stream = _storageBroker.DownloadFile(filePath);

            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = fileName
            };
            return res;
        }
        [HttpDelete("deleteFile")]
        public void Delete(string filePath)
        {
            _storageBroker.DeleteFile(filePath);
        }
        [HttpGet("getAll")]
        public List<string> GetAllDirectory(string? directory)
        {
            directory = directory ?? string.Empty;
            return _storageBroker.GetAllDirectory(directory);
        }
        [HttpGet("downloadFolderAndAsZip")]
        public FileStreamResult DownloadFolderAsZip(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                throw new Exception("Not Found");
            }
            var directoryName = Path.GetFileName(directory);
            var stream = _storageBroker.DownloadFolderAsZip(directory);
            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = directory + ".zip"
            };
            return res;
        }

    }
}
