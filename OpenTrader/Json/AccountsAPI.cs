using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using OpenApiLib.Json;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace OpenApiDeveloperLibrary.Json
{
	public class AccountsAPI
	{
		private const string TRADING_ACCOUNTS_SERVICE = "/connect/tradingaccounts";

		private const string MINUTE_TRENDBARS_SERVICE = "/connect/tradingaccounts/${id}/symbols/${symbolName}/trendbars/m1";

		private string root;
		private string authToken;

		public AccountsAPI(string root, string authToken)
		{
			this.root = root;
			this.authToken = authToken;
		}

		private string getServiceURLString(string service)
		{
			return getServiceURLString(service, null);
		}

		private string getServiceURLString(string service, IDictionary <string, string> pathParams)
		{
			return getServiceURLString(service, pathParams, null);
		}

		private string getServiceURLString(string service, IDictionary <string, string> pathParams, IDictionary<string, string> requestParams)
		{
			return getServiceURLString(service, pathParams, requestParams, true);
		}

		private string getServiceURLString(string service, IDictionary<string, string> pathParams, IDictionary<string, string> requestParams, bool authRequired)
		{
			if (requestParams == null)
			{
				requestParams = new System.Collections.Generic.Dictionary<string, string>();
			}
			if (authRequired)
			{
				requestParams["oauth_token"] = authToken;
			}
			StringBuilder urlBuilder = new StringBuilder(root);
			urlBuilder.Append(service);
			if (requestParams.Count != 0)
			{
				urlBuilder.Append("?");
				StringBuilder parametersBuilder = new StringBuilder();
				foreach (System.Collections.Generic.KeyValuePair<string, string> entry in requestParams)
				{
					if (parametersBuilder.Length > 0)
					{
						parametersBuilder.Append("&");
					}
					parametersBuilder.Append(entry.Key);
					parametersBuilder.Append("=");
					parametersBuilder.Append(entry.Value);
				}
				urlBuilder.Append(parametersBuilder);
			}
			string url = urlBuilder.ToString ();
			if (pathParams != null)
			{
				foreach (KeyValuePair<string, string> item in pathParams)
				{
					url = url.Replace ("${" + item.Key + "}", item.Value);
				}
			}
			return url;
		}

		private string callURL(string myURL)
		{
			Console.WriteLine("Requsted URL:" + myURL);
			HttpWebRequest http = (HttpWebRequest)WebRequest.Create(myURL);
			WebResponse response = http.GetResponse();

			Stream stream = response.GetResponseStream();
			string content = null;
			using (StreamReader sr = new StreamReader (stream)) {
				content = sr.ReadToEnd ();
			}
			return content;
		}

		public virtual TradingAccountJson[] getTradingAccounts()
		{
			string service = getServiceURLString(TRADING_ACCOUNTS_SERVICE);
			try
			{
				MessageJson<TradingAccountJson[]> messageJson = JsonConvert.DeserializeObject<MessageJson<TradingAccountJson[]>>(callURL(service));
				ErrorJson error = messageJson.Error;
				if (error != null)
				{
					throw new AccountsAPIException(error.ErrorCode, error.Description);
				}
				return messageJson.Data;
			}
			catch (System.Exception e)
			{
				throw new AccountsAPIException(e);
			}
		}

		/// <exception cref="com.mycompany.app.AccountsAPIException"/>
		public virtual TrendbarJson[] getMinuteTredbars(long accountId, string symbolName, DateTime from, DateTime to)
		{
			IDictionary<string, string> pathParams = new Dictionary <string, string>();
			pathParams["id"] = accountId.ToString();
			pathParams["symbolName"] = symbolName;
			IDictionary<string, string> requestParams = new Dictionary <string, string>();
			requestParams["from"] = from.ToString("yyyyMMddHHmmss");
			requestParams["to"] = to.ToString("yyyyMMddHHmmss");
			string service = getServiceURLString(MINUTE_TRENDBARS_SERVICE, pathParams, requestParams);
			try
			{
				MessageJson<TrendbarJson[]> messageJson = JsonConvert.DeserializeObject<MessageJson<TrendbarJson[]>>(callURL(service));
				ErrorJson error = messageJson.Error;
				if (error != null)
				{
					throw new AccountsAPIException(error.ErrorCode, error.Description);
				}
				return messageJson.Data;
			}
			catch (System.Exception e)
			{
				throw new AccountsAPIException(e);
			}
		}
	}
}
