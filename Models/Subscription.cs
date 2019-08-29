using System;
using System.Collections.Generic;
using System.Text;

namespace ChargifyAPI.Models
{

	public class SubscriptionGrouping
	{
		public Subscription subscription { get; set; }
	}

	public class Subscription
	{
		public int id { get; set; }
		public string state { get; set; }
		public int? balance_in_cents { get; set; }
		public int? current_billing_amount_in_cents { get; set; }
		public int? total_revenue_in_cents { get; set; }
		public int? product_price_in_cents { get; set; }
		public int? product_version_number { get; set; }
		public DateTime? current_period_ends_at { get; set; }
		public DateTime? next_assessment_at { get; set; }
		public object trial_started_at { get; set; }
		public object trial_ended_at { get; set; }
		public DateTime? activated_at { get; set; }
		public object expires_at { get; set; }
		public DateTime? created_at { get; set; }
		public DateTime? updated_at { get; set; }
		public string cancellation_message { get; set; }
		public string cancellation_method { get; set; }
		public bool? cancel_at_end_of_period { get; set; }
		public DateTime? canceled_at { get; set; }
		public DateTime? current_period_started_at { get; set; }
		public string previous_state { get; set; }
		public int signup_payment_id { get; set; }
		public string signup_revenue { get; set; }
		public object delayed_cancel_at { get; set; }
		public string coupon_code { get; set; }
		public string payment_collection_method { get; set; }
		public string snap_day { get; set; }
		public string reason_code { get; set; }
		public bool? receives_invoice_emails { get; set; }
		public SubscriptionCustomer customer { get; set; }
		public SubscriptionProduct product { get; set; }
		public CreditCard credit_card { get; set; }
		public string payment_type { get; set; }
		public string referral_code { get; set; }
		public string next_product_id { get; set; }
		public int? coupon_use_count { get; set; }
		public int? coupon_uses_allowed { get; set; }
	}


	public class SubscriptionCustomer
	{
		public int id { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string organization { get; set; }
		public string email { get; set; }
		public DateTime created_at { get; set; }
		public DateTime updated_at { get; set; }
		public object reference { get; set; }
		public string address { get; set; }
		public string address_2 { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string zip { get; set; }
		public string country { get; set; }
		public string phone { get; set; }
		public object portal_invite_last_sent_at { get; set; }
		public object portal_invite_last_accepted_at { get; set; }
		public bool verified { get; set; }
		public object portal_customer_created_at { get; set; }
		public object vat_number { get; set; }
		public object cc_emails { get; set; }
		public bool tax_exempt { get; set; }
		public object parent_id { get; set; }
	}

	public class SubscriptionProduct
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
		public SubscriptionProductFamily product_family { get; set; }
		public PublicSignupPage[] public_signup_pages { get; set; }
	}

	public class SubscriptionProductFamily
	{
		public int id { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public string handle { get; set; }
		public object accounting_code { get; set; }
	}
}
