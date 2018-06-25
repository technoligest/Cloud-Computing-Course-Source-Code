using System;
namespace MBR.Models
{
    public class RealEstate
    {
        public RealEstate()
        {
        }
        public RealEstate(string m1,string m2){
            MLS_Id = m1;
            MortId = m2;
        }
		public string id { get; set; }
		public string MLS_Id { get; set; }
		public string MortId { get; set; }
    }
}
