using SGUStoreService.DAL;
using SGUStoreService.Models;
using SGUStoreService.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SGUStoreService
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new SGUStoreServiceDbInitializer());
            ServiceHost sh = new ServiceHost(typeof(ProductService));
            sh.Open();
            Console.WriteLine("Service is running....");
            Console.WriteLine("Press any key to stop service");
            Console.ReadLine();
            sh.Close();
            Console.WriteLine("Service is stopped!");
            Console.ReadLine();
        }
    }
}
