namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LengthOfLongestSubstring("abcabcbb");
        }
        public static void LengthOfLongestSubstring(string s)
        {
            var list = new List<int>();
            var count = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == s[i + 1])
                {
                    count++;
                }
            }
            //var res = list.Max(n => n);
            //return res;
            Console.WriteLine(count);
        }
    }
}
