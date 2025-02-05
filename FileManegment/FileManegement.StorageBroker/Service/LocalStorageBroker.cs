using System.IO.Compression;

namespace FileManegement.StorageBroker.Service
{
    public class LocalStorageBroker : IStorageBroker
    {
        private string _dataPath;
        public LocalStorageBroker()
        {
            _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(_dataPath))
            {
                Directory.CreateDirectory(_dataPath);
            }
        }
        public async Task CreateDirectory(string directroy)
        {
            directroy = Path.Combine(_dataPath, directroy);
            if (Directory.Exists(directroy))
            {
                throw new Exception("Folder has already not created");
            }
            var parent = Directory.GetParent(directroy);
            if (!Directory.Exists(parent?.FullName))
            {
                throw new Exception("Parent folder path not found");
            }
            Directory.CreateDirectory(directroy);
        }

        public async Task DeleteFile(string filePath)
        {
            filePath = Path.Combine(_dataPath, filePath);
            if (!File.Exists(filePath))
            {
                throw new Exception("Not Found");
            }
            File.Delete(filePath);
        }

        public async Task<Stream> DownloadFile(string filePath)
        {
            filePath = Path.Combine(_dataPath, filePath);
            if (!File.Exists(filePath))
            {
                throw new Exception("Not found");
            }
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return stream;
        }

        public async Task<Stream> DownloadFolderAsZip(string directoryPath)
        {
            directoryPath = Path.Combine(_dataPath, directoryPath);
            if (!Directory.Exists(directoryPath))
            {
                throw new Exception("Not found");
            }
            var zip = directoryPath + ".zip";
            ZipFile.CreateFromDirectory(directoryPath, zip);
            var stream = new FileStream(zip, FileMode.Open, FileAccess.Read);
            return stream;
        }

        public async Task<List<string>> GetAllDirectory(string directory)
        {
            directory = Path.Combine(_dataPath, directory);
            var parent = Directory.GetParent(directory);
            if (!Directory.Exists(parent?.FullName))
            {
                throw new Exception("Parent folder path not found");
            }
            var all = Directory.GetFileSystemEntries(directory).ToList();
            all = all.Select(d => d.Remove(0, directory.Length + 1)).ToList();
            return all;
        }

        public async Task UploadFile(Stream stream, string path)
        {
            path = Path.Combine(_dataPath, path);
            var parentPath = Directory.GetParent(path);
            if (!Directory.Exists(parentPath?.FullName))
            {
                throw new Exception("Not found");
            }
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fs);
            }
        }
    }
}
