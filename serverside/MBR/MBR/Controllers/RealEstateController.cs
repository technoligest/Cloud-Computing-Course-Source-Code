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
	[Route("realestate")]
    public class RealEstateController
    {
		private readonly Context context_;
        private static readonly HttpClient client_ = new HttpClient();
		public RealEstateController(Context context)
        {
			context_ = context;
        }
		[HttpPut("applyforappraisal")]
		public IActionResult applyForAppraisal([FromBody] RealEstate r){
			dynamic result;
			if(r==null){
				result = new JObject();
                result.error = "Could not add real estate application.";
                return new ObjectResult(result);
			}
			context_.realEstates.Add(r);
			context_.SaveChanges();
			return new ObjectResult("success");
		}
    }
}
