using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfectPolicyFrontEnd.Models;
using PerfectPolicyFrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PerfectPolicyFrontEnd.Controllers
{
    public class CompanyController : Controller
    {
        [HttpPost]
        public IActionResult Filter(IFormCollection collection)
        {
            var result = collection["companyDDL"].ToString();
            return RedirectToAction("Index", new { filter = result });
        }

        [HttpPost]
        public IActionResult CompanyName(Company compInfo)
        {
            string temp = "";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44379/api/");

                var response = client.PostAsJsonAsync("UserInput" ,compInfo).Result;

                if (response.IsSuccessStatusCode)
                {
                    // logged in
                    temp = response.Content.ReadAsStringAsync().Result;
                    // Retrieve filter text
                    // Store the token in the session
                    HttpContext.Session.SetString("CompName", temp);
                }
                else
                {
                    // there was an issue logging in
                    ViewBag.Error = "The provided credentials were incorrect";
                    // potentially save a message to ViewBag and render in the view
                    return View();
                }
            }
            return RedirectToAction("Index", "Quiz");
        }
    }
}
