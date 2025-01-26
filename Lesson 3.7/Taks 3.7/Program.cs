namespace Taks_3._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string directoryPath = @"C:\Users\zeeyoD\Desktop\.NET\Third-module\Lesson 3.7\Lesson 3.7";
            var filesPath = Directory.GetFiles(directoryPath).ToList();
            foreach (var file in filesPath)
            {
                var thread = new Thread(() => FilesCount(file));
                thread.Start();
            }
        }
        public static Object _lock = new Object();
        public static void FilesCount(string filesPath)
        {
            lock (_lock)
            {
                using (StreamReader sr = new StreamReader(filesPath))
                {
                    var lines = sr.ReadToEnd();
                    var count = lines.Count(ch => Char.IsDigit(ch));
                    Console.WriteLine($" Count : {count}");
                    Console.WriteLine($" Path : {filesPath}");
                    Console.WriteLine($"Thread Id : {Thread.CurrentThread.ManagedThreadId}");
                }
            }
        }
    }
}
