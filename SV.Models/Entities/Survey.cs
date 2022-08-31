using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SV.Models.Entities
{
    public partial class Survey
    {
        public Survey()
        {
            Questions = new HashSet<Question>();
            UserShareSurveys = new HashSet<UserShareSurvey>();
            //SurveySharedWithCustomers = new HashSet<SurveySharedWithCustomers>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string DepartmentIds { get; set; }

        [NotMapped]
        public List<string> Department { get; set; }

        public string SurveyType { get; set; }

        public string LogoPath { get; set; }
        public string BannerPath { get; set; }
        public string BackgroundImagePath { get; set; }
        public int? MaxResponse { get; set; }
        public int? QuestionPerPage { get; set; }
        public bool IsLaunched { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        // public virtual ICollection<SurveySharedWithCustomers> SurveySharedWithCustomers { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<UserShareSurvey> UserShareSurveys { get; set; }
    }
}
