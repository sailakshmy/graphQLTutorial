using System.Text.Json;
using System.Text.Json.Serialization;

public class Query
{
    public List<Book> Books => ReadBooks();   
    public List<Magazine> Magazines => ReadMagazines();
    public List<MyReadingMaterials> ReadingMaterials => GetReadingMaterials();
    public List<IThings> Things => GetThings();
    private List<Book> ReadBooks()  {
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters={new JsonStringEnumConverter()} })!;
    }
    private List<Magazine> ReadMagazines()  {
        string fileName = "Database/magazines.json";
        string jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<Magazine>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters={new JsonStringEnumConverter()} })!;
    }
    private List<MyReadingMaterials> GetReadingMaterials(){
        var materials = ReadBooks().Cast<MyReadingMaterials>().ToList();
        materials.AddRange(ReadMagazines().Cast<MyReadingMaterials>().ToList());
        return materials;
    }
    private List<IThings> GetThings(){
        var things = ReadBooks().Cast<IThings>().ToList();
        things.AddRange(ReadMagazines().Cast<IThings>().ToList());
        return things;
    }
}