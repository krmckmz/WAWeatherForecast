namespace WeatherForecast.Application
{
    public interface IUrlBuilder
    {
        public UrlBuilder SetBaseUrl(string baseUrl);

        public UrlBuilder SetApiKey(string apiKey);
        public UrlBuilder Append(string value);
        public UrlBuilder AppendParam(string key, string value);
        public string Build();
    }
}