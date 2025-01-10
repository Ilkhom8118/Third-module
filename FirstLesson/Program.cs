namespace FirstLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> student = new List<Student>();
            Student student1 = new Student("Eldor", "Yo'ldoshev", 8, 2000);
            Student student2 = new Student("Doston", "Bunyodov", 15, 5000);
            Student student3 = new Student("Shoxjahon", "Bozorboyev", 12, 7000);
            Student student4 = new Student("Doston", "Sodiqov", 28, 9000);

            student.Add(student1);
            student.Add(student2);
            student.Add(student3);
            student.Add(student4);
            var s = student.OrderBy(st => st.Age);
            foreach (var number in s)
            {
                Console.WriteLine(number.Age);
            }
        }
    }
}
