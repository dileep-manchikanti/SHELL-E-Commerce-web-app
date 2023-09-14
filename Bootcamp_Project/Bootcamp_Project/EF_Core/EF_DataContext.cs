using Bootcamp_Project.EF_Core.PaymentMethodDetails;
using Bootcamp_Project.EF_Core.ProductDetails;
using Bootcamp_Project.EF_Core.ShoppingDetails;
using Bootcamp_Project.EF_Core.UserDetails;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using Microsoft.Extensions.Logging;
using Bootcamp_Project.EF_Core.GlobalVariables;

namespace Bootcamp_Project.EF_Core
{
    public class EF_DataContext:DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasKey(t1 => t1.Id);

            modelBuilder.Entity<Address>()
                .HasKey(t2 => t2.Id);

            modelBuilder.Entity<User_Address>()
                .HasKey(t3 => new { t3.userid, t3.addressid });

            modelBuilder.Entity<User_Address>()
                .HasOne(t3 => t3.user)
                .WithMany()
                .HasForeignKey(t3 => t3.userid);

            modelBuilder.Entity<User_Address>()
                .HasOne(t3 => t3.address)
                .WithMany()
                .HasForeignKey(t3 => t3.addressid);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<User_Address> User_Addresses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<GlobalVariable> GlobalVariables { get; set; }

        public override int SaveChanges()
        {
            Console.WriteLine("before created\n");
            DateTime dateTime = DateTime.UtcNow; // Replace with your DateTime value

            // Calculate the milliseconds since Unix epoch (January 1, 1970) in UTC
            long millisecondsSinceEpoch = (long)(dateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

            Console.WriteLine("after created\n");

            // Iterate through DbSet properties and update timestamps
            foreach (var property in GetType().GetProperties())
            {
                if (property.PropertyType.IsGenericType &&
                    property.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                {
                    var entityType = property.PropertyType.GetGenericArguments().First();
                    var entries = ChangeTracker.Entries().Where(entry => entry.Entity.GetType() == entityType);

                    foreach (var entry in entries)
                    {
                        var entity = entry.Entity;

                        switch (entry.State)
                        {
                            case EntityState.Added:
                                entity.GetType().GetProperty("createdDate")?.SetValue(entity, millisecondsSinceEpoch);
                                entity.GetType().GetProperty("updatedDate")?.SetValue(entity, millisecondsSinceEpoch);
                                break;
                            case EntityState.Modified:
                                entity.GetType().GetProperty("createdDate")?.SetValue(entity, entry.OriginalValues["createdDate"]);
                                entity.GetType().GetProperty("updatedDate")?.SetValue(entity, millisecondsSinceEpoch);
                                break;
                        }
                    }
                }
            }
            return base.SaveChanges();
        }

    }
}
