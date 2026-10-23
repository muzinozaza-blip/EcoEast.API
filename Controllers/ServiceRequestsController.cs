using EcoEast.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EcoEast.API.Controllers;
[ApiController]
[Route("api/service-requests")]
public class ServiceRequestsController(EcoEastDbContext db) : ControllerBase
{
 [HttpGet] public async Task<IActionResult> Get([FromQuery]int? residentId,[FromQuery]int? statusId) =>
  Ok(await db.ServiceRequests.AsNoTracking().Where(x=>(residentId==null||x.ResidentId==residentId)&&(statusId==null||x.StatusId==statusId)).OrderByDescending(x=>x.RequestId).ToListAsync());
 [HttpGet("{id:int}")] public async Task<IActionResult> GetOne(int id){var x=await db.ServiceRequests.FindAsync(id);return x==null?NotFound():Ok(x);}
 [HttpPost] public async Task<IActionResult> Create(ServiceRequest input){
  if(input.ResidentId<=0||input.WsId<=0||input.RequestTypeId<=0)return BadRequest(new{message="Resident, service area and request type are required."});
  if(!await db.Residents.AnyAsync(x=>x.ResidentId==input.ResidentId)||!await db.WasteSolutionsSuburbs.AnyAsync(x=>x.WsId==input.WsId)||!await db.RequestTypes.AnyAsync(x=>x.RequestTypeId==input.RequestTypeId))return BadRequest(new{message="Resident, service area or request type does not exist."});
  if(input.StatusId==0) input.StatusId=1;
  if(!await db.Statuses.AnyAsync(x=>x.StatusId==input.StatusId))return BadRequest(new{message="Invalid status."});
  input.RequestId=0; db.ServiceRequests.Add(input); await db.SaveChangesAsync(); return CreatedAtAction(nameof(GetOne),new{id=input.RequestId},input);
 }
 [HttpPatch("{id:int}/status")] public async Task<IActionResult> UpdateStatus(int id,[FromBody] StatusUpdate body){
  var request=await db.ServiceRequests.FindAsync(id); if(request==null)return NotFound();
  if(!await db.Statuses.AnyAsync(x=>x.StatusId==body.StatusId))return BadRequest(new{message="Invalid status."});
  request.StatusId=body.StatusId; await db.SaveChangesAsync(); return Ok(request);
 }
 public record StatusUpdate(int StatusId);
}
