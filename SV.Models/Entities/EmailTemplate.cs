using System;
using System.Collections.Generic;

#nullable disable

namespace SV.Models.Entities
{
    public partial class EmailTemplate
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
