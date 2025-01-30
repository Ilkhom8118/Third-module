namespace Lesson_3._9
{
    internal class Program
    {
        public delegate void Action<T>(ref T a, ref T b);
        static void Main(string[] args)
        {

            //Func<int, int, int, int> add = Add;
            //Func<int, int, int, int, int> multiply = Multiply;
            //Func<double, double, double> divide = Divide;
            //Func<int, int, (int, int)> sumAndProdeuct = SumAndProduct;
            //Func<int, bool> isEven = IsEven;
            //Func<string, string, string, string> concat = ConcatThree;
            //Func<string, (string, string)> getUpperAndLower = GetUpperAndLower;
            //Func<string, string, bool> containsSubstring = ContainsSubstring;
            //Func<string, string> reverseString = ReverseString;
            //Func<int[], int> getMax = GetMax;
            //Func<int[], int> getMin = GetMin;
            //Func<int[], int[]> getSort = GetSorted;
            //Func<int[], (int max, int min)> getMaxAndMin = GetMaxAndMin;
            //Func<int[], int, bool> containsElement = ContainsElement;
            //Func<int, int, int> getRandomNumber = GetRandomNumber;
            //Func<(int, int, int)> randomTriple = GetRandomTriple;
            //Func<string> getCurrentDateTime = GetCurrentDateTime;
            //Func<int, bool> isOdd = IsOdd;
            //Func<int, bool> isPrime = IsPrime;
            //Func<double, (double, double)> getCircleAreaAndCircumference = GetCircleAreaAndCircumference;
            //Func<int[], (int, double)> sumAndAverage = SumAndAverage;
            Action<int> swap = Swap;
            var x = 5;
            var y = 10;
            swap(ref x, ref y);
            Console.WriteLine($"X : {x}, Y : {y}");
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
        //===============================================================================================
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
    }
}
