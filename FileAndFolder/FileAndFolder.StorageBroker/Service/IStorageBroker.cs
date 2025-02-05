namespace FileAndFolder.StorageBroker.Service;

public interface IStorageBroker
{
    Task UploadFile(string filePath, Stream stream);
    Task CreateDirectory(string directory);
    Task DeleteFile(string filePath);
    Task<List<string>> GetAll(string path);
    Task<Stream> DownloadFile(string filePath);
    Task<Stream> DownloadDirecotryAsZip(string direcotry);
    Task GetTextOfTxtFile(string filePath, string textToUpdate);
    Task UpdateTextOfTxtFile(string filePath, string newFile, string info);
}