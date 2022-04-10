using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Wpb.CarsRating.Core.ApiServices.Contracts
{
    public interface IRest
    {
        Task<HttpResponseMessage> PostAsync(string endpoint, object payload, string authToken = null, IDictionary<string, string> headers = null);
        Task<HttpResponseMessage> GetAsync(string endpoint, string authToken = null, IDictionary<string, string> headers = null);
        Task<HttpResponseMessage> DeleteAsync(string endpoint, string authToken);
        Task<HttpResponseMessage> PutAsync(string endpoint, object payload, string authToken = null, IDictionary<string, string> headers = null);
    }
}
