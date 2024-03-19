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
				// throw; // Uncomment if it should not be treated as a normal exit of the script.
			}
			catch (ScriptForceAbortException)
			{
				// catch normal abort exceptions
				// throw; // Uncomment if it should not be treated as a normal exit of the script.
			}
			catch (InteractiveUserDetachedException e)
			{
				// catch a user detaching from the interactive script.
				// only applicable for interactive scripts, can be removed for non-interactive scripts.
			}
			catch (Exception e)
			{
				engine.ExitFail("Run|Something went wrong: " + e);
			}
		}

		private void RunSafe(IEngine engine)
		{
			// TODO: Define code here
		}
	}
}
