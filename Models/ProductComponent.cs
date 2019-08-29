using System;
using System.Collections.Generic;
using System.Text;

namespace ChargifyAPI.Models
{


	public class ProductComponentGrouping
	{
		public ProductComponent component { get; set; }
	}

	public class ProductComponent
	{
		public int id { get; set; }
		public string name { get; set; }
		public string handle { get; set; }
		public string pricing_scheme { get; set; }
		public string unit_name { get; set; }
		public string unit_price { get; set; }
		public int product_family_id { get; set; }
		public object price_per_unit_in_cents { get; set; }
		public string kind { get; set; }
		public bool archived { get; set; }
		public bool taxable { get; set; }
		public string description { get; set; }
		public int default_price_point_id { get; set; }
		public List<ComponentPrice> prices { get; set; }
		public int price_point_count { get; set; }
		public string price_points_url { get; set; }
		public string tax_code { get; set; }
	}

	public class ComponentPrice
	{
		public int id { get; set; }
		public int component_id { get; set; }
		public int? starting_quantity { get; set; }
		public int? ending_quantity { get; set; }
		public double? unit_price { get; set; }
		public int price_point_id { get; set; }
		public string formatted_unit_price { get; set; }
	}

}
