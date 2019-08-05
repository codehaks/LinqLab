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
    }
}
