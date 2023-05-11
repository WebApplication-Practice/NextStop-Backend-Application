using Microsoft.AspNetCore.Mvc;
using TravelApp.DAL;

namespace TravelApp.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        TravelAppRepository repos = new TravelAppRepository();

        [HttpGet]
        public JsonResult GetPackages()
        {
            try
            {
                var packageList = repos.DisplayAllPackages();
                return Json(packageList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        public string Test()
        {
            return "App is Running..";
        }

    }
}
