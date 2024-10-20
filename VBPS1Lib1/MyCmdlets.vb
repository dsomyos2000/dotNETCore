Imports System.Management.Automation

Namespace MyCmdlets
    <Cmdlet(VerbsCommon.Get, "Greeting")>
    Public Class GetGreetingCmdlet
        Inherits Cmdlet

        Protected Overrides Sub BeginProcessing()
            WriteObject("Hello, world!")
        End Sub
    End Class
End Namespace
