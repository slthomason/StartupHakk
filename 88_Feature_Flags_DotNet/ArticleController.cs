using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    [FeatureGate(FeatureFlags.EnableArticlesApi)]

    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
