using SV.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SV.Models.Entities
{
    public partial class Question
    {
        [NotMapped]
        public double RatingTerriblePer { get; set; }
        [NotMapped]
        public double RatingBadPer { get; set; }
        [NotMapped]
        public double RatingOkayPer { get; set; }
        [NotMapped]
        public double RatingGoodPer { get; set; }
        [NotMapped] 
        public double RatingGreatPer { get; set; }
        [NotMapped]
        public Dictionary<string, double> KeyValuePair { get; set; } = new Dictionary<string, double>();
        [NotMapped]
        public double[,] MatrixArray { get; set; }
        [NotMapped]
        public string QuestionTextArabic { get; set; }
        [NotMapped]
        public OptionsViewModel OptionsViewModel { get; set; }
    }
}
