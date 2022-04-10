using System.Threading.Tasks;
using Wpb.CarsRating.Core.ContextObjects;

namespace Wpb.CarsRating.Core.ApiServices.Contracts
{
    public interface IUser
    {
        Task<bool> RegisterUser(UserDetails user);
    }
}
