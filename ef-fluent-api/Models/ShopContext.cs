using ef_model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ef.Models
{
    public class ShopContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        private const string connectionString = @"
            Data Source=localhost,1433;
            Initial Catalog=shopdata;
            User ID=SA;
            Password=Password123;
            Integrated Security=false;
            TrustServerCertificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
            // optionsBuilder.UseLazyLoadingProxies();

            Console.WriteLine("OnConfiguring");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Console.WriteLine("OnModelCreating");

            // var entity = modelBuilder.Entity(typeof(Product));
            //entity => Fluent api => Product

            // var entity = modelBuilder.Entity<Product>();

            modelBuilder.Entity<Product>(entity =>
            {
                // entity => Fluent api

                // Table mapping - create table
                entity.ToTable("Products"); //create product table same [Table("Products")]
                // PK
                entity.HasKey(p => p.ProductId); // set Pk = [Key]

                // Index, push performance (only use fluent api)
                entity.HasIndex(p => p.Price).HasDatabaseName("index-sanpham-price"); //Indexing and name the index

                // Relative
                entity.HasOne(p => p.Category) //Create relation one
                      .WithMany()
                      .HasForeignKey("CateId") // Name FK
                      .OnDelete(DeleteBehavior.Cascade) // Action when delete FK
                      .HasConstraintName("SomeName")
                      ; 

                entity.Property(p => p.Name)
                      .HasColumnName("title")
                      .HasColumnType("nvarchar")
                      .HasMaxLength(60)
                      .IsRequired(false)
                      .HasDefaultValue("Ten san pha mac dinh");

            });
        }
    }
}