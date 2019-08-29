using System;
using System.Collections.Generic;
using System.Text;

namespace ChargifyAPI.Models
{
	public class BillingPortalResponse
	{
	
		public string url { get; set; }
		public int fetch_count { get; set; }
		public DateTime created_at { get; set; }
		public DateTime new_link_available_at { get; set; }
		public DateTime expires_at { get; set; }
	}

}
