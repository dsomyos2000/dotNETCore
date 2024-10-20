PATH=C:\windows\Microsoft.NET\Framework\v4.0.30319;%PATH%
C> csc 02Test.cs
C> csc 03Test.cs
C> csc /t:library /r:System.Web.Services.dll /r:System.Xml.dll 04Test.cs
