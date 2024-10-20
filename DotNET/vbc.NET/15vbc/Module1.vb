Imports System.Collections.Generic

Module Module1
    Sub Main()
        ' Create an array of four string literal elements.
        Dim array() As String = {"dog", "cat", "rat", "mouse"}

        ' Use ToDictionary.
        ' ... Use each string as the key.
        ' ... Use each string length as the value.
        Dim dict As Dictionary(Of String, Integer) =
            array.ToDictionary(Function(value As String) Return value        End Function,
                               Function(value As String) Return value.Length End Function)
        ' Display dictionary.
        For Each pair In dict
            Console.WriteLine(pair)
        Next
    End Sub
End Module