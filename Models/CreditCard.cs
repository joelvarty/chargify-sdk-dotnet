using System;
using System.Collections.Generic;
using System.Text;

namespace ChargifyAPI.Models
{
	public class CreditCard
	{
		public int id { get; set; }
		public string payment_type { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string masked_card_number { get; set; }
		public string card_type { get; set; }
		public int? expiration_month { get; set; }
		public int? expiration_year { get; set; }
		public string billing_address { get; set; }
		public string billing_address_2 { get; set; }
		public string billing_city { get; set; }
		public string billing_state { get; set; }
		public string billing_country { get; set; }
		public string billing_zip { get; set; }
		public string current_vault { get; set; }
		public string vault_token { get; set; }
		public object customer_vault_token { get; set; }
		public int customer_id { get; set; }
	}
}
