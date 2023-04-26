/*
****************************************************************************
*  Copyright (c) $COPYRIGHTYEAR$,  Skyline Communications NV  All Rights Reserved.    *
****************************************************************************

By using this script, you expressly agree with the usage terms and
conditions set out below.
This script and all related materials are protected by copyrights and
other intellectual property rights that exclusively belong
to Skyline Communications.

A user license granted for this script is strictly for personal use only.
This script may not be used in any way by anyone without the prior
written consent of Skyline Communications. Any sublicensing of this
script is forbidden.

Any modifications to this script by the user are only allowed for
personal use and within the intended purpose of the script,
and will remain the sole responsibility of the user.
Skyline Communications will not be responsible for any damages or
malfunctions whatsoever of the script resulting from a modification
or adaptation by the user.

The content of this script is confidential information.
The user hereby agrees to keep this confidential information strictly
secret and confidential and not to disclose or reveal it, in whole
or in part, directly or indirectly to any person, entity, organization
or administration without the prior written consent of
Skyline Communications.

Any inquiries can be addressed to:

	Skyline Communications NV
	Ambachtenstraat 33
	B-8870 Izegem
	Belgium
	Tel.	: +32 51 31 35 69
	Fax.	: +32 51 31 01 29
	E-mail	: info@skyline.be
	Web		: www.skyline.be
	Contact	: Ben Vandenberghe

****************************************************************************
Revision History:

DATE		VERSION		AUTHOR			COMMENTS

$INITIALVERSIONDATE$	1.0.0.1		XXX, Skyline	Initial version
****************************************************************************
*/

namespace SRM.PLS.$SCRIPTNAME$
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Newtonsoft.Json;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Library.Exceptions;
	using Skyline.DataMiner.Library.Solutions.SRM.LifecycleServiceOrchestration;
	using Skyline.DataMiner.Library.Solutions.SRM.Logging.Orchestration;
	using Skyline.DataMiner.Net.Profiles;

	/// <summary>
	/// DataMiner Script Class.
	/// </summary>
	public class Script
	{
		/// <summary>
		/// The Script entry point.
		/// </summary>
		/// <param name="engine">Link with SLAutomation process.</param>
		public void Run(Engine engine)
		{
			var configurationInfo = LoadResourceConfigurationInfo(engine);
			var nodeProfileConfiguration = LoadNodeProfileConfiguration(engine);
			var helper = new ProfileParameterEntryHelper(engine, configurationInfo?.OrchestrationLogger);

			var element = engine.GetDummy("Function DVE");

			try
			{
				helper.Log($"Executing profile-Load with Action {configurationInfo?.ProfileAction}", LogEntryType.Info);

				// EXAMPLE to retrieve the Node Profile Parameter Entries, including interfaces.
				var allProfileParameterEntries = helper.GetNodeProfileParameterEntries(
					configurationInfo,
					nodeProfileConfiguration,
					includeInterfaceParameters: true).ToList();

				// EXAMPLE to retrieve all SrmParametersConfigurations
				var parametersConfiguration = helper.GetNodeSrmParametersConfiguration(configurationInfo, nodeProfileConfiguration).ToList();
				foreach (var config in parametersConfiguration)
				{
					string value = config.Value.Type == ParameterValue.ValueType.Double ? Convert.ToString(config.Value.DoubleValue) : config.Value.StringValue;
					helper.Log($"Parameter configuration {config.ProfileParameterName} with table key {config.ResourceKey}, parameter Id {config.ProtocolParameterId} and value {value}.", LogEntryType.Info);
				}

				helper.Log($"Successfully configured resource", LogEntryType.Info);
			}
			catch (Exception e)
			{
				helper.Log($"Failed to execute profile-load script with action {configurationInfo?.ProfileAction} due to {e}", LogEntryType.Critical);
				throw;
			}
		}

		/// <summary>
		/// Loads the profile instance.
		/// </summary>
		/// <param name="engine">The engine reference.</param>
		/// <returns>The <see cref="ProfileInstance"/> object.</returns>
		/// <exception cref="ArgumentException">In case there is no 'ProfileInstance' input parameter defined.</exception>
		/// <exception cref="ProfileManagerException">In case the profile instance is not found.</exception>
		private static NodeProfileConfiguration LoadNodeProfileConfiguration(Engine engine)
		{
			var instancePlaceHolder = engine.GetScriptParam("ProfileInstance");
			if (instancePlaceHolder == null)
			{
				throw new ArgumentException("There is no input parameter named Info");
			}

			try
			{
				var data = JsonConvert.DeserializeObject<Dictionary<string, Guid>>(instancePlaceHolder.Value);

				return new NodeProfileConfiguration(data);
			}
			catch (Exception ex)
			{
				throw new ArgumentException(string.Format("Invalid input parameter 'ProfileInstance': \r\n{0}", ex));
			}
		}

		/// <summary>
		/// Loads resource configuration info object.
		/// </summary>
		/// <param name="engine">The engine reference.</param>
		/// <returns>The <see cref="SrmResourceConfigurationInfo"/> object.</returns>
		/// <exception cref="ArgumentException">In case there is no 'Info' input parameter defined.</exception>
		private static SrmResourceConfigurationInfo LoadResourceConfigurationInfo(Engine engine)
		{
			var infoPlaceHolder = engine.GetScriptParam("Info");
			if (infoPlaceHolder == null)
			{
				throw new ArgumentException("There is no input parameter named Info");
			}

			try
			{
				var resourceConfiguration = JsonConvert.DeserializeObject<SrmResourceConfigurationInfo>(infoPlaceHolder.Value);
				if (resourceConfiguration == null)
				{
					throw new ArgumentException(
						string.Format("Could not effectively deserialize the 'Info' parameter {0}.", infoPlaceHolder.Value));
				}

				return resourceConfiguration;
			}
			catch (Exception)
			{
				// Whenever an invalid or empty JSON is passed, we should support the basic flow and retrieve parameters straight from the profile instance.
				return new SrmResourceConfigurationInfo();
			}
		}
	}
}