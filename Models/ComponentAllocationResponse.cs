using System;
using System.Collections.Generic;
using System.Text;

namespace ChargifyAPI.Models
{

	public class ComponentAllocationResponseGroup
	{
		public ComponentAllocationResponse allocation { get; set; }
	}

	public class ComponentAllocationResponse
	{
		public int component_id { get; set; }
		public int subscription_id { get; set; }
		public double quantity { get; set; }
		public double previous_quantity { get; set; }
		public string memo { get; set; }
		public DateTime timestamp { get; set; }
		public string proration_upgrade_scheme { get; set; }
		public string proration_downgrade_scheme { get; set; }
		public int price_point_id { get; set; }
		public int previous_price_point_id { get; set; }
		public object payment { get; set; }

	}

}
