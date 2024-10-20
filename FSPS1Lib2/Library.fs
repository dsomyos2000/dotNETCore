namespace FSPS1Lib2

open System
open System.ComponentModel
open System.IO
open System.Management.Automation

type SpecifiedLinesData(data) =
    member val Data = Some(data) with get 

[<Cmdlet(VerbsCommon.Select, "SpecifiedLines", SupportsShouldProcess=true)>]
type SelectSpecifiedLinesCommand() =
    inherit PSCmdlet()

    let inputLines data file =
        match data with
        | Some(x) -> x
        | None ->
            use r = 
                if String.IsNullOrEmpty(file)
                then Console.In
                else new StreamReader(file) :> TextReader
            seq {
                while r.Peek()>= 0 do
                    yield r.ReadLine()
            }
            |> Seq.toList :> seq<string>

    let outputLines data file =
        use w = 
            if String.IsNullOrEmpty(file)
            then Console.Out
            else new StreamWriter(file) :> TextWriter

        for s : string in data do
            w.WriteLine(s)

    [<Parameter>]
    member val InFile = "" with get, set
    [<Parameter>]
    member val OutFile = "" with get, set
    [<Parameter(DontShow=true, ValueFromPipelineByPropertyName=true)>]
    member val Data = None with get, set
    [<Parameter(Mandatory=true)>]
    member val MaxLineLength = 0 with get, set

    override this.ProcessRecord() =
        let d =
            inputLines this.Data this.InFile
            |> Seq.filter (fun x -> x.Length <= this.MaxLineLength)

        outputLines d this.OutFile

        base.WriteObject(new SpecifiedLinesData(d))

    [<RunInstaller(true)>]
    type SelectSpecifiedLinesCmdlets() =
        inherit PSSnapIn()
        override val Name = "SelectSpecifiedLinesCmdlets" with get
        override val Vendor = "minfuk" with get
        override val Description = "Select SpecifiedLines Cmdlets" with get
