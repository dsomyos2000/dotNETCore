Imports System.Collections.Generic

Module Module1
    Sub Main()
        ' Create Dictionary and add two keys.
        Dim dictionary As New Dictionary(Of String, Integer)
        dictionary.Add("fish", 32)
        dictionary.Add("microsoft", 23)

        ' Remove two keys.
        dictionary.Remove("fish")  ' Will remove this key.
        dictionary.Remove("apple") ' Doesn't change anything.
    End Sub
End Module