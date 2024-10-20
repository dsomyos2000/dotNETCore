Imports System.Collections.Generic

Module Module1
    Sub Main()
        ' Create new Dictionary with Integer values.
        Dim dictionary As New Dictionary(Of String, Integer)
        dictionary.Add("pelican", 11)
        dictionary.Add("robin", 21)

        ' See if Dictionary contains the value 21 (it does).
        If dictionary.ContainsValue(21) Then
            ' Prints true.
            Console.WriteLine(True)
        End If
    End Sub
End Module