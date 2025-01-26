namespace FilesFodersStorageBroker.Service;

public interface IStorageBroker
{
    void CreateFolder(string filePath);
    void UploadFile(string filePath, Stream stream);
    void DeleteFile(string filePath);
    Stream DownloadFile(string filePath);
    Stream DownloadFolderAsZip(string directoryPath);
    List<string> GetAllDirectory(string directory);

}