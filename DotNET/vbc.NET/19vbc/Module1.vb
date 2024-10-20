Imports System.Collections
Imports System.Collections.Generic

Module Module1  'collections
   Sub Main()
      Dim ht As Hashtable = New Hashtable()
      Dim k As String
      ht.Add("001", "Zara Ali")
      ht.Add("002", "Abida Rehman")
      ht.Add("003", "Joe Holzner")
      ht.Add("004", "Mausam Benazir Nur")
      ht.Add("005", "M. Amlan")
      ht.Add("006", "M. Arif")
      ht.Add("007", "Ritesh Saikia")
      
      If (ht.ContainsValue("Nuha Ali")) Then
         Console.WriteLine("This student name is already in the list")
      Else
          ht.Add("008", "Nuha Ali")
      End If
      ' Get a collection of the keys. 
      Dim key As ICollection = ht.Keys
      
      For Each k In key
         Console.WriteLine(" {0} : {1}", k, ht(k))
      Next k
      'Console.ReadKey()
   End Sub
End Module