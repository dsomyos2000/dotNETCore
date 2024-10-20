Imports System     ' Optional since System is always imported
Imports System.Timers
Imports CtrlChrs = Microsoft.VisualBasic.ControlChars
Imports SCG = System.Collections.Generic
Imports System.Collections.Generic

Module Module1

    Sub Main()
        ' Step 1: create a Dictionary.
        Dim dictionary As New System.Collections.Generic.Dictionary(Of String, Integer)
        Dim dictionary2 As New SCG.Dictionary(Of String, Integer)
        Dim dictionary3 As New Dictionary(Of String, Integer)

        ' Step 2: add 4 entries.
        dictionary.Add("bird", 20)
        dictionary.Add("frog", 1)
        dictionary.Add("snake", 10)
        dictionary.Add("fish", 2)
        dictionary2.Add("fish", 2)
        dictionary3.Add("fish", 2)

        ' Step 3: display count.
        Console.WriteLine("DICTIONARY COUNT: {0}", dictionary.Count)
    End Sub

End Module