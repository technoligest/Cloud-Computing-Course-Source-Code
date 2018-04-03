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

            //HttpResponse<String> jsonResponse = Unirest.post("https://prod-22.canadaeast.logic.azure.com:443/workflows/6663b6167d0f44b782fb91167859c27b/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=Le5JWoPAlnfsOO_7Ub3wE2iL3XJb2gDg4ExElRfJ6qo")
                  //.header("accept", "application/json")
                  //.field("id", e.ID)
                  //.asJson<String>();
            return new ObjectResult("{\"success\":\"The appraisal application was added.\"}");

		}

    }

}

