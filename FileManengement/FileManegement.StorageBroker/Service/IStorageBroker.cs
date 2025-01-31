namespace FileManegement.StorageBroker.Service;

public interface IStorageBroker
{
    Task CreateDirectory(string directoryPath);
    Task DeleteFile(string filePath);
}