using SV.Models.Common;
using SV.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SV.WebApp.HTTPHelpers.Interfaces
{
    public interface ILoginHelper
    {
        Task<ResponseObject<UserRefreshToken>> Login(AppUser model);

        Task<UserRefreshToken> RefreshToken(UserRefreshToken model);

        void SetSession(UserRefreshToken model);
        UserRefreshToken GetSession();

        Task Logout();

        void RemoveSession();

        Task<List<Claim>> GetCLaimsUsingToken(string token);

        AppUser GetLoggedInUser();
    }
}
