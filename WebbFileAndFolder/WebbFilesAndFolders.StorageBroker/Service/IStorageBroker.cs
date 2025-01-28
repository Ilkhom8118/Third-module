namespace WebbFilesAndFolders.StorageBroker.Service;

public interface IStorageBroker
{
    Task CreateFolderAsync(string directoryPath);
    Task UploadFileAsync(string filePath, Stream stream);
    Task DeleteFileAsync(string filePath);
    Task<Stream> DownloadFileAsync(string directoryPath);
    Task<Stream> DownloadFolderAsZipAsync(string directoryPath);
    Task<List<string>> GetAllAsync(string directoryPath);

}
//CreateFolder
//UploadFile
//DeleteFile
//DownloadFile
//DownloadFolderAsZip
//GetAll