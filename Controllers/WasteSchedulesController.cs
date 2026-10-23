using EcoEast.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EcoEast.API.Controllers;
[ApiController]
[Route("api/waste-schedules")]
public class WasteSchedulesController(EcoEastDbContext db) : ControllerBase
{
 [HttpGet] public async Task<IActionResult> Get([FromQuery]int? workerId,[FromQuery]DateTime? from,[FromQuery]DateTime? to) =>
  Ok(await db.WasteSchedules.AsNoTracking().Where(x=>(workerId==null||x.WorkerId==workerId)&&(from==null||x.CollectionDate>=from)&&(to==null||x.CollectionDate<=to)).OrderBy(x=>x.CollectionDate).ThenBy(x=>x.CollectionTime).ToListAsync());
 [HttpGet("{id:int}")] public async Task<IActionResult> GetOne(int id){var x=await db.WasteSchedules.FindAsync(id);return x==null?NotFound():Ok(x);}
 [HttpPost] public async Task<IActionResult> Create(WasteSchedule input){
  if(!await db.FieldWorkers.AnyAsync(x=>x.WorkerId==input.WorkerId)||!await db.ServiceRequests.AnyAsync(x=>x.RequestId==input.RequestId)||!await db.CollectionTypes.AnyAsync(x=>x.CollectionId==input.CollectionTypeId))return BadRequest(new{message="Worker, service request or collection type does not exist."});
  input.ScheduleId=0; db.WasteSchedules.Add(input); var req=await db.ServiceRequests.FindAsync(input.RequestId); if(req!=null){req.StatusId=await db.Statuses.Where(s=>s.StatusName=="Scheduled").Select(s=>s.StatusId).FirstOrDefaultAsync();req.ScheduledDate=input.CollectionDate;}
  await db.SaveChangesAsync();return CreatedAtAction(nameof(GetOne),new{id=input.ScheduleId},input);
 }
}
