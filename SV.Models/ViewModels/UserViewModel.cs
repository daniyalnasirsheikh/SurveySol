using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SV.Models.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<string>? Departments { get; set; }
        public string CreatedOn { get; set; }
        public string LastLoggedIn { get; set; }
    }
}
