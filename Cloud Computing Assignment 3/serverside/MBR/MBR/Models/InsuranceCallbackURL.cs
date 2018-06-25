using System;
namespace MBR.Models
{
    public class InsuranceCallbackURL
    {
        public InsuranceCallbackURL(string ap, string cal)
        {
            applicationId = ap;
            callBackUrl = cal;
        }
        public string id { set; get; }
        public string applicationId { set; get; }
        public string callBackUrl { set; get; }
    }
}
