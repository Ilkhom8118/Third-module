namespace WebFileDirectory.StorageBroker.Service;

public interface IStorageBrokers
{
    Task DeleteFileAysnc(string filePath);
    Task CreateDirectoryAysnc(string directoryPath);
    Task<Stream> DownloadFileAysnc(string filePath);
    Task UploadFileAysnc(string filePath, Stream stream);
    Task<List<string>> GetAllAysnc(string directoryPath);
    Task<Stream> DownloadFolderAsZipAysnc(string directoryPath);
}

//CreateFolder
//UploadFile
//DeleteFile
//DownloadFile
//DownloadFolderAsZip
//GetAll