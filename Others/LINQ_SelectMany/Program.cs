// It works like a Cross Join

// Example 1
var users = new List<User>
{
    new User { UserName = "Reza" , Roles = new List<string>{"Superadmin" } },
    new User { UserName = "Amin" , Roles = new List<string>{"Guest","Reseption" } },
    new User { UserName = "Nima" , Roles = new List<string>{"Nurse","Guest" } },
};

var query = users.SelectMany(user => user.Roles);

foreach (var obj in query)
{
    Console.WriteLine(obj);
}
Console.WriteLine("- - - - - - - - - - -");

// Example 2
List<string> animals = new() { "cat", "dog", "donkey" };
List<int> number = new List<int>() { 10, 20 };

var mix = number.SelectMany(num => animals).Distinct();

foreach (var item in mix)
{
    Console.WriteLine(item);
}

