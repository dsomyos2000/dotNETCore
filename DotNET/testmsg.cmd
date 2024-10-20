msg * /W "#1 - Enter Your Message"

start "" cmd /wait /c "echo #2 - Hello world!&echo(&pause"

echo msgbox "Hey! Here is a message!" > %tmp%\tmp.vbs
cscript /nologo %tmp%\tmp.vbs
del %tmp%\tmp.vbs