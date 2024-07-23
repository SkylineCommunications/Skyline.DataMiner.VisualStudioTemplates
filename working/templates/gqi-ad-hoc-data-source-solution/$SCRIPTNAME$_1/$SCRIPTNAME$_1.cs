namespace $NAMESPACE$_1
{
	using System;
	using Skyline.DataMiner.Analytics.GenericInterface;

	/// <summary>
	/// Represents a data source.
	/// See: https://aka.dataminer.services/gqi-external-data-source for a complete example.
	/// </summary>
	[GQIMetaData(Name = "$SCRIPTNAME$")]
	public sealed class $NAMESPACE$ : IGQIDataSource
#if (IGQIInputArguments)
		, IGQIInputArguments
#endif
#if (IGQIOnInit)
		, IGQIOnInit
#endif
#if (IGQIOnDestroy)
		, IGQIOnDestroy
#endif
#if (IGQIOnPrepareFetch)
		, IGQIOnPrepareFetch
#endif
#if (IGQIUpdateable)
		, IGQIUpdateable
#endif
	{
#if (IGQIOnInit)
		public OnInitOutputArgs OnInit(OnInitInputArgs args)
		{
			// Initialize the data source
			// See: https://aka.dataminer.services/igqioninit-oninit
			return default;
		}

#endif
#if (IGQIInputArguments)
		public GQIArgument[] GetInputArguments()
		{
			// Define data source input arguments
			// See: https://aka.dataminer.services/igqiinputarguments-getinputarguments
			return Array.Empty<GQIArgument>();
		}

		public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
		{
			// Process input argument values
			// See: https://aka.dataminer.services/igqiinputarguments-onargumentsprocessed
			return default;
		}

#endif
		public GQIColumn[] GetColumns()
		{
			// Define data source columns
			// See: https://aka.dataminer.services/igqidatasource-getcolumns
			return Array.Empty<GQIColumn>();
		}
#if (IGQIOnPrepareFetch)

		public OnPrepareFetchOutputArgs OnPrepareFetch(OnPrepareFetchInputArgs args)
		{
			// Prepare data source for fetching
			// See: https://aka.dataminer.services/igqionpreparefetch-onpreparefetch
			return default;
		}
#endif
#if (IGQIUpdateable)

		public void OnStartUpdates(IGQIUpdater updater)
		{
			// Enable the data source to send updates
			// See: https://aka.dataminer.services/igqiupdateable-onstartupdates
		}
#endif

		public GQIPage GetNextPage(GetNextPageInputArgs args)
		{
			// Define data source rows
			// See: https://aka.dataminer.services/igqidatasource-getnextpage
			return new GQIPage(Array.Empty<GQIRow>())
			{
				HasNextPage = false,
			};
		}
#if (IGQIOnDestroy)

		public OnDestroyOutputArgs OnDestroy(OnDestroyInputArgs args)
		{
			// Clean up the data source
			// See: https://aka.dataminer.services/igqiondestroy-ondestroy
			return default;
		}
#endif
#if (IGQIUpdateable)

		public void OnStopUpdates()
		{
			// Stop sending updates
			// See: https://aka.dataminer.services/igqiupdateable-onstopupdates
		}
#endif
	}
}
