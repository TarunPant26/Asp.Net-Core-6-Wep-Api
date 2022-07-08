using CityApi.Info.Models;

namespace CityApi.Info
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id =1,
                    Name="Nainital",
                    Description="City of Lake",
                    PointOfInterest = new List<PointOfInterestDto>
                    {
                        new PointOfInterestDto
                        {
                            Id =1,
                            Name ="Hanuman Gadi",
                            Description ="Temple created by Baba Neem Karoli"
                        },

                        new PointOfInterestDto
                        {
                            Id =2,
                            Name ="Kenchi",
                            Description ="Temple created by Baba Neem Karoli"
                        }
                    }

                },

                new CityDto()
                {
                    Id =2,
                    Name="Haldwani",
                    Description="Gateway of Kumaon",
                    PointOfInterest = new List<PointOfInterestDto>
                    {
                        new PointOfInterestDto
                        {
                            Id =3,
                            Name ="Kalu Sai Mandir",
                            Description ="Temple famous for gud a special sweet people give as prasad"
                        },

                        new PointOfInterestDto
                        {
                            Id =4,
                            Name ="Radha Swami Temple",
                            Description ="Temple for Lord Krishna Devotees"
                        }
                    }
                },

                new CityDto()
                {
                    Id =3,
                    Name="Banglore",
                    Description="Silicon welly of India",
                    PointOfInterest = new List<PointOfInterestDto>
                    {
                        new PointOfInterestDto
                        {
                            Id =5,
                            Name ="Upudpi",
                            Description ="Restraunt to eat South Indian delicious food"
                        },

                        new PointOfInterestDto
                        {
                            Id =6,
                            Name ="ISKON",
                            Description ="Temple created by Shri Prabhupadh for Krishna Consiounous"
                        }
                    }
                }
            };
        }
    }
}
