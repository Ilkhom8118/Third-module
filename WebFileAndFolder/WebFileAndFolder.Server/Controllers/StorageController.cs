using Microsoft.AspNetCore.Mvc;
using WebFileAndFolder.Service.Service;

namespace WebFileAndFolder.Server.Controllers
{
    [Route("api/storage")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }
        [HttpPost("uploadFile")]
        public void UploadFile(IFormFile formFile, string directory)
        {
            directory = Path.Combine(directory, formFile.FileName);
            using (Stream stream = formFile.OpenReadStream())
            {
                _storageService.UploadFile(directory, stream);
            }
        }
        [HttpPost("createFolder")]
        public void CreateFolder(string directory)
        {
            _storageService.CreateDirectory(directory);
        }
        [HttpGet("getAll")]
        public List<string> GetAll(string? directory)
        {
            directory = directory ?? string.Empty;
            return _storageService.GetAllFilesAndDirectories(directory);
        }
    }
}
