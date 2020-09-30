using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AuditManagementPortalMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace AuditManagementPortalMVC.Controllers
{
    public class ChecklistController : Controller
    {
        Uri baseAddress;   //44344
        HttpClient client;
        IConfiguration config;
        
        public ChecklistController(IConfiguration _config)
        {
            config = _config;
            baseAddress = new Uri(config["Links:Checklist"]);
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        public List<ChecklistQuestions> Index(string auditType,string Token)      //Chnage Here
        {
            List<ChecklistQuestions> listOfQuestions = new List<ChecklistQuestions>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/AuditChecklist/"+ auditType).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listOfQuestions = JsonConvert.DeserializeObject<List<ChecklistQuestions>>(data);
            }
            return listOfQuestions;
        }
    }
}