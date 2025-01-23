using Microsoft.AspNetCore.Mvc;
using WebFileAndFolder.Service.Service;

namespace WebFileAndFolder.Server.Controllers;

[Route("api/storage")]
[ApiController]
public class StorageController : ControllerBase
{
    private readonly IStorageService _storageService;

    public StorageController(IStorageService storageService)
    {
        _storageService = storageService;
    }
    [HttpPost("uploadFiles")]
    public void UploadFile(List<IFormFile> formFiles, string? directory)
    {
        directory = directory ?? string.Empty;
        foreach (var file in formFiles)
        {
            directory = Path.Combine(directory, file.FileName);
            using (Stream stream = file.OpenReadStream())
            {
                _storageService.UploadFile(directory, stream);
            }
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
