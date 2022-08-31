using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SV.Models.Common;
using SV.WebApp.HTTPHelpers.Interfaces;
using SV.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SV.WebApp.HTTPHelpers.Implementation
{
    public class DataHelper : IDataHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginHelper _loginHelper;
        public UserRefreshToken userRefreshToken { get; set; }

        public DataHelper(IHttpClientFactory HttpClientFactory, ILoginHelper loginHelper)
        {
            _httpClientFactory = HttpClientFactory;
            _loginHelper = loginHelper;




        }
        public async Task<T> Delete<T>(string EndpointURL, int Id)
        {
            try
            {
                T refreshTokenObject;

                var client = GetClient();
                userRefreshToken = _loginHelper.GetSession();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userRefreshToken.Token);
                string FEndpointURL = EndpointURL + "/" + Id;
                var response = await client.DeleteAsync(FEndpointURL);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    refreshTokenObject = JsonConvert.DeserializeObject<T>(jsonString);
                    // userRefreshToken = _loginHelper.GetSession();
                    return refreshTokenObject;
                }
                if (response.Headers.Contains("Token-Expired") && response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await RefreshToken();
                    return await Delete<T>(EndpointURL, Id);
                }

                return default(T);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<T> GetAll<T>(string EndpointURL,bool requiredtoken=true)
        {
            try
            {
                T refreshTokenObject;

                var client = GetClient();

                if (requiredtoken)
                {
                    userRefreshToken = _loginHelper.GetSession();
                    if (userRefreshToken!=null)
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userRefreshToken.Token);
                    }
                }
                else
                {


                }

                var response = await client.GetAsync(EndpointURL);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    refreshTokenObject = JsonConvert.DeserializeObject<T>(jsonString);
                    // userRefreshToken = _loginHelper.GetSession();
                    return refreshTokenObject;
                }
                else if (response.Headers.Contains("Token-Expired") && response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await RefreshToken();
                    return await GetAll<T>(EndpointURL, requiredtoken);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {


                }



                //userRefreshToken = _loginHelper.GetSession();
                //if (userRefreshToken != null)
                //{
                //    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userRefreshToken.Token);
                //    var response = await client.GetAsync(EndpointURL);

                //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //    {
                //        var jsonString = await response.Content.ReadAsStringAsync();
                //        refreshTokenObject = JsonConvert.DeserializeObject<T>(jsonString);
                //        // userRefreshToken = _loginHelper.GetSession();
                //        return refreshTokenObject;
                //    }
                //    else if (response.Headers.Contains("Token-Expired") && response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                //    {
                //        await RefreshToken();
                //        return await GetAll<T>(EndpointURL);
                //    }
                //    else if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                //    { 


                //    }
                //}
                //else { 


                //}


                return default(T);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<T> GetById<T>(string EndpointURL, dynamic obj, bool requiredtoken = true)
        {
            try
            {
                T result;

                var client = GetClient();

                if (requiredtoken)
                {
                    userRefreshToken = _loginHelper.GetSession();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userRefreshToken.Token);
                }
               
              string   FEndpointURL = EndpointURL + "/" + obj;
                var response = await client.GetAsync(FEndpointURL);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(jsonString);
                    return result;
                }
                if (response.Headers.Contains("Token-Expired") && response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await RefreshToken();
                    return await GetById<T>(EndpointURL,obj,requiredtoken);
                }

                return default(T);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ResponseObject<T>> Post<T>(string EndpointURL, T model, bool requiredtoken = true)
        {
            try
            {
                Debug.WriteLine("Serilize Object");
                Debug.WriteLine(JsonConvert.SerializeObject(model));
                var requestmodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                Debug.WriteLine("Serilize Model");
                Debug.WriteLine(requestmodel);
                ResponseObject<T> result = new ResponseObject<T>(); ;
           
                var client = GetClient();
                if (requiredtoken)
                {
                    userRefreshToken = _loginHelper.GetSession();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userRefreshToken.Token);
                }
                
                //client.DefaultRequestHeaders.Add("Origion", UrlHelperExtensions.Action("ConfirmEmail","Account",new { } , HttpClient)  );
                var response = await client.PostAsync(EndpointURL, requestmodel);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    if (!String.IsNullOrEmpty(jsonString))
                    {
                        
                        result.Data = JsonConvert.DeserializeObject<T>(jsonString);
                        return result;
                    }
                    else
                    {
                        return default(ResponseObject<T>);

                    }
                   
                   
                }
                if (response.Headers.Contains("Token-Expired") && response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await RefreshToken();
                    return await Post<T>(EndpointURL, model);
                }
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    
                    result.Error = JsonConvert.DeserializeObject<List<IdentityError>>(jsonString);
                    return result;
                }

                return default(ResponseObject<T>);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> UsingSearchObject<T,U>(string EndpointURL, U model, bool requiredtoken = true)
        {
            try
            {
                var requestmodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                

                var client = GetClient();
                if (requiredtoken)
                {
                    userRefreshToken = _loginHelper.GetSession();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userRefreshToken.Token);
                }


                var response = await client.PostAsync(EndpointURL, requestmodel);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonString);
                    
                }
                if (response.Headers.Contains("Token-Expired") && response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await RefreshToken();
                    return await UsingSearchObject<T,U>(EndpointURL, model);
                }
                //if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                //{
                //    var jsonString = await response.Content.ReadAsStringAsync();
                //    result.Error = JsonConvert.DeserializeObject<List<IdentityError>>(jsonString);
                //    return result;
                //}

                return default(T);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<T> UploadFile<T>(string EndpointURL, MultipartFormDataContent model)
        {
            try
            {
              
                T result;

                var client = GetClient();
                userRefreshToken = _loginHelper.GetSession();
             

                
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userRefreshToken.Token);

                var response = await client.PostAsync(EndpointURL, model);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(jsonString);
                    return result;
                }
                if (response.Headers.Contains("Token-Expired") && response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await RefreshToken();
                    return await UploadFile<T>(EndpointURL, model);
                }

                return default(T);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> Put<T>(string EndpointURL, T model, int Id)
        {
            try
            {
                var requestmodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                T result;

                var client = GetClient();
                userRefreshToken = _loginHelper.GetSession();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userRefreshToken.Token);
                string FEndpointURL = EndpointURL + "/" + Id;
                var response = await client.PostAsync(FEndpointURL, requestmodel);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(jsonString);
                    return result;
                }
                if (response.Headers.Contains("Token-Expired") && response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await RefreshToken();
                    return await Put<T>(EndpointURL, model,Id);
                }

                return default(T);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        private async Task RefreshToken() {

            UserRefreshToken refreshToken = userRefreshToken;
            UserRefreshToken tokenobject = await _loginHelper.RefreshToken(refreshToken);
            _loginHelper.SetSession(tokenobject);
        }

        public async Task<List<T>> GetListObjects<T>(string EndpointURL, T model , bool requiredtoken = true)
        {
            try
            {
                var requestmodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                List<T> result;

                var client = GetClient();

                if (requiredtoken)
                {
                    userRefreshToken = _loginHelper.GetSession();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userRefreshToken.Token);
                }

         

                var response = await client.PostAsync(EndpointURL, requestmodel);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<T>>(jsonString);
                    return result;
                }
                if (response.Headers.Contains("Token-Expired") && response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await RefreshToken();
                    return await GetListObjects<T>(EndpointURL, model);
                }

                return default(List<T>);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public async Task<T> Post<T>(string EndpointURL, PagedResultBase<T> model)
        //{
        //    try
        //    {
        //        var requestmodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        //        T result;

        //        var client = GetClient();
        //        userRefreshToken = _loginHelper.GetSession();
        //        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + userRefreshToken.Token);

        //        var response = await client.PostAsync(EndpointURL, requestmodel);

        //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            var jsonString = await response.Content.ReadAsStringAsync();
        //            result = JsonConvert.DeserializeObject<T>(jsonString);
        //            return result;
        //        }
        //        if (response.Headers.Contains("Token-Expired") && response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        //        {
        //            await RefreshToken();
        //            return await Post<T>(EndpointURL, model);
        //        }

        //        return default(T);

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        private HttpClient GetClient()
        {

            return _httpClientFactory.CreateClient("api");

        }

        Task<ResponseObject<T>> IDataHelper.Post<T>(string EndpointURL, T model, bool requiredtoken)
        {
            throw new NotImplementedException();
        }

        
    }
}
