using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using MBR.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using unirest_net.http;
namespace MBR.Controllers
{
    [Route("broker")]
    public class BrokerController
    {
        private readonly Context context_;
        private static readonly HttpClient client_ = new HttpClient();

        public BrokerController(Context context)
        {
            context_ = context;
        }

        [HttpPut("applyformortgage")]
        public IActionResult applyForMortgage([FromBody] BrokerCustomer e){
            dynamic result;
            if(e == null){
                result = new JObject();
                result.error = "Could not find person in databse.";
                return new ObjectResult(result);
            }
            context_.brokerCustomers.Add(e);
            context_.SaveChanges();

            var values = new Dictionary<string, string>
            {
                {"id",e.ID}
            };
            
            foreach (KeyValuePair<string, string> kvp in values)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

            HttpResponse<String> jsonResponse = Unirest.post("https://prod-22.canadaeast.logic.azure.com:443/workflows/6663b6167d0f44b782fb91167859c27b/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=Le5JWoPAlnfsOO_7Ub3wE2iL3XJb2gDg4ExElRfJ6qo")
                  .header("accept", "application/json")
                  .field("id", e.ID)
                  .asJson<String>();
            result = new JObject();
            result.id = e.ID;
            return new ObjectResult( result);
        }
        [HttpGet("getapplication/{id}")]
        public IActionResult getApplication(string id){
            BrokerCustomer b = context_.brokerCustomers.FirstOrDefault(e => e.ID == id);
            if(b==null){
                dynamic result = new JObject();
                result.error = "Could not find person in database.";
                return new ObjectResult(result);
            }
            return new ObjectResult(b);
        }
        [HttpGet("applications")]
        public IEnumerable<BrokerCustomer> getApplications(){
            var result = new List<BrokerCustomer>();
            foreach (BrokerCustomer e in context_.brokerCustomers)
            {
                result.Add(e);
            }
            return result;
        }
        [HttpGet("clearall")]
        public void clearAll(){
            foreach(BrokerCustomer b in context_.brokerCustomers){
                context_.brokerCustomers.Remove(b);
            }
            context_.SaveChanges();
        }

        [HttpGet("addEmployer/{applicationId}")]
        public IActionResult addEmployer(string applicationId){
            BrokerCustomer b = context_.brokerCustomers.FirstOrDefault(d => d.ID == applicationId);
            dynamic result = new JObject();
            if (b == null)
            {
                result.error = "Could not find person in database.";
                return new ObjectResult(result);
            }

            context_.brokerCustomers.Update(b);
            b.employerApproved = true;
            context_.Update(b);
            context_.SaveChanges();
            result.added = "true";
            return new ObjectResult(b);
        }

        [HttpGet("addinsurance/{id}")]
        public IActionResult addInsurance(string id)
        {
            BrokerCustomer b = context_.brokerCustomers.FirstOrDefault(e => e.ID == id);
            dynamic result = new JObject();
            if (b == null)
            {
                result.error = "Could not find person in database.";
                return new ObjectResult(result);
            }
            b.insuranceApproved = true;
            context_.Update(b);
            context_.SaveChanges();

            result.added = "true";
            return new ObjectResult(result);
        }
    }
}
