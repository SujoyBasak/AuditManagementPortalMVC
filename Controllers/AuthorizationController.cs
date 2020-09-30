using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AuditManagementPortalMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AuditManagementPortalMVC.Controllers
{
    public class AuthorizationController : Controller
    {
        Uri baseAddress;       //44311
        HttpClient client;
        AuditContext context;
        IConfiguration config;
        public AuthorizationController(AuditContext _context,IConfiguration _config)
        {
            config = _config;
            baseAddress = new Uri(config["Links:Auth"]);
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            context = _context;

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
            ViewBag.Message = "Invalid Name or Password";
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
            ChecklistController objOfChecklistController = new ChecklistController(config);
            List<ChecklistQuestions> listOfQuestions = new List<ChecklistQuestions>();
            listOfQuestions = objOfChecklistController.Index(audittype.Type,Token);       
            return View(listOfQuestions);
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
        public IActionResult Severity(AuditRequest request)
        {
            string Token = HttpContext.Request.Cookies["Token"];
            if (string.IsNullOrEmpty(Token))
            {
                ViewBag.Message = "Please Login";
                return View("Login");
            }
            if (request.Auditdetails.Type == "Internal")
                return RedirectToAction("Internal");    
            else if (request.Auditdetails.Type == "SOX")
                return RedirectToAction("SOX");
            return View();

            
        }
        [HttpGet]
        public IActionResult Internal()
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
            SeverityController objofSeverityController = new SeverityController(config);
            AuditResponse auditResponse = new AuditResponse();
            auditResponse = objofSeverityController.Index(questions,Token);

            Storage obj = new Storage();
            obj.add(auditResponse);
            context.AuditResponse.Add(auditResponse);
            context.SaveChanges();

            return View(auditResponse);
            
        }
        public IActionResult History()
        {
            string Token = HttpContext.Request.Cookies["Token"];
            if (string.IsNullOrEmpty(Token))
            {
                ViewBag.Message = "Please Login";
                return View("Login");
            }
            Storage objOfStorage = new Storage();
            List<AuditResponse> listOfResponse = new List<AuditResponse>();
            listOfResponse = objOfStorage.returnBack();
            return View(listOfResponse);
        }
        

        [HttpGet]
        public IActionResult SOX()
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
            SeverityController objofSeverityController = new SeverityController(config);
            AuditResponse auditResponse = new AuditResponse();
            auditResponse = objofSeverityController.Index1(questions,Token);

            Storage objOfStorage = new Storage();
            objOfStorage.add(auditResponse);
            context.AuditResponse.Add(auditResponse);
            context.SaveChanges();

            return View(auditResponse);

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