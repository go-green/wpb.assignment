using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wpb.CarsRating.Core.ApiServices.Contracts;
using Wpb.CarsRating.Core.Configurations;

namespace Wpb.CarsRating.Core.ApiServices
{
    public class RestClient : IRest
    {
        private readonly HttpClient _httpClient;

        private const string JSON_CONTENT_TYPE = "application/json";

        public RestClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(AppSettings.Api.Url)
            };
        }

        public Task<HttpResponseMessage> DeleteAsync(string endpoint, string authToken)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> GetAsync(string endpoint, string authToken = null, IDictionary<string, string> headers = null)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> PostAsync(string endpoint, object payload, string authToken = null, IDictionary<string, string> headers = null)
        {
            return await SendJsonAsync(HttpMethod.Post, endpoint, payload, authToken, headers);
        }

        public async Task<HttpResponseMessage> PutAsync(string endpoint, object payload, string authToken = null, IDictionary<string, string> headers = null)
        {
            throw new NotImplementedException();
        }

        private async Task<HttpResponseMessage> SendJsonAsync(HttpMethod method, string requestUrl, object payload,
            string authToken, IDictionary<string, string> headers)
        {
            HttpRequestMessage message;
            if (payload == null)
            {
                message = new HttpRequestMessage(method, requestUrl);
            }
            else
            {
                var messageContent = JsonConvert.SerializeObject(payload);
                message = new HttpRequestMessage(method, requestUrl)
                {
                    Content = new StringContent(messageContent, Encoding.UTF8, JSON_CONTENT_TYPE)
                };
            }

            AddHeaders(message, headers);
            var response = await SendAsync(authToken, message);
            return response;
        }

        private async Task<HttpResponseMessage> SendAsync(string authToken, HttpRequestMessage request)
        {
            var httpResult = await _httpClient.SendAsync(request);
            return httpResult;
        }

        private void AddHeaders(HttpRequestMessage message, IDictionary<string, string> headers)
        {
            if (headers == null)
                return;
            foreach (var keyValuePair in headers)
                message.Headers.Add(keyValuePair.Key, keyValuePair.Value);
        }
    }
}
