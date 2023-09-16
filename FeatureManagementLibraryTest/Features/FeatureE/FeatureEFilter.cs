using Microsoft.FeatureManagement;

namespace FeatureManagementLibraryTest.Features.FeatureE
{
    [FilterAlias("FeatureE")]
    public class FeatureEFilter : IFeatureFilter
    {
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            FeatureESettings settings = context.Parameters.Get<FeatureESettings>();

            //if (settings.Method == "Even")
            //{
            //    return Task.FromResult(DateTime.Now.Ticks % 2 == 0);
            //}

            //if (settings.Method == "Odd")
            //{
            //    return Task.FromResult(DateTime.Now.Ticks % 2 == 0);
            //}

            return Task.FromResult(settings.IsEnabled);
        }
    }
}
