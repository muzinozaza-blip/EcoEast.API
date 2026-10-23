using EcoEast.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EcoEast.API.Controllers;
[ApiController]
[Route("api")]
public class RecyclingController(EcoEastDbContext db):ControllerBase
{
 [HttpGet("recycling-guides")] public async Task<IActionResult> Guides()=>Ok(await db.RecyclingGuides.AsNoTracking().OrderBy(x=>x.ItemCategoryId).ToListAsync());
 [HttpGet("item-categories")] public async Task<IActionResult> Categories()=>Ok(await db.ItemCategories.AsNoTracking().ToListAsync());
 [HttpPost("recycling-guides")] public async Task<IActionResult> CreateGuide(RecyclingGuide input){
  if(!await db.ItemCategories.AnyAsync(x=>x.ItemCategoryId==input.ItemCategoryId)||!await db.Managers.AnyAsync(x=>x.ManagerId==input.ManagerId))return BadRequest(new{message="Item category or manager does not exist."});
  input.RecyclingId=0;input.DatePosted=DateTime.Today;db.RecyclingGuides.Add(input);await db.SaveChangesAsync();return Ok(input);
 }
}
