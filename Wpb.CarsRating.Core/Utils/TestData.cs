using Wpb.CarsRating.Core.ContextObjects;
using Bogus.DataSets;
using System;

namespace Wpb.CarsRating.Core.Utils
{
    public class TestData
    {
        public static UserDetails GetRandomUser()
        {
            var name = new Name();
            var password = $"{name.FirstName()}~{name.LastName()}%{name.Random.Number(1, 20)}#";
            return new UserDetails
            {
                FirstName = name.FirstName(),
                LastName = name.LastName(),
                LoginName = $"{name.FirstName()}_{name.Random.Number(1, 20)}",
                Password = password,
                ConfirmPassword = password
            };
        }

        public static string ReverseText(string text)
        {
            var charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
