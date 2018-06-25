using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using MBR.Models;
using System.Net.Http;
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

            var content = new FormUrlEncodedContent(values);

            var response = client_.PostAsync("https://prod-22.canadaeast.logic.azure.com:443/workflows/6663b6167d0f44b782fb91167859c27b/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=Le5JWoPAlnfsOO_7Ub3wE2iL3XJb2gDg4ExElRfJ6qo", content);

            var responseString = response.Result.ToString();

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

        [HttpPut("addEmployer/{applicationId}/{employeeId}")]
        public IActionResult addEmployer(string applicationId, string employeeId){
            BrokerCustomer b = context_.brokerCustomers.FirstOrDefault(d => d.ID == applicationId);
            dynamic result = new JObject();
            if (b == null)
            {
                result.error = "Could not find person in database.";
                return new ObjectResult(result);
            }
            Employee e = context_.employerEmployees.FirstOrDefault(k => k.employeeId == employeeId);
            if (e == null)
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

        [HttpPut("addinsurance/{id}/{policyid}")]
        public IActionResult addInsurance(string id,string policyid)
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
