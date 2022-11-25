// Example 1 

string[] fruits = { "apple", "mango", "orange", "passionfruit", "grape" };

// Determine whether any string in the array is longer than "banana".
string longestName = fruits.Aggregate("banana",
                                        (longest, next) =>
                                            next.Length > longest.Length ? next : longest,
                                            fruit => fruit.ToUpper()
                                     );

Console.WriteLine("The fruit with the longest name is {0}", longestName);
Console.WriteLine("- - - - - - - - - - - - - - - - - -");


// Example 2 
var nums = new[] { 1, 2, 3, 4 };
var sum = nums.Aggregate((a, b) => a + b);
Console.WriteLine(sum); // output: 10 (1+2+3+4)


// Example 3
var chars = new[] { "a", "b", "c", "d" };
var csv = chars.Aggregate((a, b) => a + ',' + b);
Console.WriteLine(csv); // Output a,b,c,d
Console.WriteLine(" - - - - - - - - - - - - - - - - - -");


// Example 4

var multipliers = new[] { 10, 20, 30, 40 };
var multiplied = multipliers.Aggregate(5, (a, b) => a * b);
Console.WriteLine(multiplied); //Output 1200000 ((((5*10)*20)*30)*40)