using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using u22614053_HW3.Models;

namespace u22614053_HW3.Controllers
{
    public class HomeController : Controller
    {
        private LibraryEntities db = new LibraryEntities();

        public async Task<ActionResult> Index(int studentPage = 1, int bookPage = 1)
        {
            int pageSize = 6; 

            var students = await Task.Run(() => db.students.ToList());
            var books = await Task.Run(() => db.books.ToList());

            var studentsToDisplay = students.Skip((studentPage - 1) * pageSize).Take(pageSize).ToList();
            var booksToDisplay = books.Skip((bookPage - 1) * pageSize).Take(pageSize).ToList();

            // Retrieve data asynchronously 
            var student = await Task.Run(() => db.students.ToList());
            var book = await Task.Run(() => db.books.ToList());


            //CombinedViewModel to merge data
            var viewModel = new LibraryVM
            {
                Students = studentsToDisplay,
                Books = booksToDisplay,
                StudentPage = studentPage,
                BookPage = bookPage,
                TotalStudentPages = (int)Math.Ceiling((double)students.Count / pageSize),
                TotalBookPages = (int)Math.Ceiling((double)books.Count / pageSize)
            };

            return View(viewModel);
        }


        public async Task<ActionResult> About(int authorPage = 1, int typePage = 1,int borrowPage =1)
        {

            int pageSize = 6; // page size

            var authors = await Task.Run(() => db.authors.ToList());
            var types = await Task.Run(() => db.types.ToList());
            var borrows = await Task.Run(() => db.borrows.ToList());

            var authorToDisplay = authors.Skip((authorPage - 1) * pageSize).Take(pageSize).ToList();
            var typeToDisplay = types.Skip((typePage - 1) * pageSize).Take(pageSize).ToList();
            var borrowsToDisplay = borrows.Skip((typePage - 1) * pageSize).Take(pageSize).ToList();


            // CombinedViewModel to merge data
            var viewModel = new LibraryVM
            {
                Authors = authorToDisplay,
                Types = typeToDisplay,
                Borrows=borrowsToDisplay,
                AuthorPage = authorPage,
                TypePage = typePage,
                BorrowPage = borrowPage,
                TotalauthorPages = (int)Math.Ceiling((double)authors.Count / pageSize),
                TotaltypePages = (int)Math.Ceiling((double)types.Count / pageSize),
                TotalborrowPages = (int)Math.Ceiling((double)borrows.Count / pageSize)
            };

            return View(viewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Report()
        {
            // Declare Chart Data holders
            List<string> labels = new List<string>();
            List<int> data = new List<int>();
            List<string> borderColors = new List<string> { "#cd4a21" };
            List<string> backColors = new List<string> { "#cd4a21", "#21cdb5", "#cd2159", "#cd4a21", "#21cdb5", "#cd2159","#336699","#FF9900","#9933CC","#669900","#CC0033","#FFCC00","#FF3366","#0099CC","#66CC33FF6633","#99CC00","#CC9900","#3399FF","#FF99CC","#CC9966","#99CC66" };

            // Select Data to use in Chart
            List<Report> chartData = db.borrows
                                        .Include(x => x.bookId)
                                        .Include(y => y.studentId)
            .GroupBy(z => z.bookId)
                                        .Select(priority => new Report
                                        {
                                            History = priority.Select(a => a.borrowId).FirstOrDefault().ToString(),
                                            BorrowHistory = priority.Select(b => b.studentId).Count()
                                        })
                                        .ToList();

            // Append to Lists

            foreach (Report chartVm in chartData)
            {
                labels.Add(chartVm.History);
                data.Add(chartVm.BorrowHistory);
            }


            // Serialize Data
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.labels = serializer.Serialize(labels);
            ViewBag.data = serializer.Serialize(data);
            ViewBag.borderColors = serializer.Serialize(borderColors);
            ViewBag.backColors = serializer.Serialize(backColors);
            return View();
        }

    }
}