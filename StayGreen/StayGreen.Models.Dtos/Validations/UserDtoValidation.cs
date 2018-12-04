using FluentValidation;
using StayGreen.Models.Dtos.Dtos;

namespace StayGreen.Models.Dtos.Validations
{
    public class UserDtoValidation : AbstractValidator<UserDto>
    {
        public UserDtoValidation()
        {
            RuleFor(x => x.FirstName)
                .NotNull();
        }
    }
}
