using EcoEast.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EcoEast.API.Controllers;
[ApiController]
[Route("api")]
public class ReferenceController(EcoEastDbContext db) : ControllerBase
{
 [HttpGet("cities")] public async Task<IActionResult> Cities()=>Ok(await db.Cities.AsNoTracking().ToListAsync());
 [HttpGet("suburbs")] public async Task<IActionResult> Suburbs([FromQuery]int? cityId) => Ok(await db.Suburbs.AsNoTracking().Where(x=>cityId==null||x.CityId==cityId).ToListAsync());
 [HttpGet("locations")] public async Task<IActionResult> Locations([FromQuery]int? suburbId) => Ok(await db.Locations.AsNoTracking().Where(x=>suburbId==null||x.SuburbId==suburbId).ToListAsync());
 [HttpGet("waste-solutions")] public async Task<IActionResult> WasteSolutions()=>Ok(await db.WasteSolutions.AsNoTracking().ToListAsync());
 [HttpGet("request-types")] public async Task<IActionResult> RequestTypes()=>Ok(await db.RequestTypes.AsNoTracking().ToListAsync());
 [HttpGet("statuses")] public async Task<IActionResult> Statuses()=>Ok(await db.Statuses.AsNoTracking().ToListAsync());
 [HttpGet("report-categories")] public async Task<IActionResult> ReportCategories()=>Ok(await db.ReportCategories.AsNoTracking().ToListAsync());
 [HttpGet("collection-types")] public async Task<IActionResult> CollectionTypes()=>Ok(await db.CollectionTypes.AsNoTracking().ToListAsync());
}
