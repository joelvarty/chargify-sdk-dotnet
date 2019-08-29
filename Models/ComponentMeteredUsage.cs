using System;
using System.Collections.Generic;
using System.Text;

namespace ChargifyAPI.Models
{
	
	public class MeteredUsageGroup
	{
		public ComponentMeteredUsage usage { get; set; }
	}

	public class ComponentMeteredUsage
	{
		public int id { get; set; }
		public string memo { get; set; }
		public DateTime created_at { get; set; }
		public int price_point_id { get; set; }
		public double quantity { get; set; }
		public int component_id { get; set; }
		public string component_handle { get; set; }
		public int subscription_id { get; set; }
	}

}
