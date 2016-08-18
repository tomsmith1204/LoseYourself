namespace SeniorProject.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SeniorProject.Models;
    using System.Data.Entity.Core.Objects;
    using System.Security.Principal;

    public partial class LoseContext : DbContext
    {
        public LoseContext()
            : base("name=LoseEntities")
        {
        }

        public virtual DbSet<UserModels> User { get; set; }
        public virtual DbSet<WeighInModels> WeighIn { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
