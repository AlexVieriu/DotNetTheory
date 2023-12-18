using System.Reflection;
using static System.Console;

//var classTypes = Assembly.GetEntryAssembly()?
//    .GetTypes()
//    .Where(t => t.IsClass && t.IsPublic)
//    .ToList();

//if (classTypes is not null)
//{
//    foreach (var classType in classTypes)
//    {
//        WriteLine(classType.FullName);
//    }
//}

// (18:30)
if(ClassListGenerator.ClassNames.Name is not null)
{
    foreach (var c in ClassListGenerator.ClassNames.Name)
    {
        WriteLine(c);
       
    }   
}

