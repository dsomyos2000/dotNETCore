csc /target:library MetricSystem.cs 
Rem #example# C:\> csc /target:library /out:DesiredNameOfLibrary.dll file-name.cs

csc /r:Algebra.dll,MetricSystem.dll Program.cs 
