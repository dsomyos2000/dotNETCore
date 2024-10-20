==โปรแกรมสำหรับทดสอบ HTTP Service RESTFul w/ POST but not Secure==
 Directory of C:\Users\somyos_dua.FREEWILLGROUP\2023_JOB\SML\dotNETCore\HttpServ2

06/25/2023  10:15 AM    <DIR>          .
06/25/2023  10:15 AM    <DIR>          ..
06/23/2023  08:46 PM    <DIR>          bin
06/23/2023  11:37 PM               351 HttpServ2.csproj
06/23/2023  11:37 PM    <DIR>          obj
06/25/2023  11:24 AM             5,728 Program.cs
06/25/2023  11:29 AM             5,654 Readme.txt
               3 File(s)         11,733 bytes
               4 Dir(s)  10,233,335,808 bytes free

C> dotnet new console -n HttpServ2
C> cd HttpServ2
C> dotnet list package
Project 'HttpServ2' has the following package references
   [net7.0]:
   Top-level Package      Requested   Resolved
   > Newtonsoft.Json      13.0.3      13.0.3

==Server---------------------------------------------------------+ ==Client----------------
C> dotnet run					|
Listening for requests...				|
---------------------------------------------------------------------| PS1> (iwr -Uri "http://localhost:8080/end" -ErrorAction SilentlyContinue).RawContent
Received request: GET http://localhost:8080/end		| HTTP/1.1 200 OK
						| Content-Length: 4
						| Date: Sun, 25 Jun 2023 03:22:42 GMT
						| Server: Microsoft-HTTPAPI/2.0
						|
						| End.
C> dotnet run					|
Listening for requests...				|
---------------------------------------------------------------------| PS1> iwr -Uri "http://localhost:8080/api/v1/update-status"
==Output: Response Message==
StatusCode        : 200
StatusDescription : OK
Content           : {"code": "DATA_NOT_FOUND","message": "User not found","ref": 68451041449}
RawContent        : HTTP/1.1 200 OK
                    Content-Length: 73
                    Content-Type: application/json
                    Date: Sun, 25 Jun 2023 03:32:32 GMT
                    Server: Microsoft-HTTPAPI/2.0
                    
                    {"code": "DATA_NOT_FOUND","message": "User not found","ref": ...
Forms             : {}
Headers           : {[Content-Length, 73], [Content-Type, application/json], [Date, Sun, 25 Jun 2023 03:32:32 GMT], [Server, 
                    Microsoft-HTTPAPI/2.0]}
Images            : {}
InputFields       : {}
Links             : {}
ParsedHtml        : mshtml.HTMLDocumentClass
RawContentLength  : 73
---------------------------------------------------------------------| PS1> (iwr -Uri "http://localhost:8080/api/v1/update-status").Content
==Output: Response Message==
{"code": "DATA_NOT_FOUND","message": "User not found","ref": 68451041448}
---------------------------------------------------------------------| PS1> Invoke-RestMethod -Uri "http://localhost:8080/api/v1/update-status"
code           message                ref
----           -------                ---
DATA_NOT_FOUND User not found 68451041447
---------------------------------------------------------------------| PS1> Invoke-RestMethod -Uri "http://localhost:8080/api/v1/update-status" | ConvertTo-Json
{
    "code":  "DATA_NOT_FOUND",
    "message":  "User not found",
    "ref":  68451041446
}
---------------------------------------------------------------------| PS1> Invoke-RestMethod -Uri "http://localhost:8080/api/v1/update-status" -Method POST -Body (@{employee_id=1;status=@{code="00";message="register complete"}}|ConvertTo-Json) | ConvertTo-Json
{
    "code":  "SUCCESS",
    "message":  "Success",
    "ref":  68451041437
}
---------------------------------------------------------------------| PS1> Invoke-RestMethod -Uri "http://localhost:8080/api/v1/employee-profile"
GET - http://localhost:8080/api/v1/employee-profile; /api/v1/employee-profile; http://localhost:8080/api/v1/employee-profile; 68451041449(0)
---------------------------------------------------------------------| PS1> Invoke-RestMethod -Uri "http://localhost:8080/api/v1/employee-profile" -Method POST
POST - http://localhost:8080/api/v1/employee-profile; /api/v1/employee-profile; http://localhost:8080/api/v1/employee-profile; 68451041445(0)
---------------------------------------------------------------------| PS1> Invoke-RestMethod -Uri "http://localhost:8080/api/v1/employee-profile" -Method PUT
PUT - http://localhost:8080/api/v1/employee-profile; /api/v1/employee-profile; http://localhost:8080/api/v1/employee-profile; 68451041444(0)
---------------------------------------------------------------------| PS1> $body = @{"thai_id"="696c01a8b502c8c26356f148d853e77868d4f598dd915302fc68d3742e28553300000371cp_axtra_public_co_ltd";employee_id="00000371"}
						| PS1> Invoke-RestMethod -Uri "http://localhost:8080/api/v1/employee-profile" -Method POST -Body ($body|ConvertTo-Json) | ConvertTo-Json
{
    "ref":  68451041448,
    "code":  "SUCCESS",
    "message":  "Success",
    "data":  {
                 "employee_id":  "12345",
                 "mobile":  "0834567890",
                 "job_title":  "programmer",
                 "income_range":  "7",
                 "email":  "test@cpmatch.com",
                 "age":  "28",
                 "employee_start_date":  "2020-03-12",
                 "employee_end_date":  "2023-03-12",
                 "employee_type":  "fulltime",
                 "custom01":  "",
                 "custom02":  "",
                 "custom03":  "",
                 "custom04":  "",
                 "custom05":  "",
                 "custom06":  "",
                 "custom07":  "",
                 "custom08":  "",
                 "custom09":  "",
                 "custom10":  ""
             }
}
---------------------------------------------------------------------| PS1> Invoke-RestMethod -Uri "http://localhost:8080/api/v1/employee-profile" -Method POST -Body ($body|ConvertTo-Json)
        ref code    message data                                                                                                      
        --- ----    ------- ----                                                                                                      
68451041447 SUCCESS Success @{employee_id=12345; mobile=0834567890; job_title=programmer; income_range=7; email=test@cpmatch.com; a...


