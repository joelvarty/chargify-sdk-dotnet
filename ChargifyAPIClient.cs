using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ChargifyAPI.Models;
using Newtonsoft.Json;

namespace ChargifyAPI
{
	public class ChargifyAPIClient
	{
		private static HttpClient _staticHttpClient;
		private readonly HttpClient _httpClient;
		private readonly string _apiKey;
		private readonly string _chargifyUrl;

		public ChargifyAPIClient(string subDomain, string apiKey)
		{
			if (_staticHttpClient == null)
			{
				_staticHttpClient = new HttpClient();
			}

			_httpClient = _staticHttpClient;
			_apiKey = apiKey;
			_chargifyUrl = $"https://{subDomain}.chargify.com";
		}

		public async Task<Subscription> CreateSubscription(CreateSubscriptionReq req)
		{
			string url = $"{_chargifyUrl}/subscriptions.json";

			using (var request = new HttpRequestMessage(HttpMethod.Post, url))
			{
				request.Content = new StringContent(
					JsonConvert.SerializeObject(req),
					Encoding.UTF8,
					"application/json"); ;

				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead))
				{
					var result = await ProcessResponse<SubscriptionGrouping>(response);
					return result?.subscription;
				}

			}
		}


		public async Task<Customer> CreateCustomer(Customer customer)
		{
			string url = $"{_chargifyUrl}/customers.json";

			var customerGrouping = new CustomerGrouping()
			{
				customer = customer
			};

			using (var request = new HttpRequestMessage(HttpMethod.Post, url))
			{
				request.Content = new StringContent(
					JsonConvert.SerializeObject(customerGrouping),
					Encoding.UTF8,
					"application/json"); ;

				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead))
				{
					var result = await ProcessResponse<CustomerGrouping>(response);
					return result?.customer;
				}
			}
		}

		public async Task<string> GetBillingPortalUrl(int customer_id)
		{
			string url = $"{_chargifyUrl}/portal/customers/{customer_id}/management_link.json";

			using (var request = new HttpRequestMessage(HttpMethod.Get, url))
			{
				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					var res = await ProcessResponse<BillingPortalResponse>(response);
					return res?.url;
				}
			}
		}

		public async Task<Subscription> GetSubscription(int subscription_id)
		{
			string url = $"{_chargifyUrl}/subscriptions/{subscription_id}.json";

			using (var request = new HttpRequestMessage(HttpMethod.Get, url))
			{
				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					var subscriptionGrouping = await ProcessResponse<SubscriptionGrouping>(response);
					return subscriptionGrouping?.subscription;
				}
			}
		}

		public async Task<Subscription> CancelSubscription(int subscription_id, string reason)
		{
			var url = $"{_chargifyUrl}/subscriptions/{subscription_id}.json";
			using (var request = new HttpRequestMessage(HttpMethod.Delete, url))
			{
				AuthorizeRequest(request);
				if (!string.IsNullOrEmpty(reason))
				{
					request.Content = new StringContent($"{{\"subscription\": {{\"cancellation_message\": \"{reason}\"}}}}", Encoding.UTF8, "application/json");
				}

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					var subscriptionGrouping = await ProcessResponse<SubscriptionGrouping>(response);
					return subscriptionGrouping?.subscription;
				}
			}
		}

		public async Task<List<ProductComponent>> GetProductComponents(int product_family_id)
		{
			string url = $"{_chargifyUrl}/product_families/{product_family_id}/components.json";

			using (var request = new HttpRequestMessage(HttpMethod.Get, url))
			{
				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					var lst = await ProcessResponse<List<ProductComponentGrouping>>(response);
					return lst.Select(l => l.component).ToList();
				}
			}
		}

		public async Task<List<ProductPricePoint>> GetProductPricePoints(int product_id)
		{
			string url = $"{_chargifyUrl}/products/{product_id}/price_points.json";

			using (var request = new HttpRequestMessage(HttpMethod.Get, url))
			{
				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					var lst = await ProcessResponse<ProductPricePointGroup>(response);
					return lst.price_points;
				}
			}
		}

		public async Task<List<ComponentPricePoint>> GetComponentPricePoints(int component_id)
		{
			string url = $"{_chargifyUrl}/components/{component_id}/price_points.json";

			using (var request = new HttpRequestMessage(HttpMethod.Get, url))
			{
				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					var lst = await ProcessResponse<ComponentPricePointGroup>(response);
					return lst.price_points;
				}
			}
		}

		public async Task<List<Component>> GetSubscriptionComponents(int subscription_id)
		{
			string url = $"{_chargifyUrl}/subscriptions/{subscription_id}/components.json";

			using (var request = new HttpRequestMessage(HttpMethod.Get, url))
			{

				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					List<ComponentResponse> lst = await ProcessResponse<List<ComponentResponse>>(response);
					return lst.Select(c => c.component).ToList();
				}
			}
		}

		public async Task<List<ComponentMeteredUsage>> GetComponentsMeteredUsage(int subscription_id, int component_id, DateTime dtFrom, DateTime dtEnd)
		{
			string url = $"{_chargifyUrl}/subscriptions/{subscription_id}/components/{component_id}/usages.json?since_date={dtFrom:yyyy-MM-dd}&until_date={dtEnd:yyyy-MM-dd}";



			using (var request = new HttpRequestMessage(HttpMethod.Get, url))
			{

				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					List<MeteredUsageGroup> lst = await ProcessResponse<List<MeteredUsageGroup>>(response);
					return lst.Select(c => c.usage).ToList();
				}
			}
		}


		/// <summary>
		/// Upgrade or downgrade a subscription to a new product.
		/// </summary>
		/// <param name="subscriptionId"></param>
		/// <param name="req"></param>
		/// <returns></returns>
		public async Task MigrateSubscription(int subscriptionId, SubscriptionMigrationReq req)
		{
			string url = $"{_chargifyUrl}//subscriptions/{subscriptionId}/migrations.json";

			using (var request = new HttpRequestMessage(HttpMethod.Post, url))
			{
				string json = JsonConvert.SerializeObject(req);
				var content = new StringContent(json);
				content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
				request.Content = content;

				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					await ProcessResponse<object>(response);
				}
			}
		}


		/// <summary>
		/// Preview what a subscription migration will look like in terms of cost for the customer.
		/// </summary>
		/// <param name="subscriptionId"></param>
		/// <param name="req"></param>
		/// <returns></returns>
		public async Task<MigrationPreviewResponse> PreviewSubscriptionMigration(int subscriptionId, SubscriptionMigrationReq req)
		{
			string url = $"{_chargifyUrl}//subscriptions/{subscriptionId}/migrations/preview.json";

			using (var request = new HttpRequestMessage(HttpMethod.Post, url))
			{
				string json = JsonConvert.SerializeObject(req);
				var content = new StringContent(json);
				content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
				request.Content = content;

				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					return await ProcessResponse<MigrationPreviewResponse>(response);
				}
			}
		}
		/// <summary>
		/// Report usage on a component in a subscription.
		/// </summary>
		/// <param name="subscription_id"></param>
		/// <param name="component_handle"></param>
		/// <param name="price_point_handle"></param>
		/// <param name="quantity">Quantity to report.</param>
		/// <param name="memo"></param>
		/// <returns></returns>
		public async Task<ComponentUsageResponse> ReportComponentUsage(int subscription_id, int component_id, double quantity, string memo = null)
		{
			string url = $"{_chargifyUrl}/subscriptions/{subscription_id}/components/{component_id}/usages.json";

			using (var request = new HttpRequestMessage(HttpMethod.Post, url))
			{
				var req = new
				{
					usage = new
					{
						quantity = quantity,
						memo = memo
					}
				};

				string json = JsonConvert.SerializeObject(req);
				var content = new StringContent(json);
				content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
				request.Content = content;

				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					var g = await ProcessResponse<ComponentUsageResponseGroup>(response);
					return g.usage;
				}
			}
		}

		public async Task<ComponentAllocationResponse> ReportComponentQuantity(int subscription_id, int component_id, double quantity, string memo = null)
		{
			string url = $"{_chargifyUrl}/subscriptions/{subscription_id}/components/{component_id}/allocations.json";

			using (var request = new HttpRequestMessage(HttpMethod.Post, url))
			{
				var req = new
				{
					allocation = new
					{
						component_id = component_id,
						quantity = quantity,
						memo = memo
					}
				};

				string json = JsonConvert.SerializeObject(req);
				var content = new StringContent(json);
				content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
				request.Content = content;

				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					var g = await ProcessResponse<ComponentAllocationResponseGroup>(response);
					return g?.allocation;
				}
			}
		}


		public async Task<IList<ProductFamily>> GetProductFamilies()
		{

			string url = $"{_chargifyUrl}/product_families.json";

			using (var request = new HttpRequestMessage(HttpMethod.Get, url))
			{
				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					var groups = await ProcessResponse<IList<ProductFamilyGroup>>(response);
					var families = groups.Select(g => g.product_family).ToList();
					return families;
				}
			}
		}

		public async Task<IList<Product>> GetProducts(int productFamilyID)
		{

			string url = $"{_chargifyUrl}/product_families/{productFamilyID}/products.json";

			using (var request = new HttpRequestMessage(HttpMethod.Get, url))
			{
				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					var groups = await ProcessResponse<IList<ProductGroup>>(response);
					return groups.Select(g => g.product).ToList();
				}
			}
		}

		public async Task<IList<Subscription>> GetSubscriptionsForCustomer(int customerID)
		{

			string url = $"{_chargifyUrl}/customers/{customerID}/subscriptions.json";

			using (var request = new HttpRequestMessage(HttpMethod.Get, url))
			{

				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					var preRes = await ProcessResponse<IList<SubscriptionGrouping>>(response);
					return preRes.Select(g => g.subscription).ToList();
				}
			}
		}

		public async Task<IList<Subscription>> GetSubscriptions(
			int page = 1,
			int pageSize = 20,
			string state = null,
			string date_field = null,
			string start_date = null,
			string end_date = null)
		{

			string url = $"{_chargifyUrl}/subscriptions.json?page={page}&per_page={pageSize}&state={state}&date_field={date_field}&start_date={start_date}&end_date={end_date}";

			using (var request = new HttpRequestMessage(HttpMethod.Get, url))
			{

				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					var preRes = await ProcessResponse<IList<SubscriptionGrouping>>(response);
					return preRes.Select(g => g.subscription).ToList();
				}
			}
		}


		/// <summary>
		/// Get customers in a list.
		/// </summary>
		/// <param name="filter">The email or organization to filter on.</param>
		/// <returns></returns>
		public async Task<IList<Customer>> GetCustomers(string filter)
		{

			StringBuilder urlBuilder = new StringBuilder($"{_chargifyUrl}/customers.json?");

			if (!string.IsNullOrWhiteSpace(filter))
			{
				urlBuilder.AppendFormat("q={0}&", Uri.EscapeDataString(filter));
			}

			urlBuilder.Length--;
			string url = urlBuilder.ToString();


			using (var request = new HttpRequestMessage(HttpMethod.Get, url))
			{

				AuthorizeRequest(request);

				using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
				{
					var preRes = await ProcessResponse<IList<CustomerGrouping>>(response);
					return preRes.Select(g => g.customer).ToList();
				}
			}
		}

		private void AuthorizeRequest(HttpRequestMessage request)
		{
			request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
			var byteArray = Encoding.ASCII.GetBytes($"{_apiKey}:X");
			request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
		}

		private async Task<T> ProcessResponse<T>(HttpResponseMessage response)
		{
			var status = response.StatusCode;
			string responseData = null;

			try
			{
				responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
			}
			catch { }

			if (response.IsSuccessStatusCode)
			{
				//if we just want the string back...
				if (typeof(T) == typeof(string))
				{
					return (T)(object)responseData;
				}

				try
				{
					var result = JsonConvert.DeserializeObject<T>(responseData);
					return result;
				}
				catch (Exception exception)
				{
					throw new ApplicationException("Could not deserialize the response body.", exception);
				}
			}
			else
			{

			}

			switch (status)
			{
				case HttpStatusCode.Unauthorized:
					throw new ApplicationException("Chargify returned a 401 not authorized.");
				case HttpStatusCode.InternalServerError:
					throw new ApplicationException("Chargify returned a 500 server error.");
				default:
					throw new ApplicationException($"Chargify returned a {(int)status} server response: {responseData}");
			}
		}

	}
}
