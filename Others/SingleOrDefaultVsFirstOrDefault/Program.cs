// https://www.youtube.com/watch?v=ZTWl2s8ScMc&ab_channel=NickChapsas

using BenchmarkDotNet.Running;
using SingleOrDefaultVsFirstOrDefault;

#region Example 1

//#region Console example

//var users = new List<string> {
//    "Nick Chapsas",
//    "Chap Nicksas",
//    "Sas Nickchap"
//};

//// First, FirstOrDefault

//var first1 = users.First();                             // the first item in the list
//var first2 = users.First(x => x.StartsWith("Chap"));    // the first item that start with "Chap"
////var first3 = users.First(x => x.StartsWith("das"));   // Error

//var firstOrDefault1 = users.FirstOrDefault(x => x.StartsWith("das"), "N/A"); // "N/A"( or NULL if we don't set default value)

//Console.WriteLine(first1);
//Console.WriteLine(first2);
////Console.WriteLine(first3);
//Console.WriteLine(firstOrDefault1);


//// Single, SingleOrDefault

//var single1 = users.Single();                           // Error
//var single2 = users.Single(x => x.StartsWith("Chap"));  // Chap
//var single3 = users.Single(x => x.StartsWith("das"));   // Error

//var singleOrDefault = users.SingleOrDefault(x => x.StartsWith("das"), "N/A");

//#endregion
#endregion

#region Example 2

#region Service example

BenchmarkRunner.Run<Benchmarks>();

#endregion

#endregion

