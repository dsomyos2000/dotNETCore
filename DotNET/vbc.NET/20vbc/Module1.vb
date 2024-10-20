Imports System.Collections.Generic
Imports System.Collections

Module Module1
	Dim htbl2 As Hashtable = New Hashtable() From {
                                {"msg", "Welcome"},
                                {"site", "Tutlane"},
                                {1, 20.5},
                                {2, Nothing}
                            }
    Sub Main(ByVal args As String())
        Dim htbl As Hashtable = New Hashtable()
        htbl.Add("msg", "Welcome")
        htbl.Add("site", "Tutlane")
        htbl.Add(1, 20.5)
        htbl.Add(2, Nothing)
        ' Another way to add elements. If key not exist, then that key adds a new key/value pair.
        htbl(3) = "Tutorials"
        ' Add method will throws an exception if key already exists in hash table
        Try
            htbl.Add(2, 100)
        Catch
            Console.WriteLine("An element with Key = '2' already exists.")
        End Try
        Console.WriteLine("*********HashTable Elements********")
        ' It will return elements as KeyValuePair objects
        For Each item As DictionaryEntry In htbl
            Console.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value)
        Next

        Console.WriteLine("")
        Console.WriteLine("*********HashTable Elements********")
        For Each item In htbl2.Keys
            Console.WriteLine("Key = [{0}], Value = [{1}]", item, htbl2(item))
        Next
        Console.WriteLine("*********HashTable Values********")
        For Each item In htbl2.Values
            Console.WriteLine("Value = {0}", item)
        Next
        'Console.ReadLine()
    End Sub
End Module