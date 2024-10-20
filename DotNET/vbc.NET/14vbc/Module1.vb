Imports System.Collections.Generic

Module Module1
    Sub Main()
        Dim dictionary As New Dictionary(Of String, Integer)
        dictionary.Add("a", 5)
        dictionary.Add("b", 8)
        dictionary.Add("c", 13)
        dictionary.Add("d", 14)

        ' Get count.
        Console.WriteLine(dictionary.Count)
    End Sub
End Module