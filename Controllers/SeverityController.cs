using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AuditManagementPortalMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuditManagementPortalMVC.Controllers
{
    public class SeverityController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44398/api");   //Port No.
        HttpClient client;

        public SeverityController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }

        public AuditResponse Index(InternalQuestions qes,string Token)
        {
            AuditResponse ar = new AuditResponse();

            AuditRequest ad = new AuditRequest()
            {
                Auditdetails = new AuditDetail()
                {
                    Type="Internal",
                    questions = new Questions()
                    {
                        Question1 = qes.Question1,
                        Question2 = qes.Question2,
                        Question3 = qes.Question3,
                        Question4 = qes.Question4,
                        Question5 = qes.Question5                        
                    }
                }
            };
            

            string data = JsonConvert.SerializeObject(ad);            
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/AuditSeverity",content).Result;
            if (response.IsSuccessStatusCode)
            {
                string res = response.Content.ReadAsStringAsync().Result;
                ar = JsonConvert.DeserializeObject<AuditResponse>(res);
            }
            return ar;
            
        }
        public AuditResponse Index1(SOXQuestions qes,string Token)
        {
            AuditResponse ar = new AuditResponse();

            AuditRequest ad = new AuditRequest()
            {
                Auditdetails = new AuditDetail()
                {
                    Type = "SOX",
                    questions = new Questions()
                    {
                        Question1 = qes.Question1,
                        Question2 = qes.Question2,
                        Question3 = qes.Question3,
                        Question4 = qes.Question4,
                        Question5 = qes.Question5
                    }
                }
            };


            string data = JsonConvert.SerializeObject(ad);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/AuditSeverity", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string res = response.Content.ReadAsStringAsync().Result;
                ar = JsonConvert.DeserializeObject<AuditResponse>(res);
            }
            return ar;

        }
    }
}