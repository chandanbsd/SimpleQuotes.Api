namespace SimpleQuotes.Business.Services.Interfaces;
using Dtos = SimpleQuotes.Contracts.Dtos;

public interface ISimpleQuoteService
{

    Task<IEnumerable<Dtos.Quote>> GetQuotes();
  
    Task<Dtos.Quote> GetQuote(Guid guid);

    Task<IEnumerable<Dtos.Author>> GetAuthors();

    Task<Dtos.Author> GetAuthor(Guid authorGuid);


}