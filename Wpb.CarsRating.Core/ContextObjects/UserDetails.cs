using Newtonsoft.Json;

namespace Wpb.CarsRating.Core.ContextObjects
{
    public class UserUnderTest : BaseContextUnderTest<UserDetails>
    {
        public UserDetails Current { get; set; }
    }

    public class UserDetails
    {
        [JsonProperty("userName")]
        public string LoginName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("confirmPassword")]
        public string ConfirmPassword { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
