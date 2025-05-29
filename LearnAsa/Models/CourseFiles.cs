namespace LearnAsa.Models
{
    public class CourseFiles
    {
       
            public string id { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            public IFormFile videos { get; set; }
    }
}
