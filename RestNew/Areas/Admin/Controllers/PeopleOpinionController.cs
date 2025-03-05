using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestNew.Models.Repositories;
using RestNew.Models;

namespace RestNew.Areas.Admin.Controllers
{
    public class PeopleOpinionController : Controller
    {
        public IRepository<PeopleOpinion> PeopleOpinion { get; }

        // GET: PeopleOpinionController
        public PeopleOpinionController(IRepository<PeopleOpinion> _PeopleOpinion)
        {
            PeopleOpinion = _PeopleOpinion;
        }
        public ActionResult Index()
        {
            var data = PeopleOpinion.View();
            return View(data);
        }

        public ActionResult Update_Active(int id)
        {
            PeopleOpinion.Active(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
