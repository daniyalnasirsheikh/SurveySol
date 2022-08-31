using System;
using System.Collections.Generic;

#nullable disable

namespace SV.Models.Entities
{
    public partial class Answer
    {
        public int Id { get; set; }
        public int SurveyResponseProfileId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
        public string DocPath { get; set; }

        public virtual Question Question { get; set; }
        public virtual SurveyResponseProfile SurveyResponseProfile { get; set; }
    }
}
