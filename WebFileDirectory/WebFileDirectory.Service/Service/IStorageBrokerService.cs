namespace WebFileDirectory.Service.Service;

public interface IStorageBrokerService
{
    Task DeleteFileAysnc(string filePath);
    Task CreateDirectoryAysnc(string directoryPath);
    Task<Stream> DownloadFileAysnc(string filePath);
    Task UploadFileAysnc(string filePath, Stream stream);
    Task<List<string>> GetAllAysnc(string directoryPath);
    Task<Stream> DownloadFolderAsZipAysnc(string directoryPath);
}