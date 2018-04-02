using System;
namespace MBR.Models
{
    public class EmployeeCallbackURL
    {
        public EmployeeCallbackURL()
        {
        }
        public EmployeeCallbackURL(string ap, string cal)
        {
            applicationId = ap;
            callBackId = cal;
        }
        public string id { set; get; }
        public string applicationId { set; get; }
        public string callBackId { set; get; }
    }
}
