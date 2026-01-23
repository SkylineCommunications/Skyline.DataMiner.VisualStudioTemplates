namespace $CLASS_NAME_PLACEHOLDER$Bpa
{
	using Skyline.DataMiner.BpaLib;

	/// <summary>
	/// This class is used to report the result back to the test framework
	/// </summary>
	public sealed class $CLASS_NAME_PLACEHOLDER$Result : ABpaTestResult
	{
		public $CLASS_NAME_PLACEHOLDER$Result()
		{
			// TestExecuted = true indicates that the test was able to run
			TestExecuted = true;
		}
	}
}
