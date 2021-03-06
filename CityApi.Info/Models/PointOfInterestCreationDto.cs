using System.ComponentModel.DataAnnotations;

namespace CityApi.Info.Models
{
    public class PointOfInterestCreationDto
    {
        public string Name { get; set; } = string.Empty;

        public string ? Description { get; set; }
    }
}
