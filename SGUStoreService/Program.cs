using SGUStoreService.DAL;
using SGUStoreService.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGUStoreService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Service is running....");
            Database.SetInitializer(new SGUStoreServiceDbInitializer());
            using (var db = new SGUStoreServiceContext())
            {
                Category cat = db.Categories.First(e => e.Id == 1);
                Console.WriteLine(cat.Name);
            }
            Console.ReadLine();
        }
    }
}
