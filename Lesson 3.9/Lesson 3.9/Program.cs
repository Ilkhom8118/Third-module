namespace Lesson_3._9
{
    internal class Program
    {
        public delegate void Action<T>(ref T a, ref T b);
        static void Main(string[] args)
        {

            Func<int, int, int, int> add = Add;
            Func<int, int, int, int, int> multiply = Multiply;
            Func<double, double, double> divide = Divide;
            Func<int, int, (int, int)> sumAndProdeuct = SumAndProduct;
            Func<int, bool> isEven = IsEven;
            Func<string, string, string, string> concat = ConcatThree;
            Func<string, (string, string)> getUpperAndLower = GetUpperAndLower;
            Func<string, string, bool> containsSubstring = ContainsSubstring;
            Func<string, string> reverseString = ReverseString;
            Func<int[], int> getMax = GetMax;
            Func<int[], int> getMin = GetMin;
            Func<int[], int[]> getSort = GetSorted;
            Func<int[], (int max, int min)> getMaxAndMin = GetMaxAndMin;
            Func<int[], int, bool> containsElement = ContainsElement;
            Func<int, int, int> getRandomNumber = GetRandomNumber;
            Func<(int, int, int)> randomTriple = GetRandomTriple;
            Func<string> getCurrentDateTime = GetCurrentDateTime;
            Func<int, bool> isOdd = IsOdd;
            Func<int, bool> isPrime = IsPrime;
            Func<double, (double, double)> getCircleAreaAndCircumference = GetCircleAreaAndCircumference;
            Func<int[], (int, double)> sumAndAverage = SumAndAverage;
            Action<int> swap = Swap;
            System.Action<string> printMessage = PrintMessage;
            System.Action<int[]> printArray = PrintArray;
            Func<double, string, string> formatCurrency = FormatCurrency;
            Func<double, double, double> calculateDiscount = CalculateDiscount;
            Predicate<string> isPalindrome = IsPalindrome;
            Func<string, int> countWords = CountWords;
            Func<string, (string, string)> getFirstAndLastWord = GetFirstAndLastWord;
            Func<List<int>, List<int>> filterEvenNumbers = FilterEvenNumbers;
            Func<List<string>, List<string>> toUpperCaseList = ToUpperCaseList;
            Func<List<int>, List<int>> removeDuplicates = RemoveDuplicates;
            Func<List<int>, int[], List<int>> addToList = AddToList;
            Func<int[], int[]> filterPositiveNumbers = FilterPositiveNumbers;
            Func<string[], string[]> convertToLowerCase = ConvertToLowerCase;
            Func<string[], string[]> removeEmptyStrings = RemoveEmptyStrings;
            Func<int[], int[]> sortArrayDescending = SortArrayDescending;
            Func<List<int>, List<string>, Dictionary<int, string>> createDictionaryFromList = CreateDictionaryFromList;
            Func<List<string>, Dictionary<string, int>> countStringOccurrences = CountStringOccurrences;
            Func<Dictionary<int, string>, string, Dictionary<int, string>> filterDictionary = FilterDictionary;
            Func<List<string>, Dictionary<string, int>> getStringLengthDictionary = GetStringLengthDictionary;
            Func<List<int>, List<int>, List<int>> mergeLists = MergeLists;
            Func<int[], int[], int[]> mergeArrays = MergeArrays;
            Func<Dictionary<int, string>, Dictionary<int, string>, Dictionary<int, string>> mergeDictionaries = MergeDictionaries;
            Func<List<int>, List<int>> squareNumbers = SquareNumbers;
            Func<int[], int[]> getSquares = GetSquares;
            Func<List<string>, int, List<string>> filterByLength = FilterByLength;


        }

        public static int Add(int a, int b, int c) => a + b + c; // 
        public static int Multiply(int a, int b, int c, int d) => a * b * c * d;
        public static double Divide(double a, double b) => b != 0 ? a / b : double.NaN;
        public static (int sum, int product) SumAndProduct(int a, int b) => (a + b, a * b);
        public static bool IsEven(int num) => num % 2 == 0;

        // 🔥 String Manipulation
        public static string ConcatThree(string s1, string s2, string s3) => $"{s1}{s2}{s3}";
        public static (string upper, string lower) GetUpperAndLower(string str) => (str.ToUpper(), str.ToLower());
        public static bool ContainsSubstring(string main, string sub) => main.Contains(sub);
        public static string ReverseString(string str) => new string(str.Reverse().ToArray());

        // ✅ Array/List Functions
        public static int GetMax(params int[] numbers) => numbers.Max();
        public static int GetMin(params int[] numbers) => numbers.Min();
        public static int[] GetSorted(int[] numbers) => numbers.OrderBy(n => n).ToArray();
        public static (int max, int min) GetMaxAndMin(int[] numbers) => (numbers.Max(), numbers.Min());
        public static bool ContainsElement(int[] numbers, int value) => numbers.Contains(value);
        public static int GetRandomNumber(int min, int max) => new Random().Next(min, max);
        public static (int, int, int) GetRandomTriple() => (new Random().Next(1, 100), new Random().Next(1, 100), new Random().Next(1, 100));
        public static string GetCurrentDateTime() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // 💡 Boolean & Conditions
        public static bool IsOdd(int num) => num % 2 != 0;
        public static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            for (int i = 2; i * i <= num; i++)
                if (num % i == 0) return false;
            return true;
        }

        // 🚀 Tuple-Based Functions
        public static (double, double) GetCircleAreaAndCircumference(double radius)
        {
            double area = Math.PI * radius * radius;
            double circumference = 2 * Math.PI * radius;
            return (area, circumference);
        }

        public static (int sum, double average) SumAndAverage(int[] numbers)
        {
            int sum = numbers.Sum();
            double avg = numbers.Average();
            return (sum, avg);
        }
        public static void Swap(ref int a, ref int b) { int temp = a; a = b; b = temp; }
        public static void PrintMessage(string message) => Console.WriteLine(message);
        public static void PrintArray(int[] numbers) => Console.WriteLine(string.Join(", ", numbers));

        // 🛠 Advanced Functions
        public static string FormatCurrency(double amount, string currency) => $"{currency} {amount:N2}";
        public static double CalculateDiscount(double price, double discountPercent) => price - (price * (discountPercent / 100));
        public static bool IsPalindrome(string str) => str == new string(str.Reverse().ToArray());
        public static int CountWords(string sentence) => sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;

        public static (string first, string last) GetFirstAndLastWord(string sentence)
        {
            var words = sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return (words.First(), words.Last());
        }
        // 🚀 List Functions
        public static List<int> FilterEvenNumbers(List<int> numbers) => numbers.Where(n => n % 2 == 0).ToList();
        public static List<string> ToUpperCaseList(List<string> strings) => strings.Select(s => s.ToUpper()).ToList();
        public static List<int> RemoveDuplicates(List<int> numbers) => numbers.Distinct().ToList();
        public static List<int> AddToList(List<int> numbers, params int[] additionalNumbers)
        {
            numbers.AddRange(additionalNumbers);
            return numbers;
        }
        // 🔥 Array Functions
        public static int[] FilterPositiveNumbers(int[] numbers) => numbers.Where(n => n > 0).ToArray();
        public static string[] ConvertToLowerCase(string[] words) => words.Select(w => w.ToLower()).ToArray();
        public static string[] RemoveEmptyStrings(string[] strings) => strings.Where(s => !string.IsNullOrEmpty(s)).ToArray();
        public static int[] SortArrayDescending(int[] numbers) => numbers.OrderByDescending(n => n).ToArray();
        // ✅ Dictionary Functions
        public static Dictionary<int, string> CreateDictionaryFromList(List<int> keys, List<string> values)
        {
            if (keys.Count != values.Count)
                throw new ArgumentException("Keys and values lists must have the same length.");

            return keys.Zip(values, (key, value) => new KeyValuePair<int, string>(key, value))
                       .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public static Dictionary<string, int> CountStringOccurrences(List<string> strings)
        {
            return strings.GroupBy(s => s)
                          .ToDictionary(group => group.Key, group => group.Count());
        }

        public static Dictionary<int, string> FilterDictionary(Dictionary<int, string> dictionary, string filter)
        {
            return dictionary.Where(pair => pair.Value.Contains(filter))
                             .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public static Dictionary<string, int> GetStringLengthDictionary(List<string> strings)
        {
            return strings.ToDictionary(str => str, str => str.Length);
        }

        // 🔄 Collection Manipulations
        public static List<int> MergeLists(List<int> list1, List<int> list2)
        {
            return list1.Concat(list2).ToList();
        }

        public static int[] MergeArrays(int[] array1, int[] array2)
        {
            return array1.Concat(array2).ToArray();
        }

        public static Dictionary<int, string> MergeDictionaries(Dictionary<int, string> dict1, Dictionary<int, string> dict2)
        {
            var merged = new Dictionary<int, string>(dict1);
            foreach (var pair in dict2)
            {
                if (!merged.ContainsKey(pair.Key))
                {
                    merged.Add(pair.Key, pair.Value);
                }
            }
            return merged;
        }
        // 🛠 Collection Transformations
        //===============================================================================================
        public static List<int> SquareNumbers(List<int> numbers) => numbers.Select(n => n * n).ToList();
        public static int[] GetSquares(int[] numbers) => numbers.Select(n => n * n).ToArray();
        public static List<string> FilterByLength(List<string> strings, int length) => strings.Where(s => s.Length > length).ToList();
    }
}
