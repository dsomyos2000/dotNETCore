$ie = iwr -Uri "https://learn.microsoft.com/en-us/"
$ie.Content | Out-File "WriteByPSText.txt"

dir "C:\Users\somyos_dua.FREEWILLGROUP\Documents\DotNET\csc.NET\23csc"

DIR C:\Windows\Microsoft.NET\Framework64\config*.* -Recurse
DIR C:\Windows\Microsoft.NET\Framework\config* -Recurse
DIR C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config
DIR C:\Windows\Microsoft.NET\*.config -Recurse
DIR C:\Windows\assembly\Oracle.DataAccess.dll -Recurse #No file
DIR E:\Oracle.DataAccess.dll -Recurse | select fullname     #=>E:\oracle\product\11.2.0\sesdb_1\ODP.NET\bin\4\Oracle.DataAccess.dll,E:\oracle\product\11.2.0\client_1\ODP.NET\bin\2.x\Oracle.DataAccess.dll ,...
DIR C:\app\Oracle.DataAccess.dll -Recurse | select fullname #=>C:\app\client\Somyos_Dua\product\12.2.0\client_1\odp.net\bin\4\Oracle.DataAccess.dll 

<system.data>
    <DbProviderFactories>
      <add name="Oracle Data Provider for .NET" invariant="Oracle.DataAccess.Client" description="Oracle Data Provider for .NET" type="Oracle.DataAccess.Client.OracleClientFactory, Oracle.DataAccess, Version=4.112.3.0, Culture=neutral, PublicKeyToken=89b483f429c47342"/>
      <add name="Microsoft SQL Server Compact Data Provider 4.0" invariant="System.Data.SqlServerCe.4.0" description=".NET Framework Data Provider for Microsoft SQL Server Compact" type="System.Data.SqlServerCe.SqlCeProviderFactory, System.Data.SqlServerCe, Version=4.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"/>
    </DbProviderFactories>
</system.data>

#[C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\machine.config]
        <section name="system.data" type="System.Data.Common.DbProviderFactoriesConfigurationHandler, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
. . .
<configuration>
    <configSections>
. . .
    <system.data>
        <DbProviderFactories><add name="Microsoft SQL Server Compact Data Provider 4.0" invariant="System.Data.SqlServerCe.4.0" description=".NET Framework Data Provider for Microsoft SQL Server Compact" type="System.Data.SqlServerCe.SqlCeProviderFactory, System.Data.SqlServerCe, Version=4.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"/></DbProviderFactories>
    </system.data>
        <section name="system.data.oracleclient" type="System.Data.Common.DbProviderConfigurationHandler, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>

cd "C:\Users\somyos_dua.FREEWILLGROUP\Documents\DotNET"
.\01RegExp.ps1
1¹

ls $Env:windir\\Microsoft.NET\\csc.exe -Recurse|select FullName

#(sal = Set-Alias)
sal csc C:\\windows\\Microsoft.NET\\Framework64\\v4.0.30319\\csc.exe
csc /?
csc
c:\Python39_64>dir c:\python39_64\lib\site-packages\*-*.* /ad /b
dir c:\python39_64\lib\site-packages\*-*.*-info | select fullname