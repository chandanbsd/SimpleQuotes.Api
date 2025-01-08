using Microsoft.EntityFrameworkCore;
using SimpleQuotes.Business.Services.Interfaces;
using Dtos = SimpleQuotes.Contracts.Dtos;
using SimpleQuotes.Data.Context;
using SimpleQuotes.Data.Entities;

namespace SimpleQuotes.Business.Services;

public class SimpleQuoteService: ISimpleQuoteService
{
    private SimpleQuoteContext _dbContext;

    public SimpleQuoteService(SimpleQuoteContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<IEnumerable<Dtos.Quote>> GetQuotes()
    {
        return await _dbContext
            .Quotes
            .Select(q => new Dtos.Quote
            {
                QuoteGuid = q.Guid,
                Text = q.Text,
                Description = q.Description,
                AuthorGuid = q.Author.Guid,
                AuthorName = q.Author.Name
            })
            .ToListAsync();
    }
    
    public async Task<Dtos.Quote> GetQuote(Guid guid)
    {
        return await _dbContext
            .Quotes
            .Where(q => q.Guid == guid)
            .Select(q => new Dtos.Quote
            {
                QuoteGuid = q.Guid,
                Text = q.Text,
                Description = q.Description,
                AuthorGuid = q.Author.Guid,
                AuthorName = q.Author.Name
            })
            .SingleAsync();
    }
    
    public async Task<IEnumerable<Dtos.Author>> GetAuthors()
    {
        return await _dbContext
            .Authors
            .Select(a => new Dtos.Author
            {
                AuthorGuid = a.Guid,
                AuthorName = a.Name
            })
            .ToListAsync();
    }
    
    public async Task<Dtos.Author> GetAuthor(Guid authorGuid)
    {
        return await _dbContext
            .Authors
            .Where(a => a.Guid == authorGuid)
            .Select(a => new Dtos.Author
            {
                AuthorGuid = a.Guid,
                AuthorName = a.Name
            })
            .SingleAsync();
    }
}