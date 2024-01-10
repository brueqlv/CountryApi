using Newtonsoft.Json;

namespace CountryApi
{
    public class CountriesService
    {
        private readonly HttpClient _httpClient;

        public CountriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CountryInfo>> GetEuropeanUnionCountries()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/region/europe?fields=name,area,population,tld,nativeName");
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var countries = JsonConvert.DeserializeObject<List<CountryInfo>>(responseContent);

                return countries;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CountryInfo> GetCountryByName(string name)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/name/{name}/?fields=name,area,population,tld,nativeName");
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var countrie = JsonConvert.DeserializeObject<CountryInfo>(responseContent);

                return countrie;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
