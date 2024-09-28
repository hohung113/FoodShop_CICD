using PizzaStore.Models;

namespace PizzaStore.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options){}
        
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; } 
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>()
           .HasKey(od => new { od.OrderID, od.ProductID });

            modelBuilder.Entity<OrderDetails>()
               .HasOne(od => od.Order)
               .WithMany(o => o.OrderDetails)
               .HasForeignKey(od => od.OrderID);
            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductID);

            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Suppliers>().ToTable("Suppliers");
            modelBuilder.Entity<Categories>().ToTable("Categories");
            modelBuilder.Entity<Customers>().ToTable("Customers");
            modelBuilder.Entity<Orders>().ToTable("Orders");
            modelBuilder.Entity<OrderDetails>().ToTable("Order Details");
            modelBuilder.Entity<Products>().ToTable("Products");
        }
    }
}
