using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OliveOil.Data;
using OliveOil.Models;

namespace OliveOil.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OliveOilController : ControllerBase
{
    private readonly AppDbContext _context;

    public OliveOilController(AppDbContext dbContext) => _context = dbContext;

    [HttpGet("search-normal-linq")]
    public async Task<ActionResult<List<OliveOilProduct>>> Search(string term)
    {
        return await _context.OliveOilProducts
            .Where(p => p.Name.Contains(term))
            .ToListAsync();
    }

    [HttpGet("search-injection")]
    public async Task<ActionResult<List<OliveOilProduct>>> SearchVulnerable(string term)
    {
        string sql = "SELECT * FROM OliveOilProducts WHERE Name LIKE '%" + term + "%'";

        return await _context.OliveOilProducts
            .FromSqlRaw(sql)
            .ToListAsync();
    }

    [HttpGet("search-secure")]
    public async Task<ActionResult<List<OliveOilProduct>>> SearchSecure(string term)
    {
        var pattern = $"%{term}%";

        return await _context.OliveOilProducts
            .FromSql($"SELECT * FROM OliveOilProducts WHERE Name LIKE {pattern}")
            .ToListAsync();
    }
}
