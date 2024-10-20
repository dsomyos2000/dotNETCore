Imports System.Collections.Generic

Module Module1

    Sub Main()
        Dim dictionary = New Dictionary(Of Integer, Integer)()
        ' Add data by assigning to a key.
        dictionary(10) = 20
        ' Look up value.
        Console.WriteLine(dictionary(10))
    End Sub

End Module