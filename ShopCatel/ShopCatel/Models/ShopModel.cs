namespace ShopCatel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopModel : DbContext
    {
        public ShopModel()
            : base("name=ShopModel")
        {
        }

        public virtual DbSet<tBuyer> tBuyers { get; set; }
        public virtual DbSet<tCo_workers> tCo_workers { get; set; }
        public virtual DbSet<tPeople> tPeoples { get; set; }
        public virtual DbSet<tPre_orders> tPre_orders { get; set; }
        public virtual DbSet<tProduct> tProducts { get; set; }
        public virtual DbSet<tSold_prod> tSold_prod { get; set; }
        public virtual DbSet<tSupplier> tSuppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tBuyer>()
                .HasMany(e => e.tSold_prod)
                .WithRequired(e => e.tBuyer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tBuyer>()
                .HasMany(e => e.tPre_orders)
                .WithRequired(e => e.tBuyer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tCo_workers>()
                .HasMany(e => e.tSold_prod)
                .WithRequired(e => e.tCo_workers)
                .WillCascadeOnDelete(false);
        }
    }
}
