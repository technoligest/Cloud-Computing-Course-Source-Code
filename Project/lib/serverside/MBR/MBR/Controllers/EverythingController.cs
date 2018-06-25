using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using MBR.Models;

namespace MBR.Controllers
{
    [Route("v1")]
    public class EverythingController
    {  
        public EverythingController()
        {
        }
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "What are you.";
        }
    }
}
