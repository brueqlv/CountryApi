namespace CountryApi.Classes
{
    public class FullName
    {
        public string Common { get; set; }
        public string Official { get; set; }
        public Dictionary<string, NameInfo> NativeName { get; set; }
    }
}
