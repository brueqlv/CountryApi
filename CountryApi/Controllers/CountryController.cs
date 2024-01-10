using CountryApi.Classes;
using Microsoft.AspNetCore.Mvc;

namespace CountryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CountryController : ControllerBase
    {
        private readonly CountriesService _countryClient;

        public CountryController(CountriesService countryClient)
        {
            _countryClient = countryClient;
        }

        [HttpGet("top10/population")]
        public async Task<IActionResult> GetTop10Population()
        {
            var countries = await _countryClient.GetEuropeanUnionCountries();
            var top10Countries = countries.OrderByDescending(c => c.Population).Take(10);

            return Ok(top10Countries);
        }

        [HttpGet("top10/populationDensity")]
        public async Task<IActionResult> GetTop10PopulationDensity()
        {
            var countries = await _countryClient.GetEuropeanUnionCountries();
            var top10Countries = countries.OrderByDescending(c => c.Population / c.Area).Take(10);

            return Ok(top10Countries);
        }

        [HttpGet("{country}/details")]
        public async Task<IActionResult> GetCountryDetails(string country)
        {
            var selectedCountry = await _countryClient.GetCountryByName(country);

            if (selectedCountry == null)
            {
                return NotFound();
            }

            var response = new CountryDetailsResponse
            {
                Area = selectedCountry.Area,
                Population = selectedCountry.Population,
                Tld = selectedCountry.Tld,
                NativeName = selectedCountry.Name.NativeName
            };

            return Ok(response);
        }
    }
}

