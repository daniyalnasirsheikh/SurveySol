using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SV.Models.ViewModels
{
    public class DepartmentViewModel : BaseViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Department { get; set; }
    }
}
