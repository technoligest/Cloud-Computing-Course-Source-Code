using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using MBR.Models;
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

        [HttpPut("addEmployee")]
        public IActionResult addEmployee([FromBody] Employee e)
        {
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
        public IEnumerable<Employee> getEmployees(){
            var result = new List<Employee>();
            foreach (Employee e in context_.employerEmployees)
            {
                result.Add(e);
            }
            return result;
        }

        [HttpGet("getEmployee/{id}")]
        public IActionResult getEmployee(string id){
            Employee e = context_.employerEmployees.FirstOrDefault(t => t.id == id);
            if (e == null)
            {
                dynamic result = new JObject();
                result.error = "Could not find person in databse.";
                return new ObjectResult(result);
            }
            return new ObjectResult(e);   
        }

        [HttpGet("clearall")]
        public void clearall(string id)
        {
            foreach(Employee e in context_.employerEmployees){
                context_.employerEmployees.Remove(e);
            }
            context_.SaveChanges();
        }

        [HttpGet("agree/{id}")]
        public IActionResult agree(string id)
        {
            var url = context_.insuranceUrls.FirstOrDefault(s => s.applicationId == id);
            dynamic result;
            if (url == null)
            {
                result = new JObject();
                result.error = "Could not find Application in databse.";
                return new ObjectResult(result);
            }
            //TODO call the logic app.
            result = new JObject();
            result.success = "You have agreed.";
            return new ObjectResult(result);
        }

        [HttpPost("subscribe/{id}")]
        public void subscribe(string id, [FromBody]string callbackUrl){
            context_.employeeUrls.Add(new EmployeeCallbackURL(id, callbackUrl));
            context_.SaveChanges();
        }
    }
}
