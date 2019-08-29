using System;
using System.Collections.Generic;
using System.Text;

namespace ChargifyAPI.Models
{
	public class SubscriptionMigrationReq
	{
		public Migration migration { get; set; }
	}

	public class Migration
	{
		public string product_handle { get; set; }
		public int product_id { get; set; }

		public string product_price_point_handle { get; set; }
		public int product_price_point_id { get; set; }

		public bool include_trial { get; set; } = false;
		public bool include_initial_charge { get; set; }
		public bool include_coupons { get; set; }
		public bool preserve_period { get; set; } = true;

		/// <summary>
		/// The list of components to enable/disable on the subscription, along with their various price points.
		/// </summary>
		public List<Component> components { get; set; } = new List<Component>();
	}

}
