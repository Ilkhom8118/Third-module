﻿using FileAndFolder.Service.Service;
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
        public async Task CreateDirectory(string directory)
        {
            await _storageBrokerService.CreateDirectory(directory);
        }
        [HttpDelete("deleteFile")]
        public async Task DeleteFile(string filePath)
        {
            await _storageBrokerService.DeleteFile(filePath);
        }
        [HttpGet("getAll")]
        public async Task<List<string>> GetAll(string? path)
        {
            path = path ?? string.Empty;
            return await _storageBrokerService.GetAll(path);
        }
        [HttpGet("downloadFile")]
        public async Task<FileStreamResult> DownloadFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new Exception("Not found");
            }
            var fileName = Path.GetFileName(path);
            var stream = await _storageBrokerService.DownloadFile(path);
            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = fileName
            };
            return res;
        }
        [HttpGet("downloadFolderAsZip")]
        public async Task<FileStreamResult> DownloadDirectoryAsZip(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new Exception("Not found");
            }
            var namePath = Path.GetFileName(path);
            var stream = await _storageBrokerService.DownloadDirecotryAsZip(path);
            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = namePath + ".zip"
            };
            return res;
        }
    }
}
