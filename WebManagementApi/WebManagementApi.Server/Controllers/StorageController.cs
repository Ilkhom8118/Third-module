using Microsoft.AspNetCore.Mvc;
using WebManagementService.Services;

namespace WebManagementApi.Server.Controllers;

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
    public void UploadFile(IFormFile file, string directoryPath)
    {
        directoryPath = Path.Combine(directoryPath, file.FileName);
        using (Stream stream = file.OpenReadStream())
        {
            _storageService.UploadFile(directoryPath, stream);
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
    [HttpGet("downloadFile")]
    public IActionResult DownloadFile(string path)
    {
        throw new NotImplementedException();
    }
}
