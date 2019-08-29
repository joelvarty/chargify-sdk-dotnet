
using System.Collections.Generic;

namespace ChargifyAPI.Models
{
	public class ComponentPricePointGroup
	{
		public List<ComponentPricePoint> price_points;
	}
	public class ComponentPricePoint
	{
		public int id;

		// public bool default;
		public string name;
		public string handle;
		public int price_in_cents;
		public string pricing_scheme;

		public List<ComponentPrice> prices { get; set; }

	}
}