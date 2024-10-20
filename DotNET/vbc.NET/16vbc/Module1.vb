Imports System.Collections.Generic
Imports System.Diagnostics

Module Module1

    Sub Main()
        ' Create Dictionary and List.
        Dim lookup As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
        For i As Integer = 0 To 1000
            lookup.Add(i.ToString(), 1)
        Next
        Dim list As List(Of String) = New List(Of String)
        For i As Integer = 0 To 1000
            list.Add(i.ToString())
        Next

        Dim m As Integer = 1000
        ' Version 1: search Dictionary.
        Dim s1 As Stopwatch = Stopwatch.StartNew
        For i As Integer = 0 To m - 1
            If Not lookup.ContainsKey("900") Then
                Return
            End If
        Next
        s1.Stop()

        Dim s2 As Stopwatch = Stopwatch.StartNew
        ' Version 2: search List.
        For i As Integer = 0 To m - 1
            If Not list.Contains("900") Then
                Return
            End If
        Next
        s2.Stop()

        Dim u As Integer = 1000000
        Console.WriteLine(((s1.Elapsed.TotalMilliseconds * u) / m).ToString("0.00 ns"))
        Console.WriteLine(((s2.Elapsed.TotalMilliseconds * u) / m).ToString("0.00 ns"))
    End Sub

End Module