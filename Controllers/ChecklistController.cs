using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AuditManagementPortalMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AuditManagementPortalMVC.Controllers
{
    public class ChecklistController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44344/api");   //Port No.
        HttpClient client;

        public ChecklistController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        public List<ChecklistQuestions> Index(string auditType,string Token)      //Chnage Here
        {
            List<ChecklistQuestions> ls = new List<ChecklistQuestions>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/AuditChecklist/"+ auditType).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<List<ChecklistQuestions>>(data);
            }
            return ls;
        }
    }
}