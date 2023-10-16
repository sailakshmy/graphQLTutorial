using System.Text.Json;
using System.Text.Json.Serialization;

public class Query
{
    // public List<Book> Books => ReadBooks();   
    public List<Magazine> Magazines => ReadMagazines();
    public List<MyReadingMaterials> ReadingMaterials => GetReadingMaterials();
    public List<IThings> Things => GetThings();
    // private List<Book> ReadBooks()  {
    //     string fileName = "Database/books.json";
    //     string jsonString = File.ReadAllText(fileName);
    //     return JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters={new JsonStringEnumConverter()} })!;
    // }
    public List<Book> Books(string nameContains="")  {
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);
        var books= JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters={new JsonStringEnumConverter()} })!;
        return books.Where(book=>book.Name.IndexOf(nameContains)!=-1).ToList();
    }
    private List<Magazine> ReadMagazines()  {
        string fileName = "Database/magazines.json";
        string jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<Magazine>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters={new JsonStringEnumConverter()} })!;
    }
    private List<MyReadingMaterials> GetReadingMaterials(){
        var materials = Books().Cast<MyReadingMaterials>().ToList();
        materials.AddRange(ReadMagazines().Cast<MyReadingMaterials>().ToList());
        return materials;
    }
    private List<IThings> GetThings(){
        var things = Books().Cast<IThings>().ToList();
        things.AddRange(ReadMagazines().Cast<IThings>().ToList());
        return things;
    }
}