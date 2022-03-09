using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7_Higbee.Models
{
    public interface IPurchaseRepository
    {
        IQueryable<Purchase>Purchases { get; }
        IQueryable<Book> Books { get; }
        void SavePurchase(Purchase purchase);
        public void SaveBook(Book b);
        public void CreateBook(Book b);
        public void DeleteBook(Book b);
    }
}
