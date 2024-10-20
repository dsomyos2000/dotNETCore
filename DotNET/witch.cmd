@echo off
REM This bat searches a file in PATH list to see whether a file can be found.
REM If found, it shows the file's full path.
REM     which.bat gcc.exe
REM shows
REM     gcc.exe is found: D:\GMU\MinGW2\bin\gcc.exe
REM 
REM Note: Filename extension is significant in the search. E.g. If you run
REM     which.bat gcc
REM gcc.exe will not be matched.

IF "%1" == "" goto END

IF "%~$PATH:1" == "" (
      echo %1 is not found in any directories from PATH env-var.
    ) ELSE (
      echo %1 is found: %~$PATH:1
    )

:END