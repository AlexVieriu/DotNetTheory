// https://www.youtube.com/watch?v=Mno9As1SaCc&ab_channel=Ted%27sTech
// add <LangVersion>Preview</LangVersion>


// Ex1: Newlines in the "holes" of the interpolated strings

using System.Text;

var channel = new Channel();

Console.WriteLine($"The first subscriber: " +
    $"{channel
      .Subscribers
      .First()}");


// Ex2: List patterns
// C# 10
var firstSub10 = channel.Subscribers.First() == "Gary";
var firstLastSub10 = channel.Subscribers.First() == "Gary" && channel.Subscribers.Last() == "Steve";

Console.WriteLine(firstSub10);
Console.WriteLine(firstLastSub10);

// C# 11
var firstSub11 = channel.Subscribers is ["Gary", ..];
var firstLastSub11 = channel.Subscribers is ["Gary", .., "Steve"];

Console.WriteLine(firstSub11);
Console.WriteLine(firstLastSub11);

if (channel.Subscribers is [_, "Barry", .. var dsadsa, "Steve"]) // for List<> doesn't work; all from the above works
{
    foreach (var sub in dsadsa)
    {
        Console.WriteLine(sub);
    }
}

// Ex3: Raw String Literals
// C#10
var json10 = @"{
    ""Subscribers"" : 2000,
    ""Likes"" : 100
}";
Console.WriteLine(json10);

//C#11
var subCount = 3000;

var json11 = $$"""
{
    "Subscribers" : {{subCount}},
    "Likes" : 100;
}
""";
Console.WriteLine(json11);


// Ex4: Auto Default Structs
// C#10
// we need to default both Subscribers and Likes in the ctor

// C#11
// we can only add only one


// Ex5: UTF-8 String Literals
// C#10
var name10 = "Ted";
byte[] nameBytes10 = Encoding.UTF8.GetBytes(name10);  // will be analized at Runtime
ReadOnlyMemory<byte> nameSpan10 = nameBytes10;        // will be analized at Runtime

// C#11
var name11 = "Ted";
byte[] nameBytes11 = "Ted"u8;
ReadOnlySpan<byte> u8Span = "ABC"u8;

// Ex6: Switches on Read Only Spans
// C#10
static bool IsTed10(ReadOnlySpan<byte> span)
{
    if (Encoding.UTF8.GetString(span) == "Ted") return true;
    if (Encoding.UTF8.GetString(span) == "Ed") return true;
    return false;
}


// C#11 
static bool IsTed11(ReadOnlySpan<char> span)
{
    return span switch
    {
        "Ted" => true,
        "Ed" => false,
        _ => false
    };
}


public class Channel
{
    public int SubCount => Subscribers.Length;

    public string[] Subscribers = new string[]
    {
        "Gary",
        "Barry",
        "Nigel",
        "Steve"
    };

    public void Subscribe() { }
}

public struct ChannelInfo
{
    public int Subscribers;
    public int Likes;

    public ChannelInfo()
    {
        Subscribers = 0;
    }
}

