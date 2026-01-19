using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Program started");

        MethodA();

        ValueVsReferenceDemo();
        VarVsDynamicDemo();
        NullableValueDemo();
        NullableReferenceDemo();

        Console.WriteLine("Program ended");
        Console.ReadLine(); // keep process alive
    }

    static void MethodA()
    {
        Console.WriteLine("Inside MethodA");
    }

    static void ValueVsReferenceDemo()
    {
        Console.WriteLine("=== VALUE TYPE DEMO ===");

        int a = 10;
        int b = a;      // copy
        b = 20;

        Console.WriteLine($"a = {a}"); // 10
        Console.WriteLine($"b = {b}"); // 20

        Console.WriteLine();
        Console.WriteLine("=== REFERENCE TYPE DEMO ===");

        Person p1 = new Person { Name = "Alice" };
        Person p2 = p1;     // reference copy
        p2.Name = "Bob";

        Console.WriteLine($"p1.Name = {p1.Name}"); // Bob
        Console.WriteLine($"p2.Name = {p2.Name}"); // Bob

        Console.WriteLine();
        Console.WriteLine("=== STRUCT VS CLASS METHOD CALL ===");

        CounterStruct cs = new CounterStruct { Value = 5 };
        CounterClass cc = new CounterClass { Value = 5 };

        static void IncrementClass(CounterClass c)
        {
            c.Value++;
        }

        static void IncrementStruct(CounterStruct c)
        {
            c.Value++;
        }

        IncrementStruct(cs);
        IncrementClass(cc);

        Console.WriteLine($"Struct Value after method call = {cs.Value}"); // 5
        Console.WriteLine($"Class Value after method call  = {cc.Value}"); // 6
    }


    static void VarVsDynamicDemo()
    {
        Console.WriteLine("=== VAR DEMO (Compile-time) ===");

        var number = 10;        // compiler infers int
                                // number = "hello";    // ❌ compile-time error

        Console.WriteLine($"number type = {number.GetType()}");
        Console.WriteLine($"number + 5 = {number + 5}");

        Console.WriteLine();
        Console.WriteLine("=== DYNAMIC DEMO (Runtime) ===");

        dynamic value = 10;
        Console.WriteLine($"value type at runtime = {value.GetType()}");

        try
        {
            // Compiles fine, fails at runtime
            value = value.ToUpper();
        }
        catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
        {
            Console.WriteLine("Runtime error using dynamic:");
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();
        Console.WriteLine("=== VAR WITH COMPLEX TYPE ===");

        var list = new List<int> { 1, 2, 3 };
        Console.WriteLine($"list type = {list.GetType()}");

         //list.Add("test"); // ❌ compile-time error
    }


    static void NullableValueDemo()
    {
        Console.WriteLine("=== NULLABLE VALUE TYPES DEMO ===");

        int? age = null;

        Console.WriteLine($"age.HasValue = {age.HasValue}");

        if (age.HasValue)
        {
            Console.WriteLine($"age.Value = {age.Value}");
        }
        else
        {
            Console.WriteLine("age is null");
        }

        Console.WriteLine();
        Console.WriteLine("=== NULL-COALESCING OPERATOR ===");

        int actualAge = age ?? 18;
        Console.WriteLine($"actualAge = {actualAge}");

        Console.WriteLine();
        Console.WriteLine("=== NULLABLE VALUE ASSIGNMENT ===");

        int? score = 90;
        int safeScore = score ?? 0;

        Console.WriteLine($"score = {score}");
        Console.WriteLine($"safeScore = {safeScore}");

        Console.WriteLine();
        Console.WriteLine("=== INVALID DIRECT ASSIGNMENT ===");

        // int x = age; // ❌ compile-time error
        //Console.WriteLine("Direct assignment from int? to int is not allowed.");

        Console.WriteLine();
        Console.WriteLine("=== GET VALUE OR DEFAULT ===");

        Console.WriteLine($"age.GetValueOrDefault() = {age.GetValueOrDefault()}");
    }


    static void NullableReferenceDemo()
    {
        Console.WriteLine("=== NULLABLE REFERENCE TYPES DEMO ===");

        string nonNullableName = "Alice";
         //nonNullableName = null;   // ⚠ compiler warning

        string? nullableName = null; // OK

        Console.WriteLine();
        Console.WriteLine("=== COMPILER FLOW ANALYSIS ===");

        if (nullableName != null)
        {
            // compiler knows nullableName is not null here
            Console.WriteLine(nullableName.Length);
        }

        Console.WriteLine();
        Console.WriteLine("=== NULL-FORGIVING OPERATOR ===");

        string forcedNonNull = nullableName!; // suppress warning
        Console.WriteLine("Null-forgiving operator used (dangerous).");

        Console.WriteLine();
        Console.WriteLine("=== METHOD CONTRACTS ===");

        PrintLength(nullableName!);
        PrintLengthSafe(nullableName);
    }

    static void PrintLength(string name)
    {
        // name is assumed non-null by compiler
        if (name is not null) { Console.WriteLine($"Length = {name.Length}"); }
    }

    static void PrintLengthSafe(string? name)
    {
        if (name is null)
        {
            Console.WriteLine("Name is null");
            return;
        }

        Console.WriteLine($"Length = {name.Length}");
    }


}

class Person
{
    public string Name { get; set; }
}


struct CounterStruct
{
    public int Value;
}

class CounterClass
{
    public int Value;
}

