using LinqLab.Models;
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
    }
}
