namespace FileAndFolder.StorageBroker.Service;

public interface IStorageBroker
{
    void UploadFile(string filePath, Stream stream);
    void CreateDirectory(string directory);
}