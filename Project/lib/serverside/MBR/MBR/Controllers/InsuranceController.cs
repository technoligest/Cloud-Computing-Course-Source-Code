using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using unirest_net.http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using MBR.Models;namespace MBR.Controllers
{
    [Route("insurance")]
    public class InsuranceController
    {
        private readonly Context context_;
        private static readonly HttpClient client = new HttpClient();

        public InsuranceController(Context context)
        {
            context_ = context;
            
        }
        

        // [HttpPut("addCustomer")]
        // public IActionResult addCustomer([FromBody] InsuranceCustomer e)
        // {
        //    if (e == null)
        //    {
        //        dynamic result = new JObject();
        //        result.error = "Could not add customer.";
        //        return new ObjectResult(result);
        //    }
        //    context_.insuranceCustomers.Add(e);
        //    context_.SaveChanges();
        //    return new ObjectResult(e);
        // }

        // [HttpGet("signin/{id}")]
        // public IActionResult signin(string id)
        // {
        //    var e = context_.insuranceCustomers.FirstOrDefault(t => t.id == id);
        //    Console.WriteLine(id);
        //    if (e == null)
        //    {
        //        dynamic result = new JObject();
        //        result.error = "Could not find person in databse.";
        //        return new ObjectResult(result);
        //    }
        //    return new ObjectResult(e);
        // }
       
        

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


        public class ttt
        {
           public ttt()
           {
           }
           public ttt(string i)
           {
               id = i;
           }

           public string id { set; get; }
        }

        [HttpPost("subscribe/{id}")]
        public async Task<IActionResult> subscribe(string id,[FromBody] ttt callbackUrl){
           var callString = callbackUrl.id;
            

            var response = client.PostAsync(callString,new StringContent("{\"info\":\"The info is this.\"}", Encoding.UTF8, "application/json"));
            var msg = await response;
            
           return new ObjectResult("success");
        }
    }
}
