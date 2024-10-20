Imports System.Collections.Generic

Module Module1

    Sub Main()
        ' Step 1: create Dictionary with 4 keys.
        Dim colors As New Dictionary(Of String, Integer)
        colors.Add("blue", 32)
        colors.Add("yellow", 16)
        colors.Add("green", 256)
        colors.Add("red", 100)

        ' Step 2: use For Each loop over pairs.
        For Each pair As KeyValuePair(Of String, Integer) In colors
            Console.WriteLine("COLOR: {0}, VALUE: {1}", pair.Key, pair.Value)
        Next
    End Sub

End Module