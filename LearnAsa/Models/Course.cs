namespace LearnAsa.Models
{
    public class Course
    {
        
            public int id { get; set; }
            public string title { get; set; }
            public float? totaltime { get; set; }
            
            public string[] teachers { get; set; }
            public string descript { get; set; }
          
            public IFormFile videointro { get; set; }

            public float? price { get; set; }

        //public int teachersId { get; set; }




    }
}
