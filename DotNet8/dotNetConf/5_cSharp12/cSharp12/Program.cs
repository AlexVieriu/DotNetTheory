using Grade1 = System.Decimal;      // C#1
using Grade2 = decimal;             // C#12
using Grade3 = (string, decimal);   // C#12 Tuple 

var mads = new Student1("Mads Torgersen", 900751, new[] { 3.5m, 2.9m, 1.8m });

WriteLine(mads);


// Records -> C#9
public record class Student1(string Name, int Id, Grade2[] Grades)
{
    public Student1(string name, int id) : this(name, id, Array.Empty<Grade2>()) { }

    public Grade2 GPA => Grades switch
    {
    [] => 4.0m,
    [var grade] => grade,
    [.. var all] => all.Average()
    };
}

// Primary Constructors -> C#12
public class Student2(string name, int id, Grade2[] grades)
{
    public Student2(string name, int id) : this(name, id, Array.Empty<Grade2>()) { }

    public string Name { get; set; } = name;
    private int id = id;

    private readonly string name = name;
    public int Id => name.Length;

    public Grade2 GPA => grades switch
    {
    [] => 4.0m,
    [var grade] => grade,
    [.. var all] => all.Average()
    };
}