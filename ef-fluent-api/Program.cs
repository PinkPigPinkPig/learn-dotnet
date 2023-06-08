using ef.Models;
using ef_model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ef;
class Program
{
    static void CreateDataBase()
    {
        using (var dbContext = new ShopContext())
        {
            string dbName = dbContext.Database.GetDbConnection().Database;

            var kq = dbContext.Database.EnsureCreated();

            if (kq)
            {
                Console.WriteLine($"Tao db {dbName} thanh cong");
            }
            else
            {
                Console.WriteLine($"Khong tao duoc {dbName}");
            }
        }
    }
    static void DropDataBase()
    {
        using (var dbContext = new ShopContext())
        {
            string dbName = dbContext.Database.GetDbConnection().Database;

            var kq = dbContext.Database.EnsureDeleted();

            if (kq)
            {
                Console.WriteLine($"Xoa db {dbName} thanh cong");
            }
            else
            {
                Console.WriteLine($"Khong xoa duoc {dbName}");
            }
        }
    }

    static void InsertData()
    {
        using var dbContext = new ShopContext();

        // Category c1 = new Category() { Name = "Dien thoai", Description = "Cac loai dien thoai" };
        // Category c2 = new Category() { Name = "Do uong", Description = "Cac loai do uong" };
        // dbContext.categories.Add(c1);
        // dbContext.categories.Add(c2);

        var c1 = (from c in dbContext.categories where c.CategoryId == 1 select c).FirstOrDefault();
        var c2 = (from c in dbContext.categories where c.CategoryId == 2 select c).FirstOrDefault();

        dbContext.Add(new Product() { Name = "IP8", Price = 1000, CateId = c1.CategoryId });
        dbContext.Add(new Product() { Name = "IP9", Price = 1100, Category = c1 });
        dbContext.Add(new Product() { Name = "Coca", Price = 1100, CateId = c2.CategoryId });
        dbContext.Add(new Product() { Name = "Pepsi", Price = 1100, Category = c2 });

        dbContext.SaveChanges();
    }
    static void QueryProduct()
    {
        using var dbContext = new ShopContext();

        var product = (from p in dbContext.products where p.ProductId == 3 select p).FirstOrDefault();

        var e = dbContext.Entry(product); //entry return refrence

        e.Reference(p => p.Category).Load();

        if(product.Category != null)
        {
            Console.WriteLine($"{product.Category.Name} - {product.Category.Description}");
        }
        else Console.WriteLine("Category = null");
        if(product.Category.Products != null)
        {
            Console.WriteLine($"{product.Category.Name} - {product.Category.Description}");
            product.Category.Products.ForEach(p => p.PrintInfo());
        }
        else Console.WriteLine("Category = null");
    }

    static void Main(string[] args)
    {
        DropDataBase();
        CreateDataBase();
        // InsertData();
        // QueryProduct();
    }
}
