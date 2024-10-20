Imports System.Collections.Generic

Module Module1
    Sub Main()
	Dim dict0 As New Dictionary(Of String, Integer)()
	Dim dict = New Dictionary(Of Integer, String) From {{ 1, "Test1" }, { 2, "Test2" }}
	Console.WriteLine("{0}-{1}, {2}-{3}", 1, dict(1), 2, dict(2))

	For Each pair As KeyValuePair(Of Integer, String) In dict
		Console.WriteLine(pair.Key & "  -  " & pair.Value)
	Next
    End Sub

End Module