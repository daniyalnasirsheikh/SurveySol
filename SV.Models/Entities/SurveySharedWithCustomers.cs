using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Models.Entities
{
    public partial class SurveySharedWithCustomers
    {
        public int ID { get; set; }
        public int SurveyID { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }

        public string UniqueSurveyURL { get; set; }
        public bool HasSubmitted { get; set; }

        
    }
}
