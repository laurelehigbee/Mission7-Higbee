using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7_Higbee.Models
{
    public interface IBookstoreRepository //repository for books in db
    {
        IQueryable<Book>Books { get; } //gets book information from db
    }
}
