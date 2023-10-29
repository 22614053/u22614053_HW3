using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace u22614053_HW3.Models
{
    public class LibraryVM
    {
        public IEnumerable<student> Students { get; set; }
        public IEnumerable<book> Books { get; set; }
        public IEnumerable<author> Authors { get; set; }
        public IEnumerable<borrow> Borrows { get; set; }
        public IEnumerable<type> Types { get; set; }


        //author and type page count
        public int AuthorPage { get; set; }
        public int TypePage { get; set; }
        public int TotalauthorPages { get; set; }
        public int TotaltypePages { get; set; }
        //student and book count
        public int StudentPage { get; set; }
        public int BookPage { get; set; }
        public int TotalStudentPages { get; set; }
        public int TotalBookPages { get; set; }

        //Borrow page count
        public int BorrowPage { get; set; } 
        public int TotalborrowPages { get; set;}
    }
}