namespace FileAndFolder.Service.Service;

public interface IStorageBrokerService
{
    void UploadFile(string filePath, Stream stream);
    void CreateDirectory(string directory);
}