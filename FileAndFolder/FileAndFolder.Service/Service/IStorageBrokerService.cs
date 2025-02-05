namespace FileAndFolder.Service.Service;

public interface IStorageBrokerService
{
    Task UploadFile(string filePath, Stream stream);
    Task CreateDirectory(string directory);
    Task DeleteFile(string filePath);
    Task<List<string>> GetAll(string path);
    Task<Stream> DownloadFile(string filePath);
    Task<Stream> DownloadDirecotryAsZip(string direcotry);
}