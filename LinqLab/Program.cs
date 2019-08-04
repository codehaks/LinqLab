using LinqLab.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoreLinq;
using System;
using System.Linq;

namespace LinqLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var services = new ServiceCollection();

            services.AddDbContext<ChinbookContext>();

            var provider = services.BuildServiceProvider();

            var db = provider.GetService<ChinbookContext>();

            var model = db.Albums;

            foreach (var item in model)
            {
                Console.WriteLine(item.Title);
            }



        }

        
    }
}
