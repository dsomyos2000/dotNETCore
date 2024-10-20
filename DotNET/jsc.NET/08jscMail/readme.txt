@Echo Off

@Echo Compiling Get_Attachment_from_Email_Dotnet.js

Rem Release
rem jsc.exe /t:exe /r:System.dll Get_Attachment_from_Email_Dotnet.js

Rem Debug
jsc.exe /t:exe /debug /r:System.dll Get_Attachment_from_Email_Dotnet.js


rem jsc.exe /t:exe /debug /r:Microsoft.Office.Interop.Outlook.dll /r:System.dll Get_Attachment_from_Email_Dotnet.js

