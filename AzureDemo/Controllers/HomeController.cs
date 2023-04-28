using AzureDemo.Models;
using DATALAYER.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SERVICELAYER.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDemo.Controllers
{
    public class HomeController : Controller
    {
        IUserServices userServices;
        public HomeController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            int loginresult = userServices.login(user.Username, user.Password);
            if(loginresult == 0)
            {
                return View();
            }
            else
            {
                HttpContext.Session.SetInt32("UserId", userServices.getSessionValue(user.Username, user.Password));
                return RedirectToAction("Home", "Home");
            }
           
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            int registerresult = userServices.Register(user);
            if (registerresult == 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "Home");
            }
        }
        [HttpGet]
        public IActionResult Home()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                var userspecifiedcred = userServices.GetStoreCredentials(HttpContext.Session.GetInt32("UserId").GetValueOrDefault());
                return View(userspecifiedcred);
            }
            return RedirectToAction("login", "Home");

        }
        [HttpPost]
        public IActionResult Home(UserStoredCredential credentials)
        {

            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                credentials.UserId = HttpContext.Session.GetInt32("UserId");
                userServices.StoreCredentials(credentials);
                return RedirectToAction("home", "Home");
            }
            return RedirectToAction("home", "Home");
        }
       
        [HttpPost]
        public IActionResult Edit(UserStoredCredential credentials)
        {

            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                credentials.Website = userServices.GetStoredCredential(credentials.Id);
                userServices.UpdateCredentials(credentials,credentials.Id);
                return RedirectToAction("home", "Home");
            }
            return RedirectToAction("home", "Home");
        }
        
        [HttpPost]
        public IActionResult Delete(UserStoredCredential credentials)
        {

            if (HttpContext.Session.GetInt32("UserId") != null)
            {
               
                userServices.DeleteCredentials(credentials.Id);
                return RedirectToAction("home", "Home");
            }
            return RedirectToAction("home", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
