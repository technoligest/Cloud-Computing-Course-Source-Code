using System;
namespace MBR.Models
{
    public class BrokerEmployee
    {
        public string id { set; get; }
        public string name { set; get; }
        public string position { set; get; }
        public long years { set; get; }
        public long salary { set; get; }
        public BrokerEmployee()
        {
        }
        public BrokerEmployee(string id_, string name_, string position_, long years_, long salary_)
        {
            id = id_;
            name = name_;
            position = position_;
            years = years_;
            salary = salary_;
        }
    }
}
