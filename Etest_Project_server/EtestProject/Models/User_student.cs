namespace EtestProject.Models
{
    public class User_student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public List<Grade> grades { get; set; }
        public void addGrade(Grade g) { grades.Add(g); }

        public User_student(string name, string pass)
        {
            grades = new List<Grade>();
            Name = name;
            Password = pass;
            Id = 0;
        }
        public User_student()
        {
            grades = new List<Grade>();
            Name = "";
            Password = "";
            Id = 0;
        }

    }
}
