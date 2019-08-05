
using LinqLab.API;
using LinqLab.Models;
using Microsoft.EntityFrameworkCore;
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

            services.AddDbContext<ChinookContext>(options =>
            options.UseSqlite("Data Source=chinook.db"));
            services.AddTransient<Query>();

            var provider = services.BuildServiceProvider();

            //var db = provider.GetService<ChinookContext>();

            //var model = db.Albums;

            var query = provider.GetService<Query>();

            var albums = query.GetAlbums();

            foreach (var item in albums)
            {
                Console.WriteLine(item.Title);
            }



        }


    }
}
