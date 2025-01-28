namespace WebbFilesAndFolders.Service.Service;

public interface IStorageBrokerService
{
    Task CreateFolderAysnc(string directoryPath);
    Task DeleteFileAysnc(string filePath);
    Task<Stream> DownloadFileAysnc(string filePath);
}