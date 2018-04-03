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
        public string MLS_Id { set; get; }
        public int value { set; get;}

        public bool employerApproved { set; get; }
        public bool insuranceApproved { set; get; }
    }
}
