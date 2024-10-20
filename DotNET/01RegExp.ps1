$file = 'C:\Users\somyos_dua.FREEWILLGROUP\Documents\DotNET\somefile.txt'

[regex]$regex = @'
(?ms)the value of (\S+)
(\d+)
'@

#Choose one
$text = Get-Content $file -Raw  # V3 Only
$text = [IO.File]::ReadAllText($file)  # V2 or V3


$regex.matches($text) |
foreach {
   New-object PSObject -Property @{
                                   Name = $_.groups[1].value
                                   Value = $_.groups[2].value
                                  }
        }|
  Select Name,Value |
  Format-Table -AutoSize