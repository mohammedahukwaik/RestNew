using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestNew.Models.Repositories;
using RestNew.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace RestNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionBookTableController : Controller
    {
        public IRepository<TransactionBookTable> TransactionBookTable { get; }

        // GET: TransactionBookTableController
        public TransactionBookTableController(IRepository<TransactionBookTable> _TransactionBookTable)
        {
            TransactionBookTable = _TransactionBookTable;
        }
        public ActionResult Index()
        {
            var data = TransactionBookTable.View();
            return View(data);
        }
    }
}
