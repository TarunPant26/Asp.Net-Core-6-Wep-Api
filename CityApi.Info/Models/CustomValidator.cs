using CityApi.Info.Models;
using FluentValidation;

namespace CityApi.Info.Models
{
    public class CustomValidator : AbstractValidator<PointOfInterestCreationDto>
    {
        public CustomValidator()
        {
            RuleFor(poi => poi.Name).NotEmpty();
            RuleFor(poi => poi.Name).MaximumLength(20);
            RuleFor(poi => poi.Description).MaximumLength(200);
        }
    }
}
