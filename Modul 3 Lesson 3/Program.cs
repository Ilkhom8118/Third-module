namespace Modul_3_Lesson_3
{
    internal class Program
    {
        static void Main(string[] args)
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
    }
}
