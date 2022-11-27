using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Models.ViewModels
{
    public class SurveySendViewModel : BaseViewModel
    {
        public string Url { get; set; }
        public string EmailText { get; set; }
        public string ContactNumberText { get; set; }
        public string medium { get; set; }
        
        public string ErrorMessage { get; set; }
    }
}
