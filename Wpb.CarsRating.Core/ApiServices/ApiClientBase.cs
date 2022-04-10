using Wpb.CarsRating.Core.ApiServices.Contracts;

namespace Wpb.CarsRating.Core.ApiServices
{
    public class ApiClientBase
    {
        protected readonly IRest RestClient;

        public ApiClientBase(
            IRest restClient)
        {
            RestClient = restClient;
        }
    }
}
