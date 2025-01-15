namespace Lesson3._3;

internal class Program
{
    static void Main(string[] args)
    {
        var test = Console.ReadLine();

        var list = Metod(test);
        foreach (var file in list)
        {
            Console.WriteLine(file);
        }
        Console.WriteLine(list.Count);
    }
    public static List<string> Metod(string path)
    {
        DirectoryInfo filePathInfo = new DirectoryInfo(path);
        var onlyFolders = new List<string>();
        var onlyFiles = new List<string>();
        foreach (var file in filePathInfo.EnumerateDirectories())
        {
            onlyFolders.Add(file.FullName);
        }
        foreach (var file in filePathInfo.EnumerateFiles())
        {
            onlyFiles.Add(file.FullName);
        }
        for (var i = 0; i < onlyFolders.Count; i++)
        {
            DirectoryInfo fileDirectory = new DirectoryInfo(onlyFolders[i]);
            foreach (var file in fileDirectory.EnumerateDirectories())
            {
                onlyFolders.Add(file.FullName);
            }
            foreach (var file in fileDirectory.EnumerateFiles())
            {
                onlyFiles.Add(file.FullName);
            }
            onlyFolders.Remove(onlyFolders[i]);
            i--;
        }

        return onlyFiles;
    }
}
