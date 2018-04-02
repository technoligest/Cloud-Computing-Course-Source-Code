using System;
namespace MBR.Models
{
    public class BrokerCustomer
    {
        public BrokerCustomer()
        {
        }
        public string ID { set; get; }
        public string name { set; get; }
        public string address { set; get; }
        public string phone { set; get; }
        public string employer { set; get; }
        public string insuranceCompany { set; get; }
        public bool employerApproved { set; get; }
        public bool insuranceApproved { set; get; }
    }
}
