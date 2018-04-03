using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using unirest_net.http;

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

        //[HttpPut("addCustomer")]
        //public IActionResult addCustomer([FromBody] InsuranceCustomer e)
        //{
        //    if (e == null)
        //    {
        //        dynamic result = new JObject();
        //        result.error = "Could not add customer.";
        //        return new ObjectResult(result);
        //    }
        //    context_.insuranceCustomers.Add(e);
        //    context_.SaveChanges();
        //    return new ObjectResult(e);
        //}

        //[HttpGet("signin/{id}")]
        //public IActionResult signin(string id)
        //{
        //    var e = context_.insuranceCustomers.FirstOrDefault(t => t.id == id);
        //    Console.WriteLine(id);
        //    if (e == null)
        //    {
        //        dynamic result = new JObject();
        //        result.error = "Could not find person in databse.";
        //        return new ObjectResult(result);
        //    }
        //    return new ObjectResult(e);
        //}
        //[HttpGet("customers")]
        //public IEnumerable<InsuranceCustomer> getEmployees()
        //{
        //    var result = new List<InsuranceCustomer>();
        //    foreach (InsuranceCustomer e in context_.insuranceCustomers)
        //    {
        //        result.Add(e);
        //    }
        //    return result;
        //}

        //[HttpGet("clearall")]
        //public void clearall(string id)
        //{
        //    foreach (InsuranceCustomer e in context_.insuranceCustomers)
        //    {
        //        context_.insuranceCustomers.Remove(e);
        //    }
        //    context_.SaveChanges();
        //}

        //[HttpGet("agree/{id}")]
        //public IActionResult agree(string id)
        //{
        //    var url = context_.insuranceUrls.FirstOrDefault(s => s.applicationId == id);
        //    dynamic result;
        //    if(url == null)
        //    {
        //        result = new JObject();
        //        result.error = "Could not find Application in databse.";
        //        return new ObjectResult(result);
        //    }

        //    HttpResponse<String> jsonResponse = Unirest.post(url.callBackUrl)
        //    .header("accept", "application/json")
        //    .asJson<String>();
        //    result = new JObject();
        //    result.success = "You have agreed.";
        //    return new ObjectResult(result);
        //}


        //public class ttt
        //{
        //    public ttt()
        //    {
        //    }
        //    public ttt(string i)
        //    {
        //        id = i;
        //    }

        //    public string id { set; get; }
        //}

        //[HttpPost("subscribe/{id}")]
        //public IActionResult subscribe(string id,[FromBody] ttt callbackUrl){
        //    context_.insuranceUrls.Add(new InsuranceCallbackURL(id, callbackUrl.id));
        //    context_.SaveChanges();
        //    return new ObjectResult("success");
        //}

        //[HttpGet("getUrls")]
        //public IEnumerable<InsuranceCallbackURL> urls()
        //{
        //    var result = new List<InsuranceCallbackURL>();
        //    foreach (var v in context_.insuranceUrls)
        //    {
        //        result.Add(v);
        //    }
        //    return result;
        //}
        //[HttpGet("removeurls")]
        //public void removaAllUrls()
        //{
        //    foreach (var v in context_.insuranceUrls)
        //    {
        //        context_.insuranceUrls.Remove(v);
        //    }
        //    context_.SaveChanges();
        //}

    }
}
