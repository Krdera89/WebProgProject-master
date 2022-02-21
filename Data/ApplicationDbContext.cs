using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebProgProject.Models;

namespace WebProgProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Person>()
            //    .HasData(
            //    new Models.Person { id = 100, firstName = "Jack", lastName = "Clark" });


              
            modelBuilder.Entity<PicturePerson>()
                .HasOne(perpic => perpic.person)
                .WithMany(per => per.PicturePersons)
                .HasForeignKey(perpic => perpic.PersonID);
            modelBuilder.Entity<PicturePerson>()
                .HasOne(perpic => perpic.picture)
                .WithMany(pic => pic.PicturePersons)
                .HasForeignKey(perpic => perpic.pictureID);

            modelBuilder.Entity<PlotCemetary>()
                .HasOne(perpic => perpic.plot)
                .WithMany(per => per.PlotCemetaries)
                .HasForeignKey(perpic => perpic.plotID);
            modelBuilder.Entity<PlotCemetary>()
                .HasOne(perpic => perpic.cemetary)
                .WithMany(pic => pic.PlotCemetaries)
                .HasForeignKey(perpic => perpic.CemetaryID);


        }
        public DbSet<WebProgProject.Models.Person> Person { get; set; }
        public DbSet<WebProgProject.Models.Cemetary> Cemetary { get; set; }
        public DbSet<WebProgProject.Models.Picture> Picture { get; set; }
        public DbSet<WebProgProject.Models.PictureCemetary> PictureCemetary { get; set; }
        public DbSet<WebProgProject.Models.PicturePerson> PicturePerson { get; set; }
        public DbSet<WebProgProject.Models.PicturePlot> PicturePlot { get; set; }
        public DbSet<WebProgProject.Models.Plot> Plot { get; set; }
        public DbSet<WebProgProject.Models.PersonPlot> PersonPlot { get; set; }
        public DbSet<WebProgProject.Models.PlotCemetary> PlotCemetary { get; set; }
    }
}
