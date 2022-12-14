namespace WeatherForecast.Application;
using System.Text;

public class EndpointBuilder
{
    private readonly StringBuilder urlBuilder = new StringBuilder();
    private readonly StringBuilder paramBuilder = new StringBuilder();

    private const char defaultLimiter = '&';
    private const char defaultDelimiter = '/';
    private const char questionMark = '?';
    private const char equalityMark = '=';

    public string BaseUrl { get; set; }
    public string ApiKey { get; set; }

    public EndpointBuilder(string baseUrl , string apiKey)
    {
        this.BaseUrl = baseUrl;
        this.ApiKey = apiKey;
    }

    public EndpointBuilder Append(string value)
    {
        urlBuilder.Append(value);
        urlBuilder.Append(defaultDelimiter);

        return this;
    }

    public EndpointBuilder AppendParam(string key, string value)
    {
        paramBuilder.Append($"{key}{equalityMark}{value}");

        return this;
    }

    public string Build()
    {
        if (BaseUrl.EndsWith(defaultDelimiter))
            urlBuilder.Insert(default(int), BaseUrl);
        else
            urlBuilder.Insert(default(int), BaseUrl + defaultDelimiter);

        var url = urlBuilder.ToString().TrimEnd(defaultLimiter);

        if (paramBuilder.Length > default(int))
        {
            string queryParams = paramBuilder.ToString().TrimEnd(defaultLimiter);
            url = urlBuilder.ToString().TrimEnd(defaultDelimiter).TrimEnd(questionMark);

            url = $"{url}{questionMark}{queryParams}";
        }

        return url.TrimEnd(defaultDelimiter);
    }
}