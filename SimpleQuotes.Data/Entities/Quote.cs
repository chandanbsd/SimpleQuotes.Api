namespace SimpleQuotes.Data.Entities;

public class Quote
{
    public Guid Guid {  get; private set; }
    
    public int Id { get; private set; }
    
    public int CreatedById { get; private set; }
    
    public User CreatedBy { get; private set; }

    
    public DateTime CreatedOn { get; private set; }
    
    public int UpdatedById { get;  private set; }
    
    public User UpdatedBy { get; private set; }

    
    public DateTime UpdatedOn { get; private set; }
    
    public string Text { get; private set; }
    
    public string Description { get; private set; }
    
    public int AuthorId { get; private set; }
    
    public Author Author { get; private set; }
    
    public bool IsActive { get; private set; }
    
    public static Quote Create(
        string text, 
        string description,
        int authorId,
        int createdById)
    {
        return new Quote
        {
            Text = text,
            Description = description,
            AuthorId = authorId,
            CreatedById = createdById,
            CreatedOn = DateTime.UtcNow,
            IsActive = false,
        };
    }
    
    public void Update(
        string text,
        string description,
        int authorId,
        int updatedById)
    {
        Guid = Guid.NewGuid();
        Text = text;
        Description = description;
        authorId = authorId;
        UpdatedById = updatedById;
        UpdatedOn = DateTime.UtcNow;
        IsActive = false;
    }
    
    public void Inactivate(int inactivatedById)
    {
        IsActive = false;
        UpdatedById = inactivatedById;
    }
}