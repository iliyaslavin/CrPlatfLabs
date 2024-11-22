using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab6.Data;
using Lab6.Models;

[Route("api/[controller]")]
[ApiController]
public class AssetsController : ControllerBase
{
    private readonly Lab6DbContext _context;

    public AssetsController(Lab6DbContext context)
    {
        _context = context;
    }

    // Отримання всіх активів
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
    {
        return await _context.Assets.ToListAsync();
    }

    // Отримання активу за ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Asset>> GetAsset(int id)
    {
        var asset = await _context.Assets.FindAsync(id);
        if (asset == null)
        {
            return NotFound();
        }
        return asset;
    }

    // Додавання нового активу
    [HttpPost]
    public async Task<ActionResult<Asset>> PostAsset(Asset asset)
    {
        _context.Assets.Add(asset);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetAsset", new { id = asset.AssetId }, asset);
    }

    // Оновлення активу
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsset(int id, Asset asset)
    {
        if (id != asset.AssetId)
        {
            return BadRequest();
        }
        _context.Entry(asset).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Assets.Any(e => e.AssetId == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // Видалення активу
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsset(int id)
    {
        var asset = await _context.Assets.FindAsync(id);
        if (asset == null)
        {
            return NotFound();
        }

        _context.Assets.Remove(asset);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // Пошук активів за ім'ям та датою придбання
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Asset>>> SearchAssets([FromQuery] string name, [FromQuery] DateTime? acquiredAfter)
    {
        var query = _context.Assets.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(a => a.AssetName.Contains(name));

        if (acquiredAfter.HasValue)
            query = query.Where(a => a.AssetAcquiredDate > acquiredAfter.Value);

        return await query.ToListAsync();
    }

    // Пошук запчастин за списком ID
    [HttpGet("search-by-list")]
    public async Task<ActionResult<IEnumerable<Part>>> SearchParts([FromQuery] List<int> partIds)
    {
        var parts = await _context.Parts
            .Where(p => partIds.Contains(p.PartId))
            .ToListAsync();

        return parts;
    }

    // Отримання об'єднаних даних через JOIN
    [HttpGet("joined-data")]
    public async Task<ActionResult<IEnumerable<object>>> GetJoinedData()
    {
        var result = await (from asset in _context.Assets
                            join part in _context.AssetParts on asset.AssetId equals part.AssetId
                            select new
                            {
                                AssetName = asset.AssetName,
                                PartName = part.Part.PartName
                            }).ToListAsync();

        return Ok(result);
    }

    [HttpGet("convert-time")]
    public ActionResult<string> ConvertTimeToUkraineTime([FromQuery] string inputTime)
    {
        try
        {
            // Спробуємо парсити дату та час
            if (DateTime.TryParse(inputTime, out var parsedTime))
            {
                // Конвертація в час України (GMT+2/+3)
                var ukraineTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time"); // Windows: "FLE Standard Time", Linux: "Europe/Kiev"
                var ukraineTime = TimeZoneInfo.ConvertTimeFromUtc(parsedTime.ToUniversalTime(), ukraineTimeZone);

                // Повертаємо у форматі "yyyy-MM-dd HH:mm:ss"
                return Ok(ukraineTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                // Якщо формат дати некоректний
                return BadRequest("Invalid date/time format. Please provide a valid date and time.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

}
