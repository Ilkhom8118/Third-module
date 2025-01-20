namespace WebManagementService.Services;

public interface IStorageService
{
    void UploadFile(string filePath, Stream stream);
    void CreateDirectory(string directoryPath);
    List<string> GetAllFilesAndDirectories(string directory);
}
