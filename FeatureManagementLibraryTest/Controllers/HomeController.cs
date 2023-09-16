using FeatureManagementLibraryTest.Features;
using FeatureManagementLibraryTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System.Diagnostics;

namespace FeatureManagementLibraryTest.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IFeatureManager _featureManager;

        public HomeController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        public async Task<IActionResult> Index()
        {
            if (await _featureManager.IsEnabledAsync(nameof(FeatureManagement.FeatureA)))
            {
                return View("FeatureA");
            }

            return View();
        }

        [FeatureGate(FeatureManagement.FeatureA)]
        public async Task<IActionResult> FeatureA()
        {

            return View("FeatureA");
        }

        [FeatureGate(FeatureManagement.FeatureB)]
        public async Task<IActionResult> FeatureB()
        {
            return View("FeatureB");
        }


        [FeatureGate(FeatureManagement.FeatureC)]
        public async Task<IActionResult> FeatureC()
        {
            return View("FeatureC");
        }


        [FeatureGate(FeatureManagement.FeatureD)]
        public async Task<IActionResult> FeatureD()
        {
            return View("FeatureD");
        }

        [FeatureGate(FeatureManagement.FeatureE)]
        public async Task<IActionResult> FeatureE()
        {
            return View("FeatureE");
        }

        [FeatureGate(FeatureManagement.FeatureF)]
        public async Task<IActionResult> FeatureF()
        {
            return View("FeatureF");
        }


        [FeatureGate(RequirementType.Any, FeatureManagement.FeatureA, FeatureManagement.FeatureB , FeatureManagement.FeatureC , FeatureManagement.FeatureD , FeatureManagement.FeatureE, FeatureManagement.FeatureF)]
        public async Task<IActionResult> FeatureAll()
        {
            return View("FeatureAll");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}