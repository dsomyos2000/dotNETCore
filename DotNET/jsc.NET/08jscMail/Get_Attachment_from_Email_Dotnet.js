// Get_Attachment_from_Email_Dotnet.js - Get attachment from today's email with specific subject heading 

import System
import System.Windows.Forms
import Microsoft.Office.Tools
import Microsoft.Office.Interop
import Microsoft.Office.Interop.Outlook
import Microsoft.Office.Interop.Outlook.Application
import Microsoft.Office.Interop.Outlook.MAPIFolder
import Microsoft.Office.Interop.Outlook._NameSpace
import Microsoft.Outlook.Folder
import System.Data

const FOR_APPENDING : int 											= 8
const FOR_WRITING : int 												= 2

const olFolderInbox = 6

var Outlook_o : Object
var Outlook_a : Application

var Namespace_o
var DefaultFolders_o
var Inbox_o

var DefaultFolder_o
var Folder_o : Object
var Folder_col
var Items_col
var Filtered_Items_col
var Message_o
var Message_Count_n
var Attachment_o
var Attachment_Count_n
var Attachment_Item_o
var Items_a
var Subject_s
var Body_s
var ThisFolder
var TheseFolders_o

var FileName_s
var Save_Path_s

var Subject_s = "Daily Invoices"

var Save_Path_s = "c:\\FolderToSaveAttachments\\Invoices"

try
{
	Outlook_o = new ActiveXObject( "Outlook.Application" )
	Namespace_o = Outlook_o.GetNamespace("MAPI")
	Inbox_o = Namespace_o.GetDefaultFolder(olFolderInbox)
	Items_col = Inbox_o.Items
	Filtered_Items_col = Items_col.Restrict("[Subject] = " + Subject_s)
	Filtered_Items_col = Filtered_Items_col.Restrict("@SQL=%today(" + String.fromCharCode(34) + "urn:schemas:httpmail:datereceived" + String.fromCharCode(34) + ")%")
	Message_Count_n = Filtered_Items_col.Count

	for( var NthMessage_n : int = 1; NthMessage_n < Message_Count_n ; NthMessage_n++ )
	{
	  Message_o = Filtered_Items_col.Item( NthMessage_n )
	  Subject_s = Message_o.Subject 
	  Attachment_Count_n = Message_o.Attachments.Count
	  if( Attachment_Count_n > 0 )
	  {
	  	FileName_s = Message_o.Attachments.Item(1).FileName
	 	
	  	LogStatus( " Found " + FileName_s + ". Saving it to " + Save_Path_s )
			Save_Path_s = Save_Path_s + "\\" + FileName_s
	  	Message_o.Attachments.Item(1).SaveAsFile( Save_Path_s )
	  	LogStatus( " Finished saving to " + Save_Path_s )
	  	print( Save_Path_s )
	  }
	}
}
catch(e)
{
		print( e.number & 0xFFFF )	
		print( e.description )
}

function LogStatus( Status_s )
{
	var LogFileName_s
	var objFS
	var objTS
	var ErrorNumber
	var ErrorDescription
	var ErrorSource

	LogFileName_s = ".log"

	try 
	{
		objFS = new ActiveXObject("Scripting.FileSystemObject")
		objTS = objFS.OpenTextFile(LogFileName_s,FOR_APPENDING,true)
		objTS.WriteLine( DateTime.Now + " " + Status_s )
		objTS.Close()
	}
	catch(e)
	{
		print( e.number & 0xFFFF )	
		print( e.description )
		print( "Cannot write to log " + LogFileName_s )
	}
		
}