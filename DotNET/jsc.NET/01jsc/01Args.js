import System;

print(System.Environment.CommandLine);

var args = System.Environment.GetCommandLineArgs();
for (var argNo in args) {
   print(args[argNo]);
}