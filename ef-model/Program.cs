using ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ef;
class Program
{
    static void CreateDataBase()
    {
        using (var dbContext = new ProductDbContext())
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
        using (var dbContext = new ProductDbContext())
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
    static void InsertProduct()
    {
        using var dbContext = new ProductDbContext();

        var products = new object[] {
        new Product() { ProductName = "San pham 3", Provider = "Cong ty 3" },
        new Product() { ProductName = "San pham 4", Provider = "Cong ty 4" },
        new Product() { ProductName = "San pham 5", Provider = "Cong ty 5" },
       };

        dbContext.AddRange(products);
        int number_rows = dbContext.SaveChanges(); //Call if you want update DB, return number of rows changed
        Console.WriteLine($"Da chen {number_rows} du lieu");
    }
    static void ReadProducts()
    {
        using var dbContext = new ProductDbContext();
        // Linq
        // var products = dbContext.products.ToList();
        // products.ForEach(product => product.PrintInfo());

        // var qr = from product in dbContext.products
        //          where product.ProductId >= 3
        //          select product;

        // var qr = from product in dbContext.products
        //          where product.ProductId >= 3
        //          orderby product.ProductId descending
        //          select product;

        // qr.ToList().ForEach(product => product.PrintInfo());

        Product product = (from p in dbContext.products
                           where p.ProductId == 4
                           select p).FirstOrDefault();

        if (product != null)
        {
            product.PrintInfo();
        }
    }

    static void UpdateProduct(int id, string newName)
    {
        using var dbContext = new ProductDbContext();

        Product product = (from p in dbContext.products
                           where p.ProductId == id
                           select p).FirstOrDefault();

        if (product != null)
        {
            EntityEntry<Product> entry = dbContext.Entry(product);
            entry.State = EntityState.Detached;
            product.ProductName = newName;
            int number_rows = dbContext.SaveChanges(); //Call if you want update DB, return number of rows changed
            Console.WriteLine($"Da cap nhat {number_rows} du lieu");
        }
    }

    static void DeleteProduct(int id)
    {
        using var dbContext = new ProductDbContext();

        Product product = (from p in dbContext.products
                           where p.ProductId == id
                           select p).FirstOrDefault();

        if (product != null)
        {
            // EntityEntry<Product> entry = dbContext.Entry(product);
            // entry.State = EntityState.Detached;
            dbContext.Remove(product);
            int number_rows = dbContext.SaveChanges(); //Call if you want update DB, return number of rows changed
            Console.WriteLine($"Da xoa {number_rows} du lieu");
        }
    }
    static void Main(string[] args)
    {
        // Entity -< Database, Table
        // Database: data01 -> dbContext
        // --product

        // var dbContext = new ProductDbContext();
        // DropDataBase();
        // CreateDataBase();
        // InsertProduct();
        ReadProducts();
        // UpdateProduct(1, "Laptop");
    }
}
