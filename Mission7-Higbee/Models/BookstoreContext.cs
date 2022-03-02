using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mission7_Higbee.Models
{
    public class BookstoreContext : DbContext //Context for Bookstore website
    {
        public BookstoreContext()
        {
        }

        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } //references the books information in the db
        public DbSet<Purchase>Purchases { get; set; }//references the purchases information in the db

    }
}
