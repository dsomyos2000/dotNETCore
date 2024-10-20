@echo off
if not exist csc.exe echo x > csc.exe
if not exist vbc.exe echo x > vbc.exe
if not exist jsc.exe echo x > jsc.exe
if not exist javac.exe echo x > javac.exe
if not exist java.exe echo x > java.exe

for %%I in (*.exe) do @echo %%~$PATH:I 
for %%I in (*.exe) do if "%%~zI"=="4" del %%I
