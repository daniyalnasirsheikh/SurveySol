using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.WebApp.Models
{
  public  class ResponseObject <T>
    {
        public T Data { get; set; }
        public List<IdentityError> Error { get; set; }
    }
}
