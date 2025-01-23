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
        var mainPath = directory;
        foreach (var file in formFiles)
        {
            directory = Path.Combine(mainPath, file.FileName);
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
    public FileStreamResult DownloadFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new Exception("Error");
        }
        var fileName = Path.GetFileName(filePath);
        var stream = _storageService.DownloadFile(filePath);
        var res = new FileStreamResult(stream, "application/octet-stream")
        {
            FileDownloadName = fileName,
        };
        return res;
    }
    [HttpGet("downloadFolderAsZip")]
    public FileStreamResult DownloadFolderAsZip(string directoryPath)
    {
        if (string.IsNullOrEmpty(directoryPath))
        {
            throw new Exception("Error");
        }
        var fileName = Path.GetFileName(directoryPath);
        var stream = _storageService.DownloadFolderAsZip(directoryPath);
        var res = new FileStreamResult(stream, "application/octet-stream")
        {
            FileDownloadName = fileName + ".zip",
        };
        return res;
    }
    [HttpDelete("deleteFile")]
    public void DeleteFile(string filePath)
    {
        _storageService.DownloadFile(filePath);
    }

    [HttpDelete("deleteDirectory")]
    public void DeleteDirectory(string directoryPath)
    {
        _storageService.DownloadFile(directoryPath );
    }
}
