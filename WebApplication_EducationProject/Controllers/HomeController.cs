using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;
using ServiceContracts;
using Services;
using Entitites;
using System.Reflection.Metadata;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApplicationEdu.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private IAccountService _accountService;
        private static string _accountName;

        public HomeController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("/")]
        [Route("Index")]
        public IActionResult Index()
        {
            
            return View();
        }


         [HttpGet]
         [Route("IndexLoginAccess/{accountId}")]
         public IActionResult IndexLoginAccess()
         {
            
             ViewBag.AccountName = _accountName;
             return View();
         }

       
        [HttpGet]
        [Route("Signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(AccountAddRequest? accountAddRequest)
        {
            try
            {
                _accountService.LoginAccount(accountAddRequest);
                _accountName = _accountService.GetNameAccount();

                Guid accountId = _accountService.LogInAccountId();

               
                return RedirectToAction("IndexLoginAccess",  new { accountId });


            }
            catch (Exception? ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }





        [HttpPost]
        [Route("Signup")]
        public IActionResult Signup(AccountAddRequest? accountAddRequest)
        {

            try
            {
                _accountService.SignUpAccount(accountAddRequest);
                ViewBag.Message = "Sign up is success! ";
                // return View("Login", "Home"); //error vi goi post khong phai goi get
                return View("Login");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }




        }

        [HttpGet]
        [Route("Course")]
        public IActionResult Course() 
        {
            return View();
        }
    }
}
