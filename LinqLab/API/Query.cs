using LinqLab.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqLab.API
{
    class Query
    {
        private readonly ChinookContext _db;
        public Query(ChinookContext chinookContext)
        {
            _db = chinookContext;
        }

        public IList<Albums> GetAlbums()
        {
            return _db.Albums.ToList();
        }

        public void MostPopularTracks()
        {
            var q = _db.InvoiceItems.Include(i => i.Track)
               .GroupBy(i => i.TrackId)
               .OrderByDescending(g => g.Count())
               .Take(5)
               .Select(g => new { g.First().Track.Name, Count = g.Count() });

            foreach (var item in q)
            {
                Console.WriteLine($"{item.Name} ({item.Count})");
            }

        }

        public void InvoiceCustomerSupport()
        {
            var q = from Invoice in _db.Invoices
                    join customer in _db.Customers on Invoice.CustomerId equals customer.CustomerId
                    join employee in _db.Employees on customer.SupportRepId equals employee.EmployeeId
                    select new
                    {
                        Invoice.InvoiceId,
                        customer.LastName,
                        employee.FirstName
                    };

            foreach (var item in q)
            {
                Console.WriteLine($"{item.InvoiceId} | {item.LastName} | {item.FirstName}");
            }
        }

        public void BestCustomers()
        {
            var q1 = _db.Invoices
                .Join(_db.Customers,
                i => i.CustomerId,
                c => c.CustomerId,(i,c)=> new { Invoice=i,Customer=c}).Select(j=>new { j.Customer.LastName});

            foreach (var item in q1)
            {
                Console.WriteLine($"{item.LastName}");
            }

           
        }

        public void BestCustomers2()
        {
            var q = _db.Invoices.Include(i => i.Customer)
                .GroupBy(i => i.CustomerId)
                .OrderByDescending(g => g.Count())
                .Take(100)
                .Select(g => new { g.First().Customer.FirstName, g.First().Customer.LastName,Count=g.Count() });
            foreach (var item in q)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} ({item.Count})");
            }
        }
    }
}
