Imports System.Collections.Generic

Module Module1
    Sub Main()
        Dim values As Dictionary(Of String, String) = New Dictionary(Of String, String)
        values.Add("A", "uppercase letter A")
        values.Add("c", "lowercase letter C")

        ' Get value with TryGetValue.
        Dim result As String = Nothing
        If values.TryGetValue("c", result) Then
            Console.WriteLine("RESULT: {0}", result)
        End If
    End Sub
End Module