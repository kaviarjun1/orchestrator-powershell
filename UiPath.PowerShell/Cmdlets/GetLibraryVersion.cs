﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UiPath.PowerShell.Models;
using UiPath.PowerShell.Util;
using UiPath.Web.Client20183;

namespace UiPath.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, Nouns.LibraryVersion)]
    public class GetLibraryVersion : FilteredBaseCmdlet
    {
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Id")]
        public string Id { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Library", ValueFromPipeline = true)]
        public Library Library { get; set; }

        [Filter]
        [Parameter]
        public bool IsLatestVersion { get; private set; }

        protected override void ProcessRecord()
        {
            ProcessImpl(
                filter => Api_18_3.Libraries.GetVersionsByPackageid(Library?.Id ?? Id, filter: filter).Value,
                dto => Library.FromDto(dto));
        }
    }
}
