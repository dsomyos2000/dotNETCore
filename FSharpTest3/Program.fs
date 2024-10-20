// For more information see https://aka.ms/fsharp-console-apps
type Person = { Name: string; Age: int }
type Emp = { thai_id: string; employee_id: string }

printfn "Hello from F#"
let people = [| { Name = "John"; Age = 25 }; { Name = "Jane"; Age = 30 } |]
Array.iter (fun person -> printfn "%s" person.Name) people

let emp = [| 
  {thai_id="696c01a8b502c8c26356f148d853e77868d4f598dd915302fc68d3742e28553300000371cp_axtra_public_co_ltd"; employee_id="00000371"};
  {thai_id="103c4f8a17ed364cfcb537645c209c39d9ca9ca273c3ad20659ce3cbe531698e00000222cp_axtra_public_co_ltd"; employee_id="00000222"};
  {thai_id="eda466dffcf36ec29d346c28e9d9b71fc36b44c184fac3093a191adb5d3bcf7700000196cp_axtra_public_co_ltd"; employee_id="00000196"};
  {thai_id="eda466dffcf36ec29d346c28e9d9b71fc36b44c184fac3093a191adb5d3bcf7700000196cp_axtra_public_co_ltd"; employee_id="00000872"};
  {thai_id="eda466dffcf36ec29d346c28e9d9b71fc36b44c184fac3093a191adb5d3bcf7700000196cp_axtra_public_co_ltd"; employee_id="000001"}
|]

Array.iter (fun emp -> printfn "`%8s` - %s" emp.employee_id emp.thai_id) emp
