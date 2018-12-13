using StayGreen.Models.Dtos.Common;
using System;

namespace StayGreen.Models.Dtos.Schemas
{
    public class UserDto : BaseDto<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
