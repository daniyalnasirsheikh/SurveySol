using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using SV.Models.Common;
using SV.WebApp.HTTPHelpers.Interfaces;
using SV.WebApp.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

using System.Threading.Tasks;


namespace SV.WebApp.HTTPHelpers.Implementation
{
    public class LoginHelper : ILoginHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
    
        public LoginHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }


        public async Task<ResponseObject<UserRefreshToken>> Login(AppUser model)
        {
            var todoItemJson = new StringContent(
       JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            try
            {
                var client = GetClient();
                var response = await client.PostAsync("Auth/Login", todoItemJson);

                ResponseObject<UserRefreshToken> result = new ResponseObject<UserRefreshToken>(); ;

                // response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    if (!String.IsNullOrEmpty(jsonString))
                    {

                        result.Data = JsonConvert.DeserializeObject<UserRefreshToken>(jsonString);
                        return result;
                    }
                    else
                    {
                        return default(ResponseObject<UserRefreshToken>);

                    }


                }
               
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    result.Error = JsonConvert.DeserializeObject<List<IdentityError>>(jsonString);
                    return result;
                }

                return default(ResponseObject<UserRefreshToken>);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // public async Task<UserRefreshToken> Login(AppUser model)
        // {
        //     var todoItemJson = new StringContent(
        //JsonConvert.SerializeObject(model),Encoding.UTF8,"application/json");
        //     try
        //     {
        //         var client =  _httpClientFactory.CreateClient("auth");
        //         var response = await client.PostAsync("Auth/Login", todoItemJson);



        //         response.EnsureSuccessStatusCode();
        //         var jsonString = await response.Content.ReadAsStringAsync();
        //         UserRefreshToken refreshTokenObject = JsonConvert.DeserializeObject<UserRefreshToken>(jsonString);
        //         return refreshTokenObject;
        //     }
        //     catch (Exception ex) 
        //     {
        //         throw ex;
        //     }
        // }

        public async Task Logout()
        {
            RemoveSession();
            //try
            //{
            //    var client = GetClient();
            //    UserRefreshToken model = GetSession();
            //    string Url = String.Format("Auth/Logout/{0}", model.UserId);
            //    var response = await client.DeleteAsync(Url);
            //    response.EnsureSuccessStatusCode();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public async Task<UserRefreshToken> RefreshToken(UserRefreshToken model)
        {

            var todoItemJson = new StringContent(
       JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            try
            {
                var client = GetClient();
                var response = await client.PostAsync("Auth/RefreshToken", todoItemJson);

                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                UserRefreshToken refreshTokenObject = JsonConvert.DeserializeObject<UserRefreshToken>(jsonString);
               // await ClientSideLogin(refreshTokenObject);
                return refreshTokenObject;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }



        public async Task<List<Claim>> GetCLaimsUsingToken(string token)
        {

       //     var todoItemJson = new StringContent(
       //JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            try
            {
                var client = GetClient();
                var response = await client.GetAsync("Auth/GetPrincipalFromExpiredToken?token="+ token);

                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                List<Claim> ClaimsPrincipal = JsonConvert.DeserializeObject<List<Claim>>(jsonString);
                // await ClientSideLogin(refreshTokenObject);
                return ClaimsPrincipal;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //public void SetSession(UserRefreshToken model)
        //{

           
        //    _accessor.SetComplexData("Object", model);
        //}
        //public UserRefreshToken GetSession()
        //{
          
        //    return _accessor.GetComplexData<UserRefreshToken>("Object");
        //}

        public AppUser GetLoggedInUser()
        {

            //UserRefreshToken userRefreshToken = GetSession(); ;
            //return userRefreshToken?.User;
            return null;
        }
        private HttpClient GetClient() {
        
        return _httpClientFactory.CreateClient("api");

        }

        public void RemoveSession()
        {
            //_accessor.Remove("Object");
        }

       

       

        public void SetSession(UserRefreshToken model)
        {
            throw new NotImplementedException();
        }

        UserRefreshToken ILoginHelper.GetSession()
        {
            throw new NotImplementedException();
        }

        AppUser ILoginHelper.GetLoggedInUser()
        {
            throw new NotImplementedException();
        }
    }
}
