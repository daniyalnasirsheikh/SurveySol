using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SV.Models.Entities
{
    public partial class UserLogs
    {
        [Key]
        public string UserID { get; set; }
        public string UserName { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastLoggedIn { get; set; }
    }
}
