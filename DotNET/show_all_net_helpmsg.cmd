REM for /l %%i in (1,1,999) do @net helpmsg %%i 1>NUL 2>&1 && if `%ERRORLEVEL%`==`0` echo %%i & net helpmsg %%i | findstr /i "[a-z]"
@for /l %%i in (1,1,999) do @net helpmsg %%i 1>NUL 2>&1 && if `%ERRORLEVEL%`==`0` CALL showid-msg.cmd %%i
