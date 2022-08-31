using System;
using System.Collections.Generic;


#nullable disable

namespace SV.Models.Entities
{
    public partial class Departments
    {
        public Departments()
        {
           // Survey = new HashSet<Survey>();
        }

        public int ID { get; set; }
        public string Department { get; set; }
        //public virtual ICollection<Survey> Survey { get; set; }

    }
}
