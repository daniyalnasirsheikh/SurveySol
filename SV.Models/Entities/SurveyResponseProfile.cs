using System;
using System.Collections.Generic;

#nullable disable

namespace SV.Models.Entities
{
    public partial class SurveyResponseProfile
    {
        public SurveyResponseProfile()
        {
            Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string FullName { get; set; }
        public DateTime ResponseOn { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
