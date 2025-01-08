using SimpleQuotes.Data.Entities.Interface;

namespace SimpleQuotes.Data.Entities;

public class User: Audit
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

    
    public string FirstName { get; private set; }
    
    public string LastName { get; private set; }
    
    public string UserName { get; private set; }
    
    public string Email { get; private set; }
    
    public string Password { get; private set; }
    
    public ICollection<Author> AuthorsModified { get; private set; }
    
    public ICollection<Quote> QuotesModified { get; private set; }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string username,
        string password,
        int createdById)
    {
        return new User
        {
            Guid = Guid.NewGuid(),   
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            UserName = username,
            Password = password,
            CreatedById = createdById,
            CreatedOn = DateTime.UtcNow,
        };
    }
    
    public void Update(
        string firstName,
        string lastName,
        string email,
        string username,
        string password,
        int updatedById)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = username;
        Password = password;
        UpdatedById = updatedById;
        UpdatedOn = DateTime.UtcNow;
    }
    
    public void Inactivate(int updatedById)
    {
        UpdatedById = updatedById;
        UpdatedOn = DateTime.UtcNow;
        IsActive = false;
    }
}