using Bootcamp_Project.EF_Core.FeedbackDetails;
using Bootcamp_Project.EF_Core.PaymentMethodDetails;
using Bootcamp_Project.EF_Core.ProductDetails;
using Bootcamp_Project.EF_Core.ShoppingDetails;
using Bootcamp_Project.EF_Core.UserDetails;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Feedback> Feedbacks { get; set; }


    }
}
