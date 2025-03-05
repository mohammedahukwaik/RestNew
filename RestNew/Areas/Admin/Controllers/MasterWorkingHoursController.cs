using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestNew.Models.Repositories;
using RestNew.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace RestNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterWorkingHoursController : Controller
    {
        public IRepository<MasterWorkingHours> MasterWorkingHours { get; }

        // GET: MasterWorkingHoursController
        public MasterWorkingHoursController(IRepository<MasterWorkingHours> _MasterWorkingHours)
        {
            MasterWorkingHours = _MasterWorkingHours;
        }
        public ActionResult Index()
        {
            var data = MasterWorkingHours.View();
            return View(data);
        }

        public ActionResult Update_Active(int id)
        {
            MasterWorkingHours.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterWorkingHoursController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterWorkingHoursController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterWorkingHoursController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterWorkingHours collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collection.CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    MasterWorkingHours.Add(collection);
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

        // GET: MasterWorkingHoursController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterWorkingHours.Find(id);
            return View(data);
        }

        // POST: MasterWorkingHoursController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterWorkingHours collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    MasterWorkingHours.Update(id, collection);
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

        // GET: MasterWorkingHoursController/Delete/5
        public ActionResult Delete(int id, MasterWorkingHours collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            MasterWorkingHours.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }

    }
}
