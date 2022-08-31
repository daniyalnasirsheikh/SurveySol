using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SV.Models.Entities
{
    public partial class UserDepartments
    {
        [Key]
        public string UserID { get; set; }
        //public string UserName { get; set; }
        public string? DepartmentID { get; set; }
    }
}
