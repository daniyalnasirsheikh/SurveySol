using SV.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SV.WebApp.HTTPHelpers.Interfaces
{
    public interface IDataHelper
    {
        Task<T> GetById<T>(string EndpointURL, dynamic obj, bool requiredtoken = true);

        Task<T> GetAll<T>(string EndpointURL, bool requiredtoken = true);

        Task<ResponseObject<T>> Post<T>(string EndpointURL,T model, bool requiredtoken = true);
        Task<T> UploadFile<T>(string EndpointURL, MultipartFormDataContent model);

        //Task<T> Post<T>(string EndpointURL, PagedResultBase<T> model);
        Task<T> Put<T>(string EndpointURL, T model, int Id);

        Task<T> Delete<T>(string EndpointURL, int Id);

        Task<T> UsingSearchObject<T, U>(string EndpointURL, U model, bool requiredtoken = true);
        Task<List<T>> GetListObjects<T>(string EndpointURL,T Model, bool requiredtoken = true);

    }
}
