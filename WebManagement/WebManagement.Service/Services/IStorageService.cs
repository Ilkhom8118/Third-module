namespace WebManagement.Service.Services;

public interface IStorageService
{
    Task DeleteFile(string file);
    Task DeleteDirectory(string directory);
    Task CreateDirectory(string directoryPath);
    Task<Stream> DownloadFile(string directory);
    Task UploadFile(string filePath, Stream stream);
    Task<Stream> DownloadDirecotyAsZip(string directory);
    Task<List<string>> GetAllFilesAndDirectories(string directory);
}