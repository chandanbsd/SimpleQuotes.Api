using Microsoft.EntityFrameworkCore.Metadata;
using SimpleQuotes.Data.Entities.Interface;

namespace SimpleQuotes.Data.Entities;

public class Author: Audit
{
    public Guid Guid {  get; private set; }
    
    public int Id { get; private set; }
    
    public int CreatedById { get; private set; }
    
    public User CreatedBy { get; private set; }
    
    public DateTime CreatedOn { get; private set; }
    
    public int UpdatedById { get;  private set; }
    
    public User UpdatedBy { get; private set; }

    
    public DateTime UpdatedOn { get; private set; }
    
    public bool IsActive { get; private set; }

    public string Name { get; private set; }
    
    public string Description { get; private set; }
    
    public ICollection<Quote> Quotes { get; private set; }

    public static Author Create(
        string name, 
        string description,
        int createdById)
    {
        return new Author
        {
            Name = name,
            Description = description,
            CreatedById = createdById,
            CreatedOn = DateTime.UtcNow,
            IsActive = true,
        };
    }
    
    public void Update(
        string name,
        string description,
        int updatedById)
    {
        Guid = Guid.NewGuid();
        Name = name;
        Description = description;
        UpdatedById = updatedById;
        UpdatedOn = DateTime.UtcNow;
        IsActive = true;
    }

    public void Inactivate(int inactivatedById)
    {
        IsActive = false;
        UpdatedById = inactivatedById;
    }
}