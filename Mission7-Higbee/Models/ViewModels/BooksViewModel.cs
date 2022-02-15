using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7_Higbee.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<Book>Books { get; set; } //accesses all of the books in the db
        public PageInfo PageInfo { get; set; } //accesses the page info
    }
}
