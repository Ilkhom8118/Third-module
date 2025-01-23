namespace WebFileAndFolder.StorageBroker.Service;

public interface IStorageBrokerService
{
    void UploadFile(string filePath, Stream stream);
    void CreateDirectory(string directory);
    List<string> GetAllFilesAndDirectories(string directory);
    Stream DownloadFile(string filePath);
    Stream DownloadFolderAsZip(string directoryPath);
    void DeleteFile(string filePath);
    void DeleteDirectory(string directoryPath);
}
