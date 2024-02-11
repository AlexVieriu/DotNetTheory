using Deconstruction;

var keyValuePair = new KeyValuePair<string, int>("Nick", 69);
var (key1, value) = new KeyValuePair<string, int>("Nick", 69);
var (key2, _) = new KeyValuePair<string, int>("Nick", 69);

// check the Datetime class and look at the Deconstruct properties
var (year, month, day) = new DateTime();

var (message, stackTrace) = new Exception();
