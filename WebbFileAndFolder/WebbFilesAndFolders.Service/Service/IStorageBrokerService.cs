namespace WebbFilesAndFolders.Service.Service;

public interface IStorageBrokerService
{
    Task CreateFolderAysnc(string directoryPath);
    Task DeleteFileAysnc(string filePath);
    Task<Stream> DownloadFileAysnc(string filePath);
    Task UploadFileAsync(string filePath, Stream stream);
    Task<List<string>> GetAllAsync(string directoryPath);
    Task<Stream> DownloadFolderAsZipAsync(string directoryPath);
}