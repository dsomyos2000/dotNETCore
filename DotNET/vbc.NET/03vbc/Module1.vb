Imports System.Collections.Generic

Module Module1
    Sub Main()
        ' Declare new Dictionary with String keys.
        Dim dictionary As New Dictionary(Of String, Integer)

        ' Add two keys.
        dictionary.Add("carrot", 7)
        dictionary.Add("perl", 15)

        ' See if this key exists.
        If dictionary.ContainsKey("carrot") Then
            ' Write value of the key.
            Dim num As Integer = dictionary.Item("carrot")
            Console.WriteLine(num)
        End If

        ' See if this key also exists (it doesn't).
        If dictionary.ContainsKey("python") Then
            Console.WriteLine(False)
        End If
    End Sub
End Module