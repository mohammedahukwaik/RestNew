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
    public class MasterCategoryMenuController : Controller
    {
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }

        // GET: MasterCategoryMenuController
        public MasterCategoryMenuController(IRepository<MasterCategoryMenu> _MasterCategoryMenu)
        {
            MasterCategoryMenu = _MasterCategoryMenu;
        }
        public ActionResult Index()
        {
            var data = MasterCategoryMenu.View();
            return View(data);
        }
        public ActionResult Update_Active(int id)
        {
            MasterCategoryMenu.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterCategoryMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterCategoryMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterCategoryMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterCategoryMenu collection)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    collection.CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    MasterCategoryMenu.Add(collection);
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

        // GET: MasterCategoryMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterCategoryMenu.Find(id);
            return View(data);
        }

        // POST: MasterCategoryMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterCategoryMenu collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    MasterCategoryMenu.Update(id, collection);
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

        // GET: MasterCategoryMenuController/Delete/5
        public ActionResult Delete(int id, MasterCategoryMenu collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            MasterCategoryMenu.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
    }
}
