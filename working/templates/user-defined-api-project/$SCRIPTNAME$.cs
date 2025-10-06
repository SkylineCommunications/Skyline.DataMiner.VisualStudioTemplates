namespace $NAMESPACE$
{
	/// <summary>
	/// Represents a DataMiner user-defined API.
	/// </summary>
	public class Script
	{
		using Skyline.DataMiner.Automation;
		using Skyline.DataMiner.Net.Apps.UserDefinableApis;
		using Skyline.DataMiner.Net.Apps.UserDefinableApis.Actions;

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

			return new ApiTriggerOutput
			{
				ResponseBody = $"Received {method} request for route: '{route}' with body: '{body}'",
				ResponseCode = (int)StatusCode.Ok,
			};
		}
	}
}
