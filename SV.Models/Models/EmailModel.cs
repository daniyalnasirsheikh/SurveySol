using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Models.Models
{
    public class EmailModel
    {
        public string DisplayName { get; set; }
        public string FromEmailAddres { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public bool EnableSsl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
