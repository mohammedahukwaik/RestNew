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
    public class MasterSocialMediaController : Controller
    {
        public IRepository<MasterSocialMedia> MasterSocialMedia { get; }

        // GET: MasterSocialMediaController
        public MasterSocialMediaController(IRepository<MasterSocialMedia> _MasterSocialMedia)
        {
            MasterSocialMedia = _MasterSocialMedia;
        }
        public ActionResult Index()
        {
            var data = MasterSocialMedia.View();
            return View(data);
        }

        public ActionResult Update_Active(int id) 
        {
            MasterSocialMedia.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterSocialMediaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterSocialMediaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSocialMediaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSocialMedia collection)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    collection.CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    MasterSocialMedia.Add(collection);
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

        // GET: MasterSocialMediaController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSocialMedia.Find(id);
            return View(data);
        }

        // POST: MasterSocialMediaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSocialMedia collection)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    MasterSocialMedia.Update(id, collection);
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

        // GET: MasterSocialMediaController/Delete/5
        public ActionResult Delete(int id, MasterSocialMedia collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            MasterSocialMedia.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
    }
}
