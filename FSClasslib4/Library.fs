namespace FSClasslib4

type MyLibraryClass() =
    member this.SayHello() =
        printfn "Hello from MyLibrary!"

    member this.AddNumbers(a: int, b: int) =
        a + b

