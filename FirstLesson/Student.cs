namespace FirstLesson
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Cash { get; set; }
        public Student()
        {

        }
        public Student(string fN, string lN, int age, double cash)
        {
            age = Age;
            fN = FirstName;
            lN = LastName;
            cash = Cash;
        }
    }

}

