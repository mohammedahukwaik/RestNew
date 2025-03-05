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
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> SystemSetting { get; }

        // GET: SystemSettingController
        public SystemSettingController(IRepository<SystemSetting> _SystemSetting)
        {
            SystemSetting = _SystemSetting;
        }
        public ActionResult Index()
        {
            var data = SystemSetting.View();
            return View(data);
        }

        public ActionResult Update_Active(int id)
        {
            SystemSetting.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: SystemSettingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SystemSettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemSetting collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    collection.CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    SystemSetting.Add(collection);
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

        // GET: SystemSettingController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = SystemSetting.Find(id);
            return View(data);
        }

        // POST: SystemSettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemSetting collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    SystemSetting.Update(id, collection);
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

        // GET: SystemSettingController/Delete/5
        public ActionResult Delete(int id, SystemSetting collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            SystemSetting.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
    }
}
