//https://stackoverflow.com/questions/33649501/difference-between-nameof-and-typeof

/*
Typeof: -> returns Type objects    
        -> it is often used as a parameter or as a variable or field. 
        -> the typeof operator is part of an expression that acquires the Type pointer.

Nameof: -> meanwhile, returns a string with a variable's name
        -> it works at compile-time
        -> it is a special compiler feature that simplifies some programs.

*/

Type _type = typeof(char);              // Store Type as field.

Console.WriteLine(_type);               // Value type pointer
Console.WriteLine(typeof(int));         // Value type
Console.WriteLine(typeof(byte));        // Value type
Console.WriteLine(typeof(Stream));      // Class type
Console.WriteLine(typeof(TextWriter));  // Class type
Console.WriteLine(typeof(Array));       // Class type
Console.WriteLine(typeof(int[]));       // Array reference type
Console.WriteLine("- - - - - - -");

int size = 100;
Console.WriteLine(nameof(size));
Console.WriteLine("- - - - - - -");
Console.WriteLine(nameof(Int16));       
Console.WriteLine(nameof(Byte));        
Console.WriteLine(nameof(Stream));      
Console.WriteLine(nameof(TextWriter));  
Console.WriteLine(nameof(Array));       
// Console.WriteLine(nameof(int[]));       // nu merge




