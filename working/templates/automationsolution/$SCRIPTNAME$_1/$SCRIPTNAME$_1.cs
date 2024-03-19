namespace $NAMESPACE$_1
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Text;
	using Skyline.DataMiner.Automation;
	
	/// <summary>
	/// Represents a DataMiner Automation script.
	/// </summary>
	public class Script
	{
		/// <summary>
		/// The script entry point.
		/// </summary>
		/// <param name="engine">Link with SLAutomation process.</param>
		public void Run(IEngine engine)
		{
			try
			{
				RunSafe(engine);
			}
			catch (ScriptAbortException)
			{
				// catch normal abort exceptions
			}
			catch (ScriptForceAbortException)
			{
				// catch normal abort exceptions
			}
			catch (Exception e)
			{
				engine.Log("Run|Something went wrong: " + e);
			}
		}

		private void RunSafe(IEngine engine)
		{
			// TODO: Define code here
		}
	}
}
