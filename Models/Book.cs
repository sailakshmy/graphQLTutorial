public class Book : MyReadingMaterials,IThings  {
    public int BookId { get; set; }
    public string Name { get; set; }
    public int Pages { get; set; }
    public double Price {get; set;}
    public DateTime? PublishedDate {get; set;}
    public Author? Author{get;set;}
    public BookGenre Genre{get;set;} 
    public BookReview[]? Reviews{ get;set;}
}

public enum BookGenre {
    Horror,
    Fantasy,
    Drama,
    Thriller,
    NonFiction
}