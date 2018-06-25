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
    [Route("mls")]
    public class MLSController
    {
       private readonly Context context_;
        private static readonly HttpClient client_ = new HttpClient();

        public MLSController(Context context)
        {
            context_ = context;
            
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
        public async void subscribe(string id,[FromBody] ttt callbackUrl ){
            
            var callString = callbackUrl.id;
            

            var response = client_.PostAsync(callString,new StringContent("{\"info\":\"The info is this.\"}", Encoding.UTF8, "application/json"));
            var msg = await response;
        }
    }
}