using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ComplexSample;

public partial class Mw5ProjectContext : DbContext
{
    public Mw5ProjectContext(DbContextOptions<Mw5ProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasOne(d => d.Country)
                .WithMany(p => p.Brands)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasOne(d => d.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(d => d.Ratings)
                .WithOne(p => p.Product)
                .OnDelete(DeleteBehavior.Cascade);
        });


        //modelBuilder.Entity<Rating>();
        modelBuilder.Entity<Rating>(entity =>
        {
            entity.ToTable("Rating");
            entity.HasOne(d => d.Product)
                .WithMany(p => p.Ratings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientCascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
