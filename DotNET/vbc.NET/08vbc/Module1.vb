Imports System.Collections.Generic

Module Module1

    Sub Main()
        ' Step 1: add 4 string keys.
        Dim animals As New Dictionary(Of String, Integer)
        animals.Add("bird", 12)
        animals.Add("frog", 11)
        animals.Add("cat", 10)
        animals.Add("elephant", -11)

        ' Step 2: get List of String Keys.
        Dim list As New List(Of String)(animals.Keys)

        ' Step 3: loop over Keys and print the Dictionary values.
        For Each value As String In list
            Console.WriteLine("ANIMAL: {0}, VALUE: {1}", value, animals.Item(value))
        Next
    End Sub

End Module