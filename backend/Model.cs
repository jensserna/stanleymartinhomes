using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class SearchingContext : DbContext
{
    public DbSet<MetroArea> MetroAreas { get; set; }
    public DbSet<ProjectGroup> ProjectGroups { get; set; }
    public DbSet<Product> Products { get; set; }

    public string DbPath { get; }

    public SearchingContext()
    {
        var path = Directory.GetCurrentDirectory();
        DbPath = System.IO.Path.Join(path, "searching.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region MetroArea
        modelBuilder.Entity<MetroArea>().HasData(
            new MetroArea { MetroAreaId = 1006,
                            MetroAreaTitle = "Richmond",
                            MetroAreaStateAbr = "VA",
                            MetroAreaStateName = "Virginia" });

        modelBuilder.Entity<MetroArea>().HasData(
            new MetroArea { MetroAreaId = 1007,
                            MetroAreaTitle = "Atlanta",
                            MetroAreaStateAbr = "GA",
                            MetroAreaStateName = "Georgia" });

        modelBuilder.Entity<MetroArea>().HasData(
            new MetroArea { MetroAreaId = 1008,
                            MetroAreaTitle = "Charleston",
                            MetroAreaStateAbr = "SC",
                            MetroAreaStateName = "South Carolina" });
        #endregion

        #region ProjectGroup
        modelBuilder.Entity<ProjectGroup>().HasData(
            new ProjectGroup { ProjectGroupId = 23,
                            MetroAreaId = 1007,
                            FullName = "Edgewater",
                            Status = "a" });

        modelBuilder.Entity<ProjectGroup>().HasData(
            new ProjectGroup { ProjectGroupId = 25,
                            MetroAreaId = 1007,
                            FullName = "Inwood",
                            Status = "a" });
        
        modelBuilder.Entity<ProjectGroup>().HasData(
            new ProjectGroup { ProjectGroupId = 41,
                            MetroAreaId = 1008,
                            FullName = "Estuary at Bowen Village",
                            Status = "a" });

        modelBuilder.Entity<ProjectGroup>().HasData(
            new ProjectGroup { ProjectGroupId = 43,
                            MetroAreaId = 1008,
                            FullName = "Mixson",
                            Status = "i" });

        modelBuilder.Entity<ProjectGroup>().HasData(
            new ProjectGroup { ProjectGroupId = 47,
                            MetroAreaId = 1008,
                            FullName = "Oldfield",
                            Status = "a" });
        #endregion

        #region Product
        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = "Y58",
                            ProductName = "The Prescot",
                            ProjectGroupId =  23,
                            ProjectName = "Edgewater" });

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = "980",
                            ProductName = "The Davis",
                            ProjectGroupId =  23,
                            ProjectName = "Edgewater 50" });

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = "E15",
                            ProductName = "The Amelia",
                            ProjectGroupId =  23,
                            ProjectName = "Edgewater 50" });

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = "Y54",
                            ProductName = "The Lockwood",
                            ProjectGroupId =  23,
                            ProjectName = "Edgewater 50" });

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = "U68",
                            ProductName = "The Stono",
                            ProjectGroupId =  41,
                            ProjectName = "Estuary" });

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = "1601",
                            ProductName = "The Moultrie",
                            ProjectGroupId =  41,
                            ProjectName = "Estuary" });

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = "980",
                            ProductName = "The Dupree",
                            ProjectGroupId =  25,
                            ProjectName = "Inwood SFD" });

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = "E15",
                            ProductName = "Inwood",
                            ProjectGroupId =  25,
                            ProjectName = "Inwood SFD" });

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = "1674",
                            ProductName = "The Stella",
                            ProjectGroupId =  43,
                            ProjectName = "Mixson" });

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = "1665",
                            ProductName = "The Tidalview",
                            ProjectGroupId =  47,
                            ProjectName = "Oldfield" });

        // modelBuilder.Entity<Product>().HasData(
        //     new Product { ProductId = null,
        //                     ProductName = null,
        //                     ProjectGroupId =  47,
        //                     ProjectName = "Oldfield" });

        #endregion
    }
}

[PrimaryKey(nameof(MetroAreaId))]
public class MetroArea
{
    public int MetroAreaId { get; set; }
    public string? MetroAreaTitle { get; set; }
    public string? MetroAreaStateAbr { get; set; }
    public string? MetroAreaStateName { get; set; }
}

[PrimaryKey(nameof(ProjectGroupId))]
public class ProjectGroup
{
    public int ProjectGroupId { get; set; }

    [ForeignKey(nameof(MetroAreaId))]
    public int MetroAreaId { get; set; }
    public string? FullName { get; set; }
    public string? Status { get; set; }
}

[PrimaryKey(nameof(ProductId), nameof(ProjectGroupId))]
public class Product
{
    public string? ProductId { get; set; }
    public string? ProductName { get; set; }
    public int ProjectGroupId { get; set; }
    public string? ProjectName { get; set; }

}