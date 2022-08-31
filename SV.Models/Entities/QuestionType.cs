using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Models.Entities
{
    public static class QuestionType
    {
        public static List<string> Types
        {
            get
            {
                return new List<string>
                {
                    "Yes or No",
                    "Radio",
                    "Multiple Choice",
                    "Dropdown Menu",
                    "Matrix Single",
                    "Matrix Multi Select",
                    "Single Text",
                    "Comment Box",
                    "Rating",
                    "Semantic Question",
                    "Net Promoter Score",
                    "Logic"
                };
            }
        }
    }
}
