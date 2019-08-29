using System;
using System.Collections.Generic;
using System.Text;

namespace ChargifyAPI.Models
{
	public class ComponentResponse
	{ 
		public Component component { get; set; }
	}

	public class Component
	{
		public const string KIND_QUANTITY_BASED = "quantity_based_component";
		public const string KIND_METERED = "metered_component";


		public int? component_id { get; set; }
		public int? subscription_id { get; set; }
		public string component_handle { get; set; }
		public double? allocated_quantity { get; set; }


		public string name { get; set; }
		public string kind { get; set; }
		public string unit_name { get; set; }
		public string pricing_scheme { get; set; }
		public int? price_point_id { get; set; }
		public string price_point_handle { get; set; }
	}


}
