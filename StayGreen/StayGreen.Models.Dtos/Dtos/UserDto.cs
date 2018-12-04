using StayGreen.Models.Dtos.Common;

namespace StayGreen.Models.Dtos.Dtos
{
    public class UserDto : BaseDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
