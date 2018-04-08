using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using MBR.Models;
using unirest_net.http;

namespace MBR.Controllers
{
    [Route("employer")]
    public class EmployerController
    {
        private readonly Context context_;
        public EmployerController(Context context)
        {
            context_ = context;
        }
        [HttpGet("what")]
        public IActionResult what(){
            return new ObjectResult("What!");
        }
        [HttpPut("addEmployee")]
        public IActionResult addEmployee([FromBody] Employee e)
        {
            Console.WriteLine(e);
            if (e == null)
            {
                dynamic result = new JObject();
                result.error = "Could not add employee.";
                return new ObjectResult(result);
            }
            context_.employerEmployees.Add(e);
            context_.SaveChanges();
            return new ObjectResult(e);
        }

        [HttpGet("signin/{id}")]
        public IActionResult signin(string id)
        {
            Employee e = context_.employerEmployees.FirstOrDefault(t => t.employeeId == id);
            if (e == null)
            {
                dynamic result = new JObject();
                result.error = "Could not find person in database.";
                return new ObjectResult(result);
            }
            return new ObjectResult(e);
        }

        [HttpGet("getEmployees")]
        public IEnumerable<Employee> getEmployees()
        {
            var result = new List<Employee>();
            foreach (Employee e in context_.employerEmployees)
            {
                result.Add(e);
            }
            return result;
        }

        [HttpGet("getEmployee/{id}")]
        public IActionResult getEmployee(string id)
        {
            Employee e = context_.employerEmployees.FirstOrDefault(t => t.id == id);
            if (e == null)
            {
                dynamic result = new JObject();
                result.error = "Could not find person in databse.";
                return new ObjectResult(result);
            }
            return new ObjectResult(e);
        }

        //Super unsafe, but oh well.
        [HttpGet("clearall")]
        public void clearall(string id)
        {
            foreach (Employee e in context_.employerEmployees)
            {
                context_.employerEmployees.Remove(e);
            }
            context_.SaveChanges();
        }

        [HttpGet("agree/{id}")]
        public IActionResult agree(string id)
        {
            var url = context_.employeeUrls.FirstOrDefault(s => s.applicationId == id);
            dynamic result;
            if(url == null)
            {
                result = new JObject();
                result.error = "Could not find Application in databse.";
                return new ObjectResult(result);
            }
            HttpResponse<String> jsonResponse = Unirest.post(url.callBackId)
            .header("accept", "application/json")
            .asJson<String>();
            result = new JObject();
            result.success = "You have agreed.";
            return new ObjectResult(result);
        }

        //wrapper class to allow us to accept input.
        //completely useless, but couldn't figure out a way around it.
        public class ttt
        {
            public ttt(){
            }
            public ttt(string i)
            {
                id = i;
            }
        
            public string id { set; get; }
        }
        [HttpPost("subscribe/{id}")]
        public void subscribe(string id,[FromBody] ttt callbackUrl ){
            context_.employeeUrls.Add(new EmployeeCallbackURL(id, callbackUrl.id));
            context_.SaveChanges();
        }

        [HttpGet("getUrls")]
        public IEnumerable<EmployeeCallbackURL> urls(){
            var result = new List<EmployeeCallbackURL>();
            foreach(var v in context_.employeeUrls){
                result.Add(v);
            }
            return result;
        }
        [HttpGet("removeurls")]
        public void removaAllUrls(){
            foreach (var v in context_.employeeUrls)
            {
                context_.employeeUrls.Remove(v);
            }
            context_.SaveChanges();
        }


    }
}
