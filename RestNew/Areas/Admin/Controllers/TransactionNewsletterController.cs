using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestNew.Models.Repositories;
using RestNew.Models;
using Microsoft.AspNetCore.Authorization;

namespace RestNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionNewsletterController : Controller
    {
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }

        // GET: TransactionNewsletterController
        public TransactionNewsletterController(IRepository<TransactionNewsletter> _TransactionNewsletter)
        {
            TransactionNewsletter = _TransactionNewsletter;
        }
        public ActionResult Index()
        {
            var data = TransactionNewsletter.View();
            return View(data);
        }
    }
}
