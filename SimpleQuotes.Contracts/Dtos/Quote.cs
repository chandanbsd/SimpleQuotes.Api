namespace SimpleQuotes.Contracts.Dtos;

public class Quote
{
    public Guid QuoteGuid { get; set; }
    
    public string Text { get; set; }
    
    public string Description { get; set; }
    
    public Guid AuthorGuid { get; set; }
    
    public string AuthorName { get; set; }
}