namespace Lesson_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\zeeyoD\Desktop\.NET\Third-module\Lesson 4\testTXT.txt";

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
    }
}
