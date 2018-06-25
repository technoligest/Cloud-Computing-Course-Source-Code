using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using MBR.Models;namespace MBR.Controllers
{
    [Route("insurance")]
    public class InsuranceController
    {
        private readonly Context context_;

        public InsuranceController(Context context)
        {
            context_ = context;
        }

        [HttpPut("addCustomer")]
        public IActionResult addCustomer([FromBody] InsuranceCustomer e)
        {
            if (e == null)
            {
                dynamic result = new JObject();
                result.error = "Could not add employee.";
                return new ObjectResult(result);
            }
            context_.insuranceCustomers.Add(e);
            context_.SaveChanges();
            return new ObjectResult(e);
        }

        [HttpGet("signin/{id}")]
        public IActionResult signin(string id)
        {
            var e = context_.insuranceCustomers.FirstOrDefault(t => t.id == id);
            if (e == null)
            {
                dynamic result = new JObject();
                result.error = "Could not find person in databse.";
                return new ObjectResult(result);
            }
            return new ObjectResult(e);
        }
        [HttpGet("customers")]
        public IEnumerable<InsuranceCustomer> getEmployees()
        {
            var result = new List<InsuranceCustomer>();
            foreach (InsuranceCustomer e in context_.insuranceCustomers)
            {
                result.Add(e);
            }
            return result;
        }

        [HttpGet("clearall")]
        public void clearall(string id)
        {
            foreach (InsuranceCustomer e in context_.insuranceCustomers)
            {
                context_.insuranceCustomers.Remove(e);
            }
            context_.SaveChanges();
        }
        [HttpGet("agree/{id}")]
        public IActionResult agree(string id){
            var url = context_.insuranceUrls.FirstOrDefault(s => s.applicationId == id);
            dynamic result;
            if(url == null){
                result = new JObject();
                result.error = "Could not find Application in databse.";
                return new ObjectResult(result);
            }
            //TODO call the logic app.
            result = new JObject();
            result.success = "You have agreed.";
            return new ObjectResult(result);
        }

        [HttpPut("subscribe/{id}")]
        public IActionResult subscribe([FromBody] string url, string id){
            context_.insuranceUrls.Add(new InsuranceCallbackURL(id, url));
            context_.SaveChanges();
            return new ObjectResult("success");
        }
    }
}
