using System;
using System.Collections.Generic;
using System.Text;

namespace ChargifyAPI.Models
{

	public class CustomerGrouping
	{
		public Customer customer { get; set; }
	}
	public class Customer
	{
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string email { get; set; }
		public string cc_emails { get; set; }
		public string organization { get; set; }
		public object reference { get; set; }
		public int id { get; set; }
		public DateTime? created_at { get; set; }
		public DateTime? updated_at { get; set; }
		public string address { get; set; }
		public string address_2 { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string zip { get; set; }
		public string country { get; set; }
		public string phone { get; set; }
		public bool verified { get; set; }
		public DateTime? portal_customer_created_at { get; set; }
		public DateTime? portal_invite_last_sent_at { get; set; }
		public DateTime? portal_invite_last_accepted_at { get; set; }
		public bool tax_exempt { get; set; }
		public string vat_number { get; set; }
	}
}
