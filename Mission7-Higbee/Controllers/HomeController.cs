using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission7_Higbee.Models;
using Mission7_Higbee.Models.ViewModels;

namespace Mission7_Higbee.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo; //variable for the repository
        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string bookCategory, int pageNum = 1) //what to do when returning the index
        {
            int pageSize = 10; //sets number of results on page to 10

            var x = new BooksViewModel //creates new view model fo rthe books on the page
            {
                Books = repo.Books //where to get the books from
                .Where(p => p.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize) //how to determine which books go on what page
                .Take(pageSize),

                PageInfo = new PageInfo //creates new page info for a specific page
                {
                    TotalNumBooks = (bookCategory == null
                        ? repo.Books.Count()
                        : repo.Books.Where(b => b.Category == bookCategory).Count()),
                    BooksPerPage = pageSize, //how many books/page assignment
                    CurrentPage = pageNum //what page it's on assignment
                }
            };
            return View(x); //returns the view
        }
    }
}
