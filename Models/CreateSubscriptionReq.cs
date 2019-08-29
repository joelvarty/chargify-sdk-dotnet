using System;
using System.Collections.Generic;
using System.Text;

namespace ChargifyAPI.Models
{
	public class CreateSubscriptionReq
	{
		public SubscriptionReq subscription { get; set; }
	}

	public class SubscriptionReq
	{
		/// <summary>
		/// This is required if the product_id is not provided.
		/// </summary>
		public string product_handle { get; set; }

		/// <summary>
		/// This is required if the product_handle is not provided.
		/// </summary>
		public int? product_id { get; set; }

		/// <summary>
		/// The Customer to create the Subscription for, required unless the customer id is known.
		/// </summary>
		public CustomerAttributes customer_attributes { get; set; }

		/// <summary>
		/// The Chargify customer if - required unless the customer_attributes are set.
		/// </summary>
		public int? customer_id { get; set;  }

		/// <summary>
		/// The Credit Card Attributes - only required for a paid subscription.
		/// </summary>
		public CreditCardAttributes credit_card_attributes { get; set; }

		/// <summary>
		/// The list of components to enable/disable on the subscription, along with their various price points.
		/// </summary>
		public List<Component> components { get; set; } = new List<Component>();
	}

	

	public class CustomerAttributes
	{
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string email { get; set; }
	}

	public class CreditCardAttributes
	{
		public string chargify_token { get; set; }
	}

}
