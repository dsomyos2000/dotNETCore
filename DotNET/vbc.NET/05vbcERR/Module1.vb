Imports System.Collections.Generic

Module Module1

    Sub Main()
        Dim dict = New Dictionary(Of String, String)()

        ' We must use ContainsKey or TryGetValue.
        If dict("car") = "vehicle" Then
            Return
        End If
    End Sub

End Module

'Unhandled Exception: System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary.
'   at System.ThrowHelper.ThrowKeyNotFoundException()
'   at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
'   at Module1.Main()