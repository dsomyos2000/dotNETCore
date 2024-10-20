Imports System.Collections.Generic 

Module Module1 
      Sub Main() 
           Dim AuthorList As New Dictionary(Of String, Int16) 
           AuthorList.Add("Mahesh Chand", 35) 
           AuthorList.Add("Mike Gold", 25) 
           AuthorList.Add("Praveen Kumar", 29) 
           AuthorList.Add("Raj Beniwal", 21) 
           AuthorList.Add("Dinesh Beniwal", 84)

           ' Read all data
           Console.WriteLine("Authors List") 
           For Each author As KeyValuePair(Of String, Int16) In AuthorList       
                     Console.WriteLine("Key = {0}, Value = {1}", _
                                     author.Key, author.Value)       
           Next author       
           'Console.ReadKey() 
       End Sub

 End Module