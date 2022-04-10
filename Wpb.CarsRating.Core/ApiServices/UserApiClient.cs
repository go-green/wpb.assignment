using System;
using System.Net.Http;
using System.Threading.Tasks;
using Wpb.CarsRating.Core.ApiServices.Contracts;
using Wpb.CarsRating.Core.ContextObjects;

namespace Wpb.CarsRating.Core.ApiServices
{
    public class UserApiClient : ApiClientBase, IUser
    {
        public UserApiClient(
            IRest restClient)
            : base(restClient)
        {
        }

        public async Task<bool> RegisterUser(UserDetails user)
        {
            HttpResponseMessage response = null;
            string responseMessage = null;
            var endPoint = "/prod/users";
            try
            {
                response = await RestClient.PostAsync(endPoint, user, null, null);
                response.EnsureSuccessStatusCode();
                responseMessage = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"Request to end point: {endPoint} failed. \n {responseMessage} \n {e.InnerException}");
            }
        }
    }
}
