using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission7_Higbee.Models
{
    public partial class Book //book class for db, initializes variables down below
    {
        [Key]
        [Required]
        public int BookId { get; set; } //bookid is the primary key 
        [Required]
        public string Title { get; set; } //all fields are required, as shown by required in brackets
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int PageCount { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
