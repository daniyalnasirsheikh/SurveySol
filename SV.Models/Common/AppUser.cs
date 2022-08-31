using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Models.Common
{
    public class AppUser
    {
        public AppUser()
        {
            AppUserRoles = new List<AppUserRoles>();
        }
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<AppUserRoles> AppUserRoles { get; set; }
        public string CreatedOn { get; set; }
        public string LastLoggedIn { get; set; }
        
    }

    public class AppUserRoles
    {
        public AppUserRoles()
        {
            RolesClaimsList = new List<RolesClaims>();
        }
        public int ID { get; set; }
        public string Role { get; set; }
        public List<RolesClaims> RolesClaimsList { get; set; }
    }

    public class RolesClaims
    {
        public int ID { get; set; }
        public string ClaimName { get; set; }
    }
}
