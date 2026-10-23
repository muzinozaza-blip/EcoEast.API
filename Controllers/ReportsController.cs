using EcoEast.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EcoEast.API.Controllers;
[ApiController]
[Route("api/reports")]
public class ReportsController(EcoEastDbContext db) : ControllerBase
{
 [HttpGet] public async Task<IActionResult> Get([FromQuery]int? residentId,[FromQuery]int? statusId) =>
  Ok(await db.ReportSubmissions.AsNoTracking().Where(x=>(residentId==null||x.ResidentId==residentId)&&(statusId==null||x.StatusId==statusId)).OrderByDescending(x=>x.SubmissionDate).ToListAsync());
 [HttpGet("{id:int}")] public async Task<IActionResult> GetOne(int id){var x=await db.ReportSubmissions.FindAsync(id);return x==null?NotFound():Ok(x);}
 [HttpPost] public async Task<IActionResult> Create(ReportSubmission input){
  if(input.ResidentId<=0||input.WsId<=0||input.CategoryId<=0)return BadRequest(new{message="Resident, service area and category are required."});
  if(!await db.Residents.AnyAsync(x=>x.ResidentId==input.ResidentId)||!await db.WasteSolutionsSuburbs.AnyAsync(x=>x.WsId==input.WsId)||!await db.ReportCategories.AnyAsync(x=>x.RepCategoryId==input.CategoryId))return BadRequest(new{message="Resident, service area or category does not exist."});
  if(input.StatusId==0)input.StatusId=1;
  if(!await db.Statuses.AnyAsync(x=>x.StatusId==input.StatusId))return BadRequest(new{message="Invalid status."});
  input.ReportId=0; input.SubmissionDate=DateTime.Now; input.ReviewedAt=null; db.ReportSubmissions.Add(input); await db.SaveChangesAsync(); return CreatedAtAction(nameof(GetOne),new{id=input.ReportId},input);
 }
 [HttpPatch("{id:int}/review")] public async Task<IActionResult> Review(int id,[FromBody] StatusUpdate body){
  var report=await db.ReportSubmissions.FindAsync(id);if(report==null)return NotFound();
  if(!await db.Statuses.AnyAsync(x=>x.StatusId==body.StatusId))return BadRequest(new{message="Invalid status."});
  report.StatusId=body.StatusId;report.ReviewedAt=DateTime.Now;await db.SaveChangesAsync();return Ok(report);
 }
 public record StatusUpdate(int StatusId);
}
