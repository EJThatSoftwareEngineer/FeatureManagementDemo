using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FeatureManagementLibraryTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleAPIController : ControllerBase
    {
        [Route("GetBoolean")]
        public string GetBoolean()
        {
            return GenerateRandomBoolean().ToString().ToLower();
        }

        private bool GenerateRandomBoolean()
        {
            Random _random = new Random();
            // Generate a random number between 0 and 1
            double randomNumber = _random.NextDouble();
            // If the random number is less than 0.75, return true, else return false
            return randomNumber < 0.75;
        }

    }
}
