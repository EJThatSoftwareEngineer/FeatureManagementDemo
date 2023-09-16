using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.FeatureManagement;

[FilterAlias("FeatureF")]
public class FeatureF : IFeatureFilter
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FeatureF(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
    {
        // Replace with your server endpoint to fetch feature state
        string serverEndpoint = "https://localhost:7021/api/ExampleAPI/GetBoolean";

        try
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync(serverEndpoint);
            // Parse the response and determine if the feature should be enabled
            bool isFeatureEnabled = response.ToLower() == "true";
            return isFeatureEnabled;
        }
        catch (Exception)
        {
            // Handle errors (e.g., network issues, server not available)
            // Return false to disable the feature in case of an error
            return false;
        }
    }
}
