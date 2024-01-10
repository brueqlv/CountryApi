namespace CountryApi.Classes
{
    public class CountryDetailsResponse
    {
        public double Area { get; set; }
        public int Population { get; set; }
        public List<string>? Tld { get; set; }
        public Dictionary<string, NameInfo>? NativeName { get; set; }
    }
}
