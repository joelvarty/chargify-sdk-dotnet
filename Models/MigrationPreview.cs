using System;
using System.Collections.Generic;
using System.Text;

namespace ChargifyAPI.Models
{
	public class MigrationPreviewResponse
	{
			public MigrationPreview migration { get; set; }
	}

	public class MigrationPreview
	{
		public int prorated_adjustment_in_cents { get; set; }
		public int charge_in_cents { get; set; }
		public int payment_due_in_cents { get; set; }
		public int credit_applied_in_cents { get; set; }
	}

}
