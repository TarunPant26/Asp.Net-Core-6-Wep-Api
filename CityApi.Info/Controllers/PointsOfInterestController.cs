using CityApi.Info.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityApi.Info.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly IValidator<PointOfInterestCreationDto> validator;

        public PointsOfInterestController(IValidator<PointOfInterestCreationDto> validator)
        {
            this.validator = validator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city.PointOfInterest);
        }

        [HttpGet("{pointofinterestid}",Name = "GetPointofInterest")]
        public ActionResult<PointOfInterestDto> GetPointofInterest(int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointOfInterest.FirstOrDefault(x => x.Id == pointOfInterestId);

            if(pointOfInterest ==null)
            {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }

        /// <summary>
        /// we are usiing api controller attribute so we do not need frombody 
        /// as paramerter for complex type
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="pointOfInterest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(
            int cityId,
            PointOfInterestCreationDto pointOfInterest
            )
        {
            //as validatoin in model is violating single respoinsiblity priciple as 
            // it is not the place to validate the model so we used 3rd party Fluent validation
            ValidationResult result = await validator.ValidateAsync(pointOfInterest);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            //not needed because of API Controller
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);

            if(city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore.Current.Cities.
                SelectMany(c => c.PointOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description

            };

            city.PointOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointofInterest",
                new { cityId = cityId, pointOfInterestId = finalPointOfInterest.Id }, finalPointOfInterest);
        }
    }
}
