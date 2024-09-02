using Microsoft.AspNetCore.Mvc;

namespace WebApplication_EducationProject.Controllers
{
    public class AdminController1 : Controller
    {
        [Route("/foradmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
