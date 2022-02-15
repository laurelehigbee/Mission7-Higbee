using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7_Higbee.Models.ViewModels
{
    public class PageInfo //what info is needed to perform pagination
    {
        public int TotalNumBooks { get; set; } //intializes variables
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalNumBooks /BooksPerPage); 
        //math to determine total pages
    }
}
