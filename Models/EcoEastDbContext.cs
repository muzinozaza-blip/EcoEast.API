using Microsoft.EntityFrameworkCore;
namespace EcoEast.API.Models;
public class EcoEastDbContext : DbContext
{
    public EcoEastDbContext(DbContextOptions<EcoEastDbContext> options) : base(options) { }
    public DbSet<City> Cities => Set<City>();
    public DbSet<Suburb> Suburbs => Set<Suburb>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<WasteSolution> WasteSolutions => Set<WasteSolution>();
    public DbSet<Resident> Residents => Set<Resident>();
    public DbSet<Manager> Managers => Set<Manager>();
    public DbSet<ItAdmin> ItAdmins => Set<ItAdmin>();
    public DbSet<FieldWorker> FieldWorkers => Set<FieldWorker>();
    public DbSet<ResidentsWasteSolution> ResidentsWasteSolutions => Set<ResidentsWasteSolution>();
    public DbSet<WasteSolutionsSuburb> WasteSolutionsSuburbs => Set<WasteSolutionsSuburb>();
    public DbSet<RequestType> RequestTypes => Set<RequestType>();
    public DbSet<Status> Statuses => Set<Status>();
    public DbSet<ServiceRequest> ServiceRequests => Set<ServiceRequest>();
    public DbSet<ReportCategory> ReportCategories => Set<ReportCategory>();
    public DbSet<ReportSubmission> ReportSubmissions => Set<ReportSubmission>();
    public DbSet<ItemCategory> ItemCategories => Set<ItemCategory>();
    public DbSet<RecyclingGuide> RecyclingGuides => Set<RecyclingGuide>();
    public DbSet<CollectionType> CollectionTypes => Set<CollectionType>();
    public DbSet<WasteSchedule> WasteSchedules => Set<WasteSchedule>();
}
