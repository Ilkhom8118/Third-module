namespace WebFileAndFolder.Service.Service;

public interface IStorageService
{
    void UploadFile(string filePath, Stream stream);
    void CreateDirectory(string directory);
    List<string> GetAllFilesAndDirectories(string directory);
    Stream DownloadFile(string filePaht);
    Stream DownloadFolderAsZip(string directoryPath);
}