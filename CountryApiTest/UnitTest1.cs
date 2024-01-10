using CountryApi;
using CountryApi.Controllers;
using Moq;

namespace CountryApiTest
{
    public class Tests
    {
        private CountriesService _countriesService;
        private Mock<HttpClient> _httpClientMock;

        [SetUp]
        public void Setup()
        {
            _httpClientMock = new Mock<HttpClient>();
            _countriesService = new CountriesService(_httpClientMock.Object);
        }

        [Test]
        public async Task GetEuropeanUnionCountries_Should_Return_Country_List()
        {
            var result = await _countriesService.GetEuropeanUnionCountries();

            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(List<CountryInfo>), result);
        }

        [Test]
        public async Task GetTop10Population_Should_Be_Sorted_By_Population()
        {
        }
    }
}