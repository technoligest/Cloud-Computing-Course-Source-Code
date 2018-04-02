using System;
namespace MBR.Models
{
	public class InsuranceProperty
    {
		public InsuranceProperty()
        {
        }
		public string id { get; set; }
		public string MLS_Id { get; set; }
		public double insuredValue { get; set; }
		public double deductable { get; set; }
		public string clientName { get; set; }
    }
}
