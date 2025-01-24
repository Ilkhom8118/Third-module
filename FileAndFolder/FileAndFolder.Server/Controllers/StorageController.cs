using FileAndFolder.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace FileAndFolder.Server.Controllers
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
        [HttpPost("uploadFile")]
        public void UploadFile(string? filePath, IFormFile file)
        {
            filePath = filePath ?? string.Empty;
            filePath = Path.Combine(filePath, file.FileName);
            using (var stream = file.OpenReadStream())
            {
                _storageBrokerService.UploadFile(filePath, stream);
            }
        }
        [HttpPost("createDirectory")]
        public void CreateDirectory(string directory)
        {
            _storageBrokerService.CreateDirectory(directory);
        }
    }
}
