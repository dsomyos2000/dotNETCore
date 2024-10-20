@echo off
for /f "delims=" %%A in ('net helpmsg %1') do echo %1 - %%A