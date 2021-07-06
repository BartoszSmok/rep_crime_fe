using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LawEnforcement = LawEnforcement.API.Models.LawEnforcement;

namespace LawEnforcement.API.Data.Context
{
    public class LawEnforcementContext:DbContext
    {
        public DbSet<Models.LawEnforcement> LawOfficers { get; set; }
        public LawEnforcementContext(DbContextOptions<LawEnforcementContext> options):
            base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Models.LawEnforcement>()
            //    .HasOne(x => x.AssignedCasesIds).WithMany();


            modelBuilder.Entity<Models.LawEnforcement>()
                .ToContainer("Officers");
            modelBuilder.Entity<Models.LawEnforcement>().HasData(new Models.LawEnforcement(){ Id = new Guid("336d24a8-c386-44e4-b28d-e07028398100"), Agency = "Police", Rank = "Captain", BadgeId = "XRP001"});

        }
    }


}
