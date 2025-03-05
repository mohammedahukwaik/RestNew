using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestNew.Models.Repositories;
using RestNew.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using RestNew.Areas.Admin.ViewModels;

namespace RestNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterMenuController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }

        // GET: MasterMenuController
        public MasterMenuController(IRepository<MasterMenu> _MasterMenu)
        {
            MasterMenu = _MasterMenu;
        }
        public ActionResult Index()
        {
            var data = MasterMenu.View();
            return View(data);
        }

        public ActionResult Update_Active(int id)
        {
            MasterMenu.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMenu collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collection.CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    MasterMenu.Add(collection);
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

        // GET: MasterMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterMenu.Find(id);

            return View(data);
        }

        // POST: MasterMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterMenu collection)
        {
            try
            {
                collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                MasterMenu.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Delete/5
        public ActionResult Delete(int id, MasterMenu collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            MasterMenu.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }

    }
}
