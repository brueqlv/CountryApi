namespace CountryApi.Classes
{
    public class CountryInfo
    {
        public FullName Name { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }
        public List<string>? Tld { get; set; }
    }
}
