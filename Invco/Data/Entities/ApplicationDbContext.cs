using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Invco.Data.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Electronics" },
                new Category { Id = 2, CategoryName = "Furniture" },
                new Category { Id = 3, CategoryName = "Stationery" },
                new Category { Id = 4, CategoryName = "Vehicles" },
                new Category { Id = 5, CategoryName = "Maintenance Equipment" }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, DepartmentName = "Finance" },
                new Department { Id = 2, DepartmentName = "IT" },
                new Department { Id = 3, DepartmentName = "Academics" },
                new Department { Id = 4, DepartmentName = "Maintenance" },
                new Department { Id = 5, DepartmentName = "Housekeeping" }
            );

            modelBuilder.Entity<Asset>().HasData(
                new Asset { Id = 1, AssetName = "Laptop", AssetUser = "John Doe", SerialNumber = "LTP001", Purchasedate = DateTime.Parse("2023-01-10"), CategoryId = 1, DepartmentId = 2 },
                new Asset { Id = 2, AssetName = "Projector", AssetUser = "Jane Smith", SerialNumber = "PRJ002", Purchasedate = DateTime.Parse("2022-11-15"), CategoryId = 1, DepartmentId = 3 },
                new Asset { Id = 3, AssetName = "Office Chair", AssetUser = "Mike Brown", SerialNumber = "OFC003", Purchasedate = DateTime.Parse("2021-06-21"), CategoryId = 2, DepartmentId = 1 },
                new Asset { Id = 4, AssetName = "Whiteboard", AssetUser = "Sarah Johnson", SerialNumber = "WBD004", Purchasedate = DateTime.Parse("2020-09-05"), CategoryId = 3, DepartmentId = 3 },
                new Asset { Id = 5, AssetName = "Photocopier", AssetUser = "Robert Green", SerialNumber = "PHC005", Purchasedate = DateTime.Parse("2023-03-14"), CategoryId = 1, DepartmentId = 1 },
                new Asset { Id = 6, AssetName = "Server", AssetUser = "IT Admin", SerialNumber = "SRV006", Purchasedate = DateTime.Parse("2024-02-10"), CategoryId = 1, DepartmentId = 2 },
                new Asset { Id = 7, AssetName = "Desk", AssetUser = "Emma White", SerialNumber = "DSK007", Purchasedate = DateTime.Parse("2019-08-22"), CategoryId = 2, DepartmentId = 1 },
                new Asset { Id = 8, AssetName = "Van", AssetUser = "Logistics Team", SerialNumber = "VAN008", Purchasedate = DateTime.Parse("2022-12-30"), CategoryId = 4, DepartmentId = 4 },
                new Asset { Id = 9, AssetName = "Cleaning Machine", AssetUser = "Housekeeping", SerialNumber = "CLM009", Purchasedate = DateTime.Parse("2021-07-18"), CategoryId = 5, DepartmentId = 5 },
                new Asset { Id = 10, AssetName = "AC Unit", AssetUser = "Facility Manager", SerialNumber = "ACU010", Purchasedate = DateTime.Parse("2020-05-25"), CategoryId = 5, DepartmentId = 4 },
                new Asset { Id = 11, AssetName = "Tablet", AssetUser = "Dr. Adams", SerialNumber = "TAB011", Purchasedate = DateTime.Parse("2023-08-16"), CategoryId = 1, DepartmentId = 3 },
                new Asset { Id = 12, AssetName = "Bookshelf", AssetUser = "Library Staff", SerialNumber = "BSH012", Purchasedate = DateTime.Parse("2021-02-10"), CategoryId = 2, DepartmentId = 3 },
                new Asset { Id = 13, AssetName = "Camera", AssetUser = "Media Team", SerialNumber = "CAM013", Purchasedate = DateTime.Parse("2022-05-20"), CategoryId = 1, DepartmentId = 2 },
                new Asset { Id = 14, AssetName = "Microphone", AssetUser = "Event Coordinator", SerialNumber = "MIC014", Purchasedate = DateTime.Parse("2020-04-12"), CategoryId = 1, DepartmentId = 3 },
                new Asset { Id = 15, AssetName = "Filing Cabinet", AssetUser = "Admin Staff", SerialNumber = "FCB015", Purchasedate = DateTime.Parse("2019-10-08"), CategoryId = 2, DepartmentId = 1 },
                new Asset { Id = 16, AssetName = "Electric Generator", AssetUser = "Maintenance Staff", SerialNumber = "GEN016", Purchasedate = DateTime.Parse("2018-06-29"), CategoryId = 5, DepartmentId = 4 },
                new Asset { Id = 17, AssetName = "Smart TV", AssetUser = "Lounge", SerialNumber = "STV017", Purchasedate = DateTime.Parse("2023-04-05"), CategoryId = 1, DepartmentId = 3 },
                new Asset { Id = 18, AssetName = "Chairs", AssetUser = "Auditorium", SerialNumber = "CHR018", Purchasedate = DateTime.Parse("2021-11-23"), CategoryId = 2, DepartmentId = 3 },
                new Asset { Id = 19, AssetName = "Hand Truck", AssetUser = "Logistics", SerialNumber = "HDT019", Purchasedate = DateTime.Parse("2022-09-15"), CategoryId = 5, DepartmentId = 4 },
                new Asset { Id = 20, AssetName = "Fire Extinguisher", AssetUser = "Safety Officer", SerialNumber = "FEX020", Purchasedate = DateTime.Parse("2019-12-10"), CategoryId = 5, DepartmentId = 4 }
            );

        }
        
    }

}