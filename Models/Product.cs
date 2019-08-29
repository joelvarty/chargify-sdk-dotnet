using System;
using System.Collections.Generic;
using System.Text;

namespace ChargifyAPI.Models
{
	public class ProductGroup
	{
		public Product product;
	}
	public class Product
	{

		public int id { get; set; }
		public string name { get; set; }
		public string handle { get; set; }
		public string description { get; set; }
		public string accounting_code { get; set; }
		public bool request_credit_card { get; set; }
		public object expiration_interval { get; set; }
		public string expiration_interval_unit { get; set; }
		public DateTime created_at { get; set; }
		public DateTime updated_at { get; set; }
		public int price_in_cents { get; set; }
		public int interval { get; set; }
		public string interval_unit { get; set; }
		public object initial_charge_in_cents { get; set; }
		public object trial_price_in_cents { get; set; }
		public object trial_interval { get; set; }
		public string trial_interval_unit { get; set; }
		public object archived_at { get; set; }
		public bool require_credit_card { get; set; }
		public string return_params { get; set; }
		public bool taxable { get; set; }
		public string update_return_url { get; set; }
		public string tax_code { get; set; }
		public bool initial_charge_after_trial { get; set; }
		public int version_number { get; set; }
		public string update_return_params { get; set; }
		public int default_product_price_point_id { get; set; }
		public int product_price_point_id { get; set; }
		public string product_price_point_handle { get; set; }
		public ProductFamily product_family { get; set; }
		public IList<PublicSignupPage> public_signup_pages { get; set; }
	}

}
