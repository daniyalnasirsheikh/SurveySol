using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SV.Models.Entities
{
    public partial class Survey
    {
        [NotMapped]
        public string DetailedName { get; set; }
    }
}
