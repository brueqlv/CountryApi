using CountryApi;
using CountryApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CountryApiTest
{
    public class Tests
    {
        private CountriesService _countriesService;
        private CountryController _controller;
        private Mock<HttpClient> _httpClientMock;

        [SetUp]
        public void Setup()
        {
            _httpClientMock = new Mock<HttpClient>();
            _countriesService = new CountriesService(_httpClientMock.Object);
            _controller = new CountryController(_countriesService);

        }

        [Test]
        public async Task GetEuropeanUnionCountries_Should_Return_Country_List()
        {
            var result = await _countriesService.GetEuropeanUnionCountries();

            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(List<CountryInfo>), result);
        }

        [Test]
        public async Task GetTop10Population_Should_Return_10_Countries()
        {
            var actionResult = await _controller.GetTop10Population();
            var okResult = actionResult as OkObjectResult;
            var result = okResult?.Value as IEnumerable<CountryInfo>;

            List<CountryInfo> resultList = result.ToList();

            Assert.IsTrue(resultList.Count == 10);
        }

        [Test]
        public async Task GetTop10Population_Should_Be_Sorted_By_Population()
        {
            var actionResult = await _controller.GetTop10Population();
            var okResult = actionResult as OkObjectResult;
            var result = okResult?.Value as IEnumerable<CountryInfo>;

            List<CountryInfo> resultList = result.ToList();

            for (int i = 1; i < resultList.Count; i++)
            {
                Assert.True(resultList[i - 1].Population >= resultList[i].Population);
            }
        }

        [Test]
        public async Task GetTop10PopulationDensity_Should_Return_10_Countries()
        {
            var actionResult = await _controller.GetTop10PopulationDensity();
            var okResult = actionResult as OkObjectResult;
            var result = okResult?.Value as IEnumerable<CountryInfo>;

            List<CountryInfo> resultList = result.ToList();

            Assert.IsTrue(resultList.Count == 10);
        }

        [Test]
        public async Task GetTop10PopulationDensity_Should_Be_Sorted_By_Population_Density()
        {
            var actionResult = await _controller.GetTop10PopulationDensity();
            var okResult = actionResult as OkObjectResult;
            var result = okResult?.Value as IEnumerable<CountryInfo>;

            List<CountryInfo> resultList = result.ToList();

            for (int i = 1; i < resultList.Count; i++)
            {
                double firstDensity = resultList[i - 1].Population / resultList[i - 1].Area;
                double secondDensity = resultList[i].Population / resultList[i].Area;

                Assert.True(firstDensity >= secondDensity);
            }
        }
        [Test]
        public async Task GetCountryDetails_Should_Return_Latvia()
        {
            var actionResult = await _controller.GetCountryDetails("Latvia");
            var okResult = actionResult as OkObjectResult;
            var result = okResult.Value as CountryDetailsResponse;

            Assert.IsNotNull(result);

            var expectedArea = 64559;
            var expectedPopulation = 1901548;

            Assert.AreEqual(expectedArea, result.Area);
            Assert.AreEqual(expectedPopulation, result.Population);
        }
    }
}