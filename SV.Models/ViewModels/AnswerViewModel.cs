using Microsoft.AspNetCore.Http;
using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Models.ViewModels
{
    public class AnswerViewModel : Answer
    {
        public IFormFile Doc { get; set; }
    }
}
