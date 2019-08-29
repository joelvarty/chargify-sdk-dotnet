
using System.Collections.Generic;

namespace ChargifyAPI.Models
{
	public class ProductPricePointGroup
	{
		public List<ProductPricePoint> price_points;
	}
	public class ProductPricePoint
	{
		public string name;
		public string handle;
		public int price_in_cents;
		public int interval;
		public string interval_unit;
		public int? trial_price_in_cents;
		public int? trial_interval;
		public string trial_interval_unit;
		public string trial_type;
		public int? initial_charge_in_cents;


		public bool? initial_charge_after_trial;
		public int? expiration_interval;
		public string expiration_interval_unit;


	}
}