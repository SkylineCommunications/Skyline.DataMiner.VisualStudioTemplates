namespace $NAMESPACE$_1
{
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Net.Apps.UserDefinableApis;
	using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;

	/// <summary>
	/// Represents a DataMiner Automation script.
	/// </summary>
	public class Script
	{
		private static IDictionary<string, string> GetParametersFromInput(ApiTriggerInput requestData)
		{
			var parameters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		
			if (requestData != null)
			{
				var queryList = requestData.QueryParameters?.GetAllKeys();
				if (requestData.Parameters?.Count > 0 && (queryList == null || queryList.Count == 0))
				{
					foreach (var parameter in requestData.Parameters)
					{
						parameters[parameter.Key] = parameter.Value;
					}
				}
				else if (queryList?.Count > 0)
				{
					foreach (var query in queryList)
					{
						if (requestData.QueryParameters.TryGetValue(query, out var value))
						{
							parameters[query] = value;
						}
					}
				}
			}
		
			return parameters;
		}
		
		/// <summary>
		/// The API trigger.
		/// </summary>
		/// <param name="engine">Link with SLAutomation process.</param>
		/// <param name="requestData">Holds the API request data.</param>
		/// <returns>An object with the script API output data.</returns>
		[AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
		public ApiTriggerOutput OnApiTrigger(IEngine engine, ApiTriggerInput requestData)
		{
			var method = requestData.RequestMethod;
			var route = requestData.Route;
			var body = requestData.RawBody;
			var parameters = GetParametersFromInput(requestData);

			return new ApiTriggerOutput
			{
				ResponseBody = $"Received {method} request for route: '{route}' with body: '{body}'",
				ResponseCode = (int)StatusCode.Ok,
			};
		}
	}
}
