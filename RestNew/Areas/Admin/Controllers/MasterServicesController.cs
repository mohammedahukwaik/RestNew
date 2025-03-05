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
    public class MasterServicesController : Controller
    {
        public IRepository<MasterServices> MasterServices { get; }

        // GET: MasterServicesController
        public MasterServicesController(IRepository<MasterServices> _MasterServices)
        {
            MasterServices = _MasterServices;
        }
        public ActionResult Index()
        {
            var data = MasterServices.View();
            return View(data);
        }

        public ActionResult Update_Active(int id)
        {
            MasterServices.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterServicesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterServicesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterServices collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    collection.CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    MasterServices.Add(collection);
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

        // GET: MasterServicesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterServices.Find(id);
            return View(data);
        }

        // POST: MasterServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterServices collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    MasterServices.Update(id, collection);
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

        // GET: MasterServicesController/Delete/5
        public ActionResult Delete(int id, MasterServices collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            MasterServices.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
    }
}
