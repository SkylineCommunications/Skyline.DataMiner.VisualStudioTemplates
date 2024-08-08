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

$INITIALVERSIONDATE$	1.0.0.1		$AUTHORVERSIONHISTORY$, Skyline	Initial version
****************************************************************************
*/

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
#if (IGQIOnInit)
		, IGQIOnInit
#endif
#if (IGQIInputArguments)
		, IGQIInputArguments
#endif
#if (IGQIOnPrepareFetch)
		, IGQIOnPrepareFetch
#endif
#if (IGQIUpdateable)
		, IGQIUpdateable
#endif
#if (IGQIOnDestroy)
		, IGQIOnDestroy
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
#if (IGQIUpdateable)

		public void OnStopUpdates()
		{
			// Stop sending updates
			// See: https://aka.dataminer.services/igqiupdateable-onstopupdates
		}
#endif
#if (IGQIOnDestroy)

		public OnDestroyOutputArgs OnDestroy(OnDestroyInputArgs args)
		{
			// Clean up the data source
			// See: https://aka.dataminer.services/igqiondestroy-ondestroy
			return default;
		}
#endif
	}
}
