namespace Modul_3_Lesson_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\Users\zeeyoD\Desktop\.NET\Third-module\Modul 3 Lesson 3\test1.mp4";
            CopyFileAtOnce(filePath, "Doston");
        }
        public static void CopyFileFileWithChunks(string filePath, string newFileName)
        {
            var extension = Path.GetExtension(filePath);
            var distention = Path.Combine(Directory.GetCurrentDirectory(), filePath + newFileName);
            var fileInfo = new FileInfo(filePath);

            var fileLength = fileInfo.Length;

            var bytes = 1024 * 20;
            byte[] buffer = new byte[bytes];
            int bytesRead;

            var bytesPrecent = bytes * 100d / fileLength;

            var precent = bytesPrecent;

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream distenationStrem = new FileStream(distention, FileMode.Create, FileAccess.Write))
                {
                    while (true)
                    {
                        Console.WriteLine($"{(int)precent} %");
                        precent += bytesPrecent;
                        bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                        if (bytesRead <= 0) break;
                        distenationStrem.Write(buffer, 0, bytesRead);

                    }
                }
            }
        }
        public static void CopyFileAtOnce(string filePath, string newFileName)
        {
            var extension = Path.GetExtension(filePath);
            var destinationFile = Path.Combine(Directory.GetCurrentDirectory(), newFileName + extension);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream distinationStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
                {
                    fileStream.CopyTo(distinationStream);
                }
            }

        }
        public static void FuncFileInfo()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "text.txt");
            var qovunfilePath = Path.Combine(Directory.GetCurrentDirectory(), "qovun.txt");
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
            {
                fileInfo.Create().Close();
            }

            //var streamWriter = fileInfo.AppendText();
            //streamWriter.Write("Salom");
            //streamWriter.Write("Hello");
            //streamWriter.Write("Hi");
            //streamWriter.Write("Privet");
            //streamWriter.Close();
            //fileInfo.OpenWrite();

            fileInfo.Replace(qovunfilePath, null);

            Console.WriteLine(fileInfo.CreationTime);
            Console.WriteLine(fileInfo.CreationTimeUtc);
            Console.WriteLine(fileInfo.FullName);
            Console.WriteLine(fileInfo.Directory);
            Console.WriteLine(fileInfo.Length);
            Console.WriteLine(fileInfo.LastWriteTime);
            Console.WriteLine(fileInfo.LastAccessTime);
        }
        public static void FuncFolderInfo()
        {
            string directory = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            Console.WriteLine(Directory.GetCreationTime(directory));

            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            //Console.WriteLine(directoryInfo.FullName);
            //Console.WriteLine(directoryInfo.CreationTime);
            //Console.WriteLine(directoryInfo.Parent);
            //Console.WriteLine(directoryInfo.LinkTarget);
            //Console.WriteLine(directoryInfo.Attributes);
            //Console.WriteLine(directoryInfo.Root);
            //Console.WriteLine(directoryInfo.LastAccessTime);
            //Console.WriteLine(directoryInfo.LastWriteTimeUtc);

            var res1 = directoryInfo.EnumerateFileSystemInfos();
            var res2 = directoryInfo.EnumerateFiles();
            Console.WriteLine(directoryInfo.Equals(res1));
        }
        public static void InformationPath()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "qovun.txt");
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "data");

            Console.WriteLine("File " + Path.GetExtension(filePath));
            Console.WriteLine("Folder " + Path.GetExtension(folderPath));

            var fileInfo = new FileInfo(filePath);
            var fileFullName = fileInfo.FullName;
            var fileExtension = fileInfo.Extension;
            //fileFullName = fileFullName.Remove(fileFullName.Length - fileExtension.Length);
            fileFullName = fileFullName.Replace(fileExtension, ".json");

            if (!File.Exists(fileFullName))
            {
                var res = File.ReadAllLines(filePath);
                File.WriteAllLines(fileFullName, res);
            }
            
        }
    }
}
