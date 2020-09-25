using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AuditManagementPortalMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuditManagementPortalMVC.Controllers
{
    public class AuthorizationController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44311/api");   //Port No.
        HttpClient client;

        public AuthorizationController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(Authenticate user)
        {
            string data = JsonConvert.SerializeObject(user);
            
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Token/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string Token = response.Content.ReadAsStringAsync().Result;
                HttpContext.Response.Cookies.Append("Token", Token);
                return View("Home");        

            }
            ViewBag.Message = "Wrong Credentials";
            return View("Login");
            

        }
        
        [HttpGet]
        public IActionResult Home()
        {
            string Token = HttpContext.Request.Cookies["Token"];
            if (string.IsNullOrEmpty(Token))
            {
                ViewBag.Message = "Please Login";
                return View("Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Checklist(AuditDetail audittype)
        {
            string Token = HttpContext.Request.Cookies["Token"];
            if(string.IsNullOrEmpty(Token))
            {
                ViewBag.Message = "Please Login";
                return View("Login");
            }
            ChecklistController con = new ChecklistController();
            List<ChecklistQuestions> ls = new List<ChecklistQuestions>();
            ls = con.Index(audittype.Type,Token);       // Change Here 

            return View(ls);
        }
        [HttpPost]
        public IActionResult AuditForm()
        {
            string Token = HttpContext.Request.Cookies["Token"];
            if (string.IsNullOrEmpty(Token))
            {
                ViewBag.Message = "Please Login";
                return View("Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Severity(AuditRequest req)
        {
            string Token = HttpContext.Request.Cookies["Token"];
            if (string.IsNullOrEmpty(Token))
            {
                ViewBag.Message = "Please Login";
                return View("Login");
            }
            if (req.Auditdetails.Type == "Internal")
                return RedirectToAction("Internal",req);
            else if (req.Auditdetails.Type == "SOX")
                return RedirectToAction("SOX",req);
            return View();

            
        }
        [HttpGet]
        public IActionResult Internal(AuditRequest req)
        {
            string Token = HttpContext.Request.Cookies["Token"];
            if (string.IsNullOrEmpty(Token))
            {
                ViewBag.Message = "Please Login";
                return View("Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult AuditResponseView(InternalQuestions questions)
        {
            string Token = HttpContext.Request.Cookies["Token"];
            if (string.IsNullOrEmpty(Token))
            {
                ViewBag.Message = "Please Login";
                return View("Login");
            }
            SeverityController con = new SeverityController();
            AuditResponse ls = new AuditResponse();
            ls = con.Index(questions,Token);

            return View(ls);
            
        }

        [HttpGet]
        public IActionResult SOX(AuditRequest req)
        {
            string Token = HttpContext.Request.Cookies["Token"];
            if (string.IsNullOrEmpty(Token))
            {
                ViewBag.Message = "Please Login";
                return View("Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult AuditResponseSOXView(SOXQuestions questions)
        {
            string Token = HttpContext.Request.Cookies["Token"];
            if (string.IsNullOrEmpty(Token))
            {
                ViewBag.Message = "Please Login";
                return View("Login");
            }
            SeverityController con = new SeverityController();
            AuditResponse ls = new AuditResponse();
            ls = con.Index1(questions,Token);

            return View(ls);

        }
        [HttpGet]
        public IActionResult SignOut()
        {
            string Token = HttpContext.Request.Cookies["Token"];
            if (string.IsNullOrEmpty(Token))
            {
                ViewBag.Message = "Please Login";
                return View("Login");
            }
            HttpContext.Response.Cookies.Delete("Token");
            return View("Login");
        }
    }
}