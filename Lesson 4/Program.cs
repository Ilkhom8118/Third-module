namespace Lesson_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\zeeyoD\Downloads\Telegram Desktop";
            var folderPath = new List<string>();
            FileMp4(filePath, folderPath);
        }
        public static List<int> GetNumberOfDigitsEachLine(string filePath)
        {
            var numberList = new List<int>();
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                var line = string.Empty;
                while (true)
                {
                    line = streamReader.ReadLine();
                    if (line == null) break;
                    var count = line.Count(ch => char.IsDigit(ch));
                    numberList.Add(count);
                }
            }
            return numberList;
        }
        public static void FillAllFiles(string folderPath, List<string> files)
        {
            var filesInPath = Directory.GetFiles(folderPath);
            var folderInPath = Directory.GetDirectories(folderPath);
            files.AddRange(filesInPath);
            foreach (var folder in folderInPath)
            {
                FillAllFiles(folder, files);
            }
        }
        public static void StreamReaderInformation(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                string line = string.Empty;
                while (true)
                {
                    line = streamReader.ReadLine();
                    if (line == null)
                    {
                        Console.WriteLine("tugadi");
                        break;
                    }
                    Console.WriteLine(line);
                }
            }
        }
        public static List<int> GetNumber(string filePath)
        {
            var listNumber = new List<int>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string list = string.Empty;
                while (true)
                {
                    list = sr.ReadLine();
                    if (list == null) break;
                    var count = list.Count(ch => char.IsDigit(ch));
                    listNumber.Add(count);
                }
            }
            return listNumber;
        }

        public static void FileReadWrite(string filePath)
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), "example.csv");
            FileInfo fileInfor = new FileInfo(file);
            if (!File.Exists(file))
            {
                fileInfor.Create();
            }
            using (var fileInfo = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var savingFile = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    fileInfo.CopyTo(savingFile);
                }
            }
        }

        //==================================
        public static void FileMp4(string file, List<string> files)
        {
            foreach (var filee in Directory.EnumerateFiles(file))
            {

                var exs = Path.GetExtension(filee);
                if (exs == ".mp4")
                {
                    files.Add(file);
                    //Folder(exs);
                }
                if (exs == ".mp3")
                {
                    files.Add(filee);
                    Folder(exs, filee);


                }
                if (exs == ".pdf")
                {
                    files.Add(filee);
                    Folder(exs, filee);
                }
            }
            var allFolders = Directory.EnumerateDirectories(file);
            foreach (var filee in allFolders)
            {
                FileMp4(filee, files);
            }

        }
        public static void Folder(string exs, string filePath)
        {
            var exs1 = string.Empty;
            if (!string.IsNullOrWhiteSpace(exs))
            {
                exs1 = exs.Substring(1).ToUpper();
                var folderPathName = Path.Combine(Directory.GetCurrentDirectory(), exs1);
                if (!Directory.Exists(folderPathName))
                {
                    Directory.CreateDirectory(folderPathName);
                }
            }
            var file = Path.Combine(Directory.GetCurrentDirectory(), exs1, exs);
            //var fileee = Directory.EnumerateDirectories(filePath);
            foreach (var fileinfo in filePath)
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream fileDestination = new FileStream(file, FileMode.Create, FileAccess.Write))
                    {
                        fileStream.CopyTo(fileDestination);
                    }
                }
            }
            Console.WriteLine(filePath);
        }
    }
}

