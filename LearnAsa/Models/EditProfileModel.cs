﻿using System.ComponentModel.DataAnnotations;

namespace LearnAsa.Models
{
    public class EditProfileModel
    {
        [Required]
        public string Username { get; set; }
        [Required , EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
       
        
    }
}
