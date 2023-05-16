namespace EtestProject.Models
{
    public class User_teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public List<Test> tests { get; set; }
        public void addTest(Test t) { tests.Add(t); }

        public User_teacher(string name, string pass)
        {
            tests = new List<Test>();
            Name = name;
            Password = pass;
            Id = 0;
        }

        public User_teacher()
        {
            tests = new List<Test>();
            Name = "";
            Password = "";
            Id = 0;
        }
    }
}
