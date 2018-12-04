using FluentValidation;
using StayGreen.Models.Dtos.Schemas;

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
