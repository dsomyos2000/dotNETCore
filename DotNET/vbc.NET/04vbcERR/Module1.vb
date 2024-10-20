Imports System.Collections.Generic

Module Module1
    Sub Main()
        Dim lookup As Dictionary(Of String, Integer) =
            New Dictionary(Of String, Integer)
        lookup.Add("cat", 10)
        ' This causes an error.
        lookup.Add("cat", 100)
    End Sub
End Module

'Unhandled Exception: System.ArgumentException: An item with the same key has already been added.
'   at System.ThrowHelper.ThrowArgumentException(ExceptionResource resource)
'   at System.Collections.Generic.Dictionary`2.Insert(TKey key, TValue value, Boolean add)
'   at Module1.Main()