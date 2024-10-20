Imports System.Collections.Generic

Module Module1

    Sub Main()
        Dim source = New Dictionary(Of String, Integer)()
        source.Add("bird", 20)

        ' Copy the Dictionary.
        Dim copy = New Dictionary(Of String, Integer)(source)

        ' Write some details.
        Console.WriteLine("COPY: {0}, COUNT = {1}", copy("bird"), copy.Count)
    End Sub

End Module