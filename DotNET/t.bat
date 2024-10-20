@echo off
echo *[%*] 0[%~0] 1[%~1] 2[%~2] 3[%~3] 4[%~4]
echo `%%~$PATH:1`     %~$PATH:1
echo `%%~dp$PATH:1`   %~dp$PATH:1
echo `%%ERRORLEVEL%%` %ERRORLEVEL%
echo `%%comspec%%`     %comspec% 
echo `%%date%%`        "%date%"
for /f %%i in ('whoami') do echo `%%whoami%%`      %%i
for /f usebackq %%F in (`dir /w/b *.cmd`) do echo `%%F`
echo --------------------------
for /f "delims=" %%A in ('set /a 0x3DE1') do echo %%A
echo ------net helpmsg #-------
for /f "delims=" %%A in ('net helpmsg 2185') do echo 2185 - %%A
for /f "delims=" %%A in ('net helpmsg 2182') do echo 2182 - %%A
for /f "delims=" %%A in ('net helpmsg 3521') do echo 3521 - %%A
for /f "delims=" %%A in ('net helpmsg 3534') do echo 3534 - %%A
for /f "delims=" %%A in ('net helpmsg 2245') do echo 2245 - %%A
for /f "delims=" %%A in ('net helpmsg 2182') do echo 2182 - %%A
for /f "delims=" %%A in ('net helpmsg 2250') do echo 2250 - %%A
for /f "delims=" %%A in ('net helpmsg 3547') do echo 3547 - %%A
for /f "delims=" %%A in ('net helpmsg 2221') do echo 2221 - %%A

echo Version of:[csc, vbc, jsc, java, javac]
wmic /node:"somyos_dua_nb" datafile where name='c:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\csc.exe' get version | find /v "Version"
wmic /node:"somyos_dua_nb" datafile where name='c:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\vbc.exe' get version | find /v "Version"
wmic /node:"somyos_dua_nb" datafile where name='c:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\jsc.exe' get version | find /v "Version"
wmic /node:"somyos_dua_nb" datafile where name='C:\\Program Files\\Java\\jdk-19\\bin\\java.exe' get version | find /v "Version"
wmic /node:"somyos_dua_nb" datafile where name='C:\\Program Files\\Java\\jdk-19\\bin\\javac.exe' get version | find /v "Version"
echo --------------------------
wmic csproduct get name | find /v "Name"