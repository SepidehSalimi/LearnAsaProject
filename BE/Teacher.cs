namespace BE
{
    public class Teacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string? pic { get; set; }
        public string email { get; set; }
        public List<courseteacher> courseteachers { get; set; }
    }
}
