using System.Text.Json;

var twitchStreamers = new[] {
    "alex",
    "ion",
    "vasile",
    "cristi",
    "ioana",
    "simina"
};

var third = twitchStreamers[^2];
var slice = twitchStreamers[2..4];
var firstTwo = twitchStreamers[..2];
var fromIndex2 = twitchStreamers[2..];
var lastTwotest = twitchStreamers[^2..];

Console.WriteLine(JsonSerializer.Serialize(third));
Console.WriteLine(JsonSerializer.Serialize(slice));
Console.WriteLine(JsonSerializer.Serialize(firstTwo));
Console.WriteLine(JsonSerializer.Serialize(fromIndex2));
Console.WriteLine(JsonSerializer.Serialize(lastTwotest));

