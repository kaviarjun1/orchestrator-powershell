﻿using System.Management.Automation;
using UiPath.PowerShell.Models;
using UiPath.PowerShell.Util;
using UiPath.Web.Client20183;

namespace UiPath.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, Nouns.Library)]
    public class GetLibrary : FilteredBaseCmdlet
    {

        [Filter]
        [Parameter(ParameterSetName = "Filter")]
        public string Authors { get; private set; }


        [Filter]
        [Parameter(ParameterSetName = "Filter")]
        public bool? IsLatestVersion { get; private set; }

        [Filter]
        [Parameter(ParameterSetName = "Filter")]
        public string Key { get; private set; }

        [Filter]
        [Parameter(ParameterSetName = "Filter")]
        public string OldVersion { get; private set; }

        [Filter]
        [Parameter(ParameterSetName = "Filter")]
        public string Title { get; private set; }

        [Filter]
        [Parameter(ParameterSetName = "Filter")]
        public string Version { get; private set; }

        [Filter]
        [Parameter(ParameterSetName = "Filter")]
        public string Id { get; private set; }

        protected override void ProcessRecord()
        {
            ProcessImpl(
                filter => Api_18_3.Libraries.GetLibraries(filter: filter).Value,
                dto => Library.FromDto(dto));
        }
    }
}
