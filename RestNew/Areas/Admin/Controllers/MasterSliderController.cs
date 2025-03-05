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
    public class MasterSliderController : Controller
    {
        public IRepository<MasterSlider> MasterSlider { get; }

        // GET: MasterSliderController
        public MasterSliderController(IRepository<MasterSlider> _MasterSlider)
        {
            MasterSlider = _MasterSlider;
        }
        public ActionResult Index()
        {
            var data = MasterSlider.View();
            return View(data);
        }
        
        public ActionResult Update_Active(int id) 
        {
            MasterSlider.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterSliderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterSliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSlider collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    collection.CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    MasterSlider.Add(collection);
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

        // GET: MasterSliderController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSlider.Find(id);
            return View(data);
        }

        // POST: MasterSliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSlider collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    MasterSlider.Update(id, collection);
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

        // GET: MasterSliderController/Delete/5
        public ActionResult Delete(int id, MasterSlider collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            MasterSlider.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
    }
}
