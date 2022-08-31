using System;
using System.Collections.Generic;

#nullable disable

namespace SV.Models.Entities
{
    public partial class UserShareSurvey
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int SurveyId { get; set; }

        public virtual Survey Survey { get; set; }
    }
}
