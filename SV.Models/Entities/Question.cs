using System;
using System.Collections.Generic;

#nullable disable

namespace SV.Models.Entities
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            InverseParentQuestion = new HashSet<Question>();
        }

        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int Order { get; set; }
        public string QuestionText { get; set; }
        public string Type { get; set; }
        public bool IsRequire { get; set; }
        public bool IsDocRequire { get; set; }
        public string DocPath { get; set; }
        public string OptionsText { get; set; }
        public string CssClass { get; set; }
        public string OptionsAlignment { get; set; }
        public string LogicalQuestionText { get; set; }
        public int? ParentQuestionId { get; set; }

        public virtual Question ParentQuestion { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Question> InverseParentQuestion { get; set; }
    }
}
