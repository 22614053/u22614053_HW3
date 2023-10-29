using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u22614053_HW3.Models;

namespace u22614053_HW3.Controllers
{
    public class ArchiveController : Controller
    {

        // GET: Archive
        // This method returns a list of saved reports from your data source.
        private List<ArchiveItem> GetSavedReports()
        {
            // Implement the logic to retrieve a list of saved reports from your data source.
            // This could be a database, a specific folder, or any storage where you store the reports.

            // Replace the following code with your actual data retrieval logic.
            var reports = new List<ArchiveItem>
        {
            new ArchiveItem { ReportName = "Report1.pdf", FilePath = "path/to/Report1.pdf" },
            new ArchiveItem { ReportName = "Report2.pdf", FilePath = "path/to/Report2.pdf" },
        };

            return reports;
        }

        // GET: /Archive/
        public ActionResult Index()
        {
            // Retrieve a list of saved reports (ArchiveItems) from your data source.
            List<ArchiveItem> archiveItems = GetSavedReports();
            return View(archiveItems);
        }

        // GET: /Archive/DownloadReport
        public ActionResult DownloadReport(string filePath, string reportName)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                // Combine the base directory with the file path to get the full file path.
                string fullFilePath = Path.Combine(Server.MapPath("~/Reports"), filePath);

                if (System.IO.File.Exists(fullFilePath))
                {
                    // Implement logic to download the report file.
                    // You can use the FileResult to return the file to the user for download.
                    return File(fullFilePath, "application/octet-stream", reportName);
                }
            }

            // Handle the case where the file is not found.
            return HttpNotFound();
        }

        // GET: /Archive/DeleteReport
        public ActionResult DeleteReport(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                // Combine the base directory with the file path to get the full file path.
                string fullFilePath = Path.Combine(Server.MapPath("~/Reports"), filePath);

                if (System.IO.File.Exists(fullFilePath))
                {
                    // Implement logic to delete the report file.
                    System.IO.File.Delete(fullFilePath);

                    // After deletion, you might want to refresh the list of saved reports.
                    return RedirectToAction("Index");
                }
            }

            // Handle the case where the file is not found.
            return HttpNotFound();
        }
    }
}