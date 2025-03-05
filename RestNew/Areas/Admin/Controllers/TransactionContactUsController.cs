using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestNew.Models.Repositories;
using RestNew.Models;
using Microsoft.AspNetCore.Authorization;

namespace RestNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionContactUsController : Controller
    {
        public IRepository<TransactionContactUs> TransactionContactUs { get; }

        // GET: TransactionContactUsController
        public TransactionContactUsController(IRepository<TransactionContactUs> _TransactionContactUs)
        {
            TransactionContactUs = _TransactionContactUs;
        }
        public ActionResult Index()
        {
            var data = TransactionContactUs.View();
            return View(data);
        }
    }
}
