using System;
namespace MBR.Models
{
    public class RealEstateCallbackURL
    {
        public RealEstateCallbackURL()
        {
        }
        public RealEstateCallbackURL(string m1,string m2, string urll){
            MLS_Id = m1;
            MortId = m2;
            urlString = urll;
        }
        public string id { set; get; }
        public string MLS_Id { set; get; }
        public string MortId { set; get; }
        public string urlString { set; get; }
    }
}
