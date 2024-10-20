Imports System
Imports System.Management.Automation

Namespace CSPS1Lib2
    <Cmdlet(VerbsCommon.Get, "Foo")>
    Public Class GetFooCommand
        Inherits PSCmdlet

        <Parameter>
        Public Property Name As String = ""

        Protected Overrides Sub EndProcessing()
            WriteObject("Foo is " & Name)
            MyBase.EndProcessing()
        End Sub
    End Class
End Namespace

