using System.Text.Json;
using RuneSharp.Models.Enums;

namespace RuneSharp.Brokers.Apis;

public partial class ApiBroker : IApiBroker
{
    private readonly HttpClient _httpClient;
   
    public ApiBroker(HttpClient? httpClient = default)
    {
        _httpClient = httpClient ?? new HttpClient();
    }

    private async ValueTask<string> GetAsync(string relativeUrl, CancellationToken cancellationToken)
    {
       var response = await _httpClient.GetAsync(relativeUrl,cancellationToken);
       return await response.Content.ReadAsStringAsync(cancellationToken);
    }


    private async ValueTask<string> PostAsync<T>(string relativeUrl, T content, CancellationToken cancellationToken)
    {
        var jsonString = JsonSerializer.Serialize(content);
        var response = await _httpClient.PostAsync(relativeUrl, new StringContent(jsonString),cancellationToken);
        return await response.Content.ReadAsStringAsync(cancellationToken);
    }
    
    

    private void OnConfiguration(Endpoints endpoint)
    {
        //find endpoint
        _httpClient.BaseAddress = new Uri(string.Empty);
    }
    

}