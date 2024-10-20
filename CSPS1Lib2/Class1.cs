using System;
using System.Management.Automation;

namespace CSPS1Lib2
{
    [Cmdlet(VerbsCommon.Get, "Foo")]
    public class GetFooCommand : PSCmdlet
    {
        [Parameter]
        public string Name { get; set; } = "";

        protected override void EndProcessing()
        {
            WriteObject("Foo is " + Name);
            base.EndProcessing();
        }
    }
}
