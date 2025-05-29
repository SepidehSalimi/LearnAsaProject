using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace LearnAsa.Models
{
    public class Teacher
    {
        public int id { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string name { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string family { get; set; }
        public IFormFile pic { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [EmailAddress]
        public string email { get; set; }
     
        //public string picName { get; set; }
    }
}
