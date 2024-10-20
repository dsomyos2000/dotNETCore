Imports System.Collections.Generic

Module Module1
    ''' <summary>
    ''' Stores class-level Dictionary instance.
    ''' </summary>
    Class Example

        Private _dictionary

        Public Sub New()
            ' Part 2: allocate and populate the field Dictionary.
            Me._dictionary = New Dictionary(Of String, Integer)
            Me._dictionary.Add("make", 55)
            Me._dictionary.Add("model", 44)
            Me._dictionary.Add("color", 12)
        End Sub

        Public Function GetValue() As Integer
            ' Return value from private Dictionary.
            Return Me._dictionary.Item("make")
        End Function

    End Class

    Sub Main()
        ' Part 1: allocate an instance of the class.
        Dim example As New Example

        ' Part 3: write a value from the class.
        Console.WriteLine(example.GetValue())
    End Sub
End Module