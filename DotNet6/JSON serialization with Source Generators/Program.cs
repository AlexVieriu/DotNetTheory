// Tutorial: https://www.youtube.com/watch?v=HhyBaJ7uisU&ab_channel=NickChapsas

using System.Text.Json;
using System.Text.Json.Serialization;

Person person = new() { FirstName = "Nick", LastName = "Cage" };

// normal way
var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
var nickCageText = JsonSerializer.Serialize(person, option);

// with Source Generators
var nickCageTextWithGenerators = JsonSerializer.Serialize(person, PersonJsonContext.Default.Person);
var nickCageDeserialized = JsonSerializer.Deserialize(nickCageTextWithGenerators,
                                                      PersonJsonContext.Default.Person);

Console.WriteLine(nickCageText);
Console.WriteLine(nickCageTextWithGenerators);
Console.WriteLine(nickCageDeserialized);


// Normal way
public class Person
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

// With Source Generators
[JsonSerializable(typeof(Person))]
[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default, 
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public partial class PersonJsonContext : JsonSerializerContext
{

}
