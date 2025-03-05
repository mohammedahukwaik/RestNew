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
    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> MasterPartner { get; }

        // GET: MasterPartnerController
        public MasterPartnerController(IRepository<MasterPartner> _MasterPartner)
        {
            MasterPartner = _MasterPartner;
        }
        public ActionResult Index()
        {
            var data = MasterPartner.View();
            return View(data);
        }

        public ActionResult Update_Active(int id)
        {
            MasterPartner.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterPartnerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterPartnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterPartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPartner collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collection.CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    MasterPartner.Add(collection);
                    return RedirectToAction(nameof(Index));
                }
                else 
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterPartner.Find(id);
            return View(data);
        }

        // POST: MasterPartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterPartner collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    MasterPartner.Update(id, collection);
                    return RedirectToAction(nameof(Index));
                }
                else 
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Delete/5
        public ActionResult Delete(int id, MasterPartner collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            MasterPartner.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
    }
}
