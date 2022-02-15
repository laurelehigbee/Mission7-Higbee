using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7_Higbee.Models
{
    public class EFBookstoreRepository : IBookstoreRepository //repository for book info
    {
        private BookstoreContext context { get; set; } //context var
        public EFBookstoreRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book>Books => context.Books; //connects to book context
    }
}
