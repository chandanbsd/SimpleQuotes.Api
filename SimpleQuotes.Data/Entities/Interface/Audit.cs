namespace SimpleQuotes.Data.Entities.Interface;

public abstract class Audit
{
    protected Guid Guid {  get; private set; }
    
    protected int Id { get; private set; }
    
    protected int CreatedById { get; private set; }
    
    protected DateTime CreatedOn { get; private set; }
    
    protected int UpdatedById { get;  set; }
    
    protected DateTime UpdatedOn { get; private set; }
    
    protected bool IsActive { get; private set; }
}