using System;
using System.Collections.Generic;
using System.Text;

namespace ChargifyAPI.Models
{


	public class ComponentUsageResponseGroup
	{
		public ComponentUsageResponse usage { get; set; }
	}

	public class ComponentUsageResponse
	{
		public int id { get; set; }
		public string memo { get; set; }
		public DateTime created_at { get; set; }
		public int price_point_id { get; set; }
		public double quantity { get; set; }
	}

}
