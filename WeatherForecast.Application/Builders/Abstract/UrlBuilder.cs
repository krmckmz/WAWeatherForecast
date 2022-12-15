namespace WeatherForecast.Application;

public abstract class UrlBuilder : IUrlBuilder, IDomainBuilder
{
    protected string BaseUrl { get; set; }
    protected string ApiKey { get; set; }
    
    public abstract UrlBuilder SetApiKey(string apiKey);

    public abstract UrlBuilder SetBaseUrl(string baseUrl);
    public abstract UrlBuilder Append(string value);
    public abstract UrlBuilder AppendParam(string key, string value);
    public abstract string Build();
}