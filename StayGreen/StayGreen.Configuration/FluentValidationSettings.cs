using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using StayGreen.Models.Dtos.Schemas;
using StayGreen.Models.Dtos.Validations;

namespace StayGreen.Configuration
{
    public static class FluentValidationSettings
    {
        public static void CofidureFluentValidationDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IValidator<UserDto>, UserDtoValidation>();
        }
    }
}
