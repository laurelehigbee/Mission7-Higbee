using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7_Higbee.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext context { get; set; }

        public EFPurchaseRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Purchase> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x=>x.Book);

        public IQueryable<Book> Books => context.Books;

        public void SavePurchase(Purchase purchase)
        {
            context.AttachRange(purchase.Lines.Select(x=>x.Book));
            if (purchase.BookId==0)
            {
                context.Purchases.Add(purchase);
            }
            context.SaveChanges();
        }

        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
