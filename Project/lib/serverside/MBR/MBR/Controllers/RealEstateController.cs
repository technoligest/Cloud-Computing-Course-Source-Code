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
using System.Text;
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
		public async Task<IActionResult> applyForAppraisal([FromBody] RealEstate r){
			dynamic result;
			if(r==null){
				result = new JObject();
                result.error = "Could not add real estate application.";
                return new ObjectResult(result);
			}
			context_.realEstates.Add(r);
			context_.SaveChanges();
            var url = context_.realEstateCallbackURLs.FirstOrDefault(s => s.MLS_Id == r.MLS_Id && s.MortId == r.MortId);
            var callString = url.urlString;

            var stringTask = client_.PostAsync(callString, new StringContent("", Encoding.UTF8, "application/json"));

            var msg = await stringTask;

            //HttpResponse<String> jsonResponse = Unirest.post("https://prod-22.canadaeast.logic.azure.com:443/workflows/6663b6167d0f44b782fb91167859c27b/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=Le5JWoPAlnfsOO_7Ub3wE2iL3XJb2gDg4ExElRfJ6qo")
                  //.header("accept", "application/json")
                  //.field("id", e.ID)
                  //.asJson<String>();
            return new ObjectResult("{\"success\":\"The appraisal application was added.\"}");

		}
         //wrapper class to allow us to accept input.
        //completely useless, but couldn't figure out a way around it.
        public class ttt
        {
            public ttt(){
            }
            public ttt(string i, string i2, string i3)
            {
                callback = i;
                mortId = i2;
                mls = i3;
            }
        
            public string callback { set; get; }
            public string mortId{set;get;}
            public string mls{set;get;}
        }
        [HttpPost("subscribe")]
        public void subscribe(string id,[FromBody] ttt callbackUrl ){
            context_.realEstateCallbackURLs.Add(new RealEstateCallbackURL(callbackUrl.mls,callbackUrl.mortId, callbackUrl.callback));
            context_.SaveChanges();
        }

    }

}

