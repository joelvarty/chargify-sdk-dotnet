using System;
using System.Collections.Generic;
using System.Text;

namespace ChargifyAPI.Models
{
	public class ProductFamilyGroup
	{
		public ProductFamily product_family;
	}
	public class ProductFamily
	{

		public int id { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public string handle { get; set; }
		public object accounting_code { get; set; }
	}

}
