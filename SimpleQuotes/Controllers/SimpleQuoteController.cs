using Microsoft.AspNetCore.Mvc;
using SimpleQuotes.Business.Services.Interfaces;
using SimpleQuotes.Contracts.Dtos;

namespace SimpleQuotes.Controllers;

public class SimpleQuoteController : Controller
{
    private readonly ISimpleQuoteService _simpleQuoteService;
    
    SimpleQuoteController(ISimpleQuoteService simpleQuoteService)
    {
        _simpleQuoteService = simpleQuoteService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
    {
        try
        {
            var res = await _simpleQuoteService.GetQuotes();
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    
    public async Task<ActionResult<Quote>> GetQuote(Guid guid)
    {
        try
        {
            var res = await _simpleQuoteService.GetQuote(guid);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
    
    public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
    {
        var res = await _simpleQuoteService.GetAuthors();
        return Ok(res);
    }
    
    public async Task<ActionResult<Author>> GetAuthor(Guid authorGuid)
    {
        try
        {
            var res = await _simpleQuoteService.GetAuthor(authorGuid);
            return Ok(res);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
}