https://learn.microsoft.com/en-us/dotnet/core/tools/ 
dotnet new console 
F:\01dotNet build --output ./build_output 
path=C:\Windows\Microsoft.NET\Framework64\v4.0.30319;C:\Windows\Microsoft.NET\Framework64\v4.0.30319;C:\Windows\system32;C:\Windows;C:\Windows\System32\Wbem;C:\Windows\System32\WindowsPowerShell\v1.0\;C:\Windows\System32\OpenSSH\;C:\Program Files\Microsoft SQL Server\150\Tools\Binn\;C:\Program Files (x86)\Microsoft SQL Server\160\DTS\Binn\;C:\Program Files\Azure Data Studio\bin;C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\170\Tools\Binn\;C:\Program Files (x86)\Microsoft SQL Server\150\Tools\Binn\;C:\Program Files\Microsoft SQL Server\150\DTS\Binn\;C:\Program Files\Git\cmd;C:\Program Files\OpenRPA\;C:\Program Files\dotnet\;C:\Users\User\AppData\Local\Microsoft\WindowsApps;;C:\Program Files\Azure Data Studio\bin;C:\Users\User\AppData\Local\Programs\Microsoft VS Code\bin;C:\Users\User\.dotnet\tools 
csc -? 
New connections will be remembered.


Status       Local     Remote                    Network

-------------------------------------------------------------------------------
OK           D:        \\172.17.96.1\d$          Microsoft Windows Network
OK           E:        \\172.17.96.1\c$          Microsoft Windows Network
OK           F:        \\172.17.96.1\c$\Users\somyos_dua.FREEWILLGROUP\Documents\DotNET 
                                                Microsoft Windows Network
OK                     \\172.17.96.1\IPC$        Microsoft Windows Network
The command completed successfully.

t.bat csc.exe yyy zzz TTT
C:\Users\somyos_dua.FREEWILLGROUP\Documents\DotNET>t.bat csc.exe 222 333 444 555
*[csc.exe 222 333 444 555] 0[t.bat] 1[csc.exe] 2[222] 3[333] 4[444]
`%~$PATH:1`     c:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe
`%~dp$PATH:1`   c:\Windows\Microsoft.NET\Framework64\v4.0.30319\
`%ERRORLEVEL%` 0
`%comspec%`     C:\Windows\system32\cmd.exe
`%date%`        "Tue 10/18/2022"
`%whoami%`      freewillgroup\somyos_dua
`envCSC.cmd`
`t2.cmd`
`witch.cmd`
--------------------------
15841
------net helpmsg #-------
2185 - The service name is invalid.
2182 - The requested service has already been started.
3521 - The *** service is not started.
3534 - The service did not report an error.
2245 - The password does not meet the password policy requirements. Check the minimum password length, password complexity and password history requirements.
2182 - The requested service has already been started.
2250 - The network connection could not be found.
3547 - A service specific error occurred: ***.
2221 - The user name could not be found.

C:\Users\somyos_dua.FREEWILLGROUP\Documents\DotNET>witch python.exe
python.exe is found: C:\Python39_64\python.exe
C:\Users\somyos_dua.FREEWILLGROUP\Documents\DotNET>witch csc.exe
csc.exe is found: c:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe
C:\Users\somyos_dua.FREEWILLGROUP\Documents\DotNET>witch javac.exe
javac.exe is found: C:\Program Files\Java\jdk-19\bin\javac.exe

C:\Users\somyos_dua.FREEWILLGROUP\Documents\DotNET>for %I in (*.exe) do @echo %~$PATH:I
c:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe
c:\Windows\Microsoft.NET\Framework64\v4.0.30319\jsc.exe
c:\Windows\Microsoft.NET\Framework64\v4.0.30319\vbc.exe
