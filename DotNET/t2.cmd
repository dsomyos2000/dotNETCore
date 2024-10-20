@echo on

%comspec% /C FOR %%n in (1 2) do PROMPT SET _date=$d$_ | find /V "PROMPT" > temp.bat
call temp.bat
del temp.bat

echo currentDate is %_date%
