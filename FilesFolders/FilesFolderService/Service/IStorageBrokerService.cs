namespace FilesFolderService.Service;

public interface IStorageBrokerService
{
    void CreateFolder(string filePath);
    void UploadFile(string filePath, Stream stream);
    Stream DownloadFile(string filePath);
    void DeleteFile(string filePath);
    List<string> GetAllDirectory(string directory);
    Stream DownloadFolderAsZip(string directory);
}