Imports System.Collections.Generic

Module Module1

    Sub Main()
        ' Step 1: use Integer keys, String array values.
        Dim dictionary As New Dictionary(Of Integer, String())
        dictionary.Add(100, New String() {"cat", "bird"})
        dictionary.Add(200, New String() {"dog", "fish"})

        ' Step 2: see if key exists.
        If dictionary.ContainsKey(200) Then

            ' Step 3: get array value, join elements, and print it.
            Dim value() As String = dictionary.Item(200)
            Console.WriteLine("RESULT: {0}", String.Join(",", value))
        End If
    End Sub

End Module