using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;
using ServiceContracts;
using Services;
using Entitites;
using System.Reflection.Metadata;

namespace WebApplicationEdu.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private IAccountService _accountService;
        private static Account _accountHasAccess;

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

 /*       [HttpPost]
        [Route("Index")]
        public IActionResult Index(AccountAddRequest? accountAddRequest)
        {
              if(ViewBag.Title == "Login")
              {
                  try
                  {
                      _accountService.LoginAccount(accountAddRequest);
                      _accountHasAccess = accountAddRequest.ToAccount();

                      return View("IndexLoginAccess", "Home");
                  }
                  catch (Exception? ex)
                  {
                    return View(ex);
                  }
              }
              if(ViewBag.Title == "Signup")
              {
                  try
                  {
                      _accountService.SignUpAccount(accountAddRequest);
                      ViewBag.ErrorMessage = "Sign up is success! ";
                      // return View("Login", "Home"); //error vi goi post khong phai goi get
                      return View();
                  }
                  catch (Exception ex)
                  {
                      ViewBag.ErrorMessage = ex.Message;
                      return RedirectToAction("Login", "Home");
                  }
              }

            return View();
        }*/

         [HttpGet]
         [Route("IndexLoginAccess")]
         public IActionResult IndexLoginAccess()
         {
             ViewBag.AccountName = _accountHasAccess.accountName;
             return View();
         }

        /*
         [HttpPost]
         public IActionResult Login(Exception? ex)
         {
             ViewBag.ErrorMessage = ex.Message;
             return View();

         }

         [HttpGet]
         public IActionResult Signup(Exception? ex)
         {
             ViewBag.ErrorMessage = ex.Message;
             return View();
         }

         */
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
                _accountHasAccess = accountAddRequest.ToAccount();

                
                return RedirectToAction("IndexLoginAccess", "Home");


            }
            catch (Exception? ex)
            {
                ViewBag.ErrorMessage = ex.Message;
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
                ViewBag.ErrorMessage = "Sign up is success! ";
                // return View("Login", "Home"); //error vi goi post khong phai goi get
                return View("IndexLoginAccess", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
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
