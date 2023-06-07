using ef.Models;
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
    
    static void Main(string[] args)
    {
        DropDataBase();
        CreateDataBase();
    }
}
