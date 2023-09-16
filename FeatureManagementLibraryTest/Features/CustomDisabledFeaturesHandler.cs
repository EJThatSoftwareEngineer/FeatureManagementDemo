using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureManagementLibraryTest.Features
{
    public class CustomDisabledFeaturesHandler : IDisabledFeaturesHandler
    {
        public Task HandleDisabledFeatures(IEnumerable<string> features, ActionExecutingContext context)
        {
           //Log Error
           var message = $"The following features are disabled: {string.Join(", ", features)}";

            context.Result = new ContentResult()
            {   
                ContentType = "text/plain",
                Content = message,
                StatusCode = 404
            };

            return Task.CompletedTask;

        }
    }
}
