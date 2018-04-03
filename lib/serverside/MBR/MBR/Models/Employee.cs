using System;
using Microsoft.EntityFrameworkCore;

namespace MBR.Models
{
    public class Employee
    {
        public string id { set; get; }
        public string employeeId { set; get; }
        public string name { set; get; }
        public string position { set; get; }
        public long years { set; get; }
        public long salary { set; get; }

        public Employee()
        {
        }
        public Employee(string id_, string name_, string position_, long years_, long salary_){
            employeeId = id_;
            name = name_;
            position = position_;
            years = years_;
            salary = salary_;
        }
    }
}
