namespace FSPS1Lib1

open System
open System.Management.Automation

[<Cmdlet(VerbsCommon.Get, "Foo", SupportsShouldProcess=true)>]
type GetFooCommand() =
    inherit PSCmdlet()

    [<Parameter>]
    member val Name : string = "" with get, set

    override x.EndProcessing() =
        x.WriteObject("Foo is " + x.Name)
        base.EndProcessing()