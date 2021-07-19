using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Reporting;
using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using Microsoft.AspNetCore.Mvc;
using temp;
using Transfermarkt.Web.Data;

namespace Transfermarkt.Web.Controllers
{
    public class ReportController : Controller
    {
        private AppDbContext _context;

        public ReportController(AppDbContext db)
        {
            _context = db;
        }
        public List<IgraciVM> GetPlayers (AppDbContext db)
        {
            List<IgraciVM> data = _context.Players.Select(a => new IgraciVM
            {
                FirstName= a.FirstName,
                LastName=a.LastName,
                MiddleName=a.MiddleName,
                height=a.Height
            }).ToList();

            return data;
        }
        public IActionResult Index()
        {

            LocalReport localreport = new LocalReport("Reporti/Report1.rdlc");
            List<IgraciVM> data = GetPlayers(_context);
            localreport.AddDataSource("DataSet1", data);

            ReportResult result = localreport.Execute(RenderType.Pdf);

            return File(result.MainStream, "application/pdf");
        }
    }
}