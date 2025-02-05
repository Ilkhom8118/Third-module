namespace FileManegement.StorageBroker.Service;

public interface IStorageBroker
{
    Task DeleteFile(string filePath);
    Task CreateDirectory(string directroy);
    Task UploadFile(Stream stream, string path);
    Task<Stream> DownloadFile(string filePath);
    Task<Stream> DownloadFolderAsZip(string directoryPath);
    Task<List<string>> GetAllDirectory(string directory);
}

//CreateFolder
//UploadFile
//DeleteFile
//DownloadFile
//DownloadFolderAsZip
//GetAll