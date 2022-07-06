using SingleOrDefaultVsFirstOrDefault;

/*
Tutorial:
http://www.technicaloverload.com/linq-single-vs-singleordefault-vs-first-vs-firstordefault/

https://stackoverflow.com/questions/69765829/ef-core-firstordefault-vs-singleordefault-performance-comparison
*/

var employeers = new List<Employeer>() {
    new Employeer(){ Employeeid = 1, LastName = "Davolio",  FirstName = "Nancy",    Birthdate=DateTime.Now},
    new Employeer(){ Employeeid = 2, LastName = "Fuller",   FirstName = "Andrew",   Birthdate=DateTime.Now},
    new Employeer(){ Employeeid = 3, LastName = "Leverling",FirstName = "Janet",    Birthdate=DateTime.Now},
    new Employeer(){ Employeeid = 4, LastName = "Peacock",  FirstName = "Margaret", Birthdate=DateTime.Now},
    new Employeer(){ Employeeid = 5, LastName = "Buchanan", FirstName = "Robert",   Birthdate=DateTime.Now},
    new Employeer(){ Employeeid = 6, LastName = "Suyama",   FirstName = "Michael",  Birthdate=DateTime.Now},
    new Employeer(){ Employeeid = 7, LastName = "King",     FirstName = "Robert",   Birthdate=DateTime.Now},
    new Employeer(){ Employeeid = 8, LastName = "Callahan", FirstName = "Laura",    Birthdate=DateTime.Now},
    new Employeer(){ Employeeid = 9, LastName = "Dodsworth",FirstName = "Anne",     Birthdate=DateTime.Now}
};


//// -- Single --
//var oneRecord = employeers.Single(e => e.Employeeid == 1);             // Should return this record.
//var multipleRecords = employeers.Single(e => e.FirstName == "Robert"); // InvalidOperationException
//var noRecord = employeers.Single(e => e.Employeeid == 10);             // InvalidOperationException

//Console.WriteLine(oneRecord);
//Console.WriteLine(multipleRecords);
//Console.WriteLine(noRecord);


//// -- SingleOrDefault --
//var oneRecord = employeers.SingleOrDefault(e => e.Employeeid == 1);             // Should return this record.
//var multipleRecords = employeers.SingleOrDefault(e => e.FirstName == "Robert"); // InvalidOperationException
//var noRecord = employeers.SingleOrDefault(e => e.Employeeid == 10);             // NULL

//Console.WriteLine(oneRecord);
//Console.WriteLine(multipleRecords);
//Console.WriteLine(noRecord);


//// -- First --
//var oneRecord = employeers.First(e => e.Employeeid == 1);                       // Should return this record.
//var multipleRecords = employeers.First(e => e.FirstName == "Robert");           // Shloud return first record
//var noRecord = employeers.First(e => e.Employeeid == 10);                       // InvalidOperationException

//Console.WriteLine(oneRecord);
//Console.WriteLine(multipleRecords);
//Console.WriteLine(noRecord);


//// -- FirstOrDefault --
//var oneRecord = employeers.First(e => e.Employeeid == 1);                       // Should return this record.
//var multipleRecords = employeers.First(e => e.FirstName == "Robert");           // Shloud return first record
//var noRecord = employeers.First(e => e.Employeeid == 10);                       // NULL

//Console.WriteLine(oneRecord);
//Console.WriteLine(multipleRecords);
//Console.WriteLine(noRecord);




