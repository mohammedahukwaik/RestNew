using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestNew.Models.Repositories;
using RestNew.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using RestNew.ViewModels;
using NuGet.Protocol;

namespace RestNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }
        public IHostingEnvironment Hosting { get; }

        // GET: MasterItemMenuController
        public MasterItemMenuController(IRepository<MasterItemMenu> _MasterItemMenu, IRepository<MasterCategoryMenu> _MasterCategoryMenu, IHostingEnvironment hosting)
        {
            MasterItemMenu = _MasterItemMenu;
            MasterCategoryMenu = _MasterCategoryMenu;
            Hosting = hosting;
        }
        public ActionResult Index()
        {
            var data = MasterItemMenu.View();
            return View(data);
        }

        public ActionResult Update_Active(int id)
        {
            MasterItemMenu.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterContactUsInformationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterContactUsInformationController/Create
        public ActionResult Create()
        {
            var MasterItemMenuModel = new MasterItemMenuModel
            {
                ListMasterCategoryMenu = MasterCategoryMenu.View(),
            };
            return View(MasterItemMenuModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterItemMenuModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.ItemMenuFile);

                if (ModelState.IsValid)
                {
                    var data = new MasterItemMenu
                    {
                        MasterItemMenuId = collection.MasterItemMenuId,
                        MasterCategoryMenuId = collection.MasterCategoryMenuId,
                        MasterItemMenuTitle = collection.MasterItemMenuTitle,
                        MasterItemMenuBreef = collection.MasterItemMenuBreef,
                        MasterItemMenuDesc = collection.MasterItemMenuDesc,
                        MasterItemMenuPrice = collection.MasterItemMenuPrice,
                        MasterItemMenuImageUrl = ImageName,
                        MasterItemMenuDate = collection.MasterItemMenuDate,
                        CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                        EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    };

                    MasterItemMenu.Add(data);
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

        // GET: MasterContactUsInformationController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterItemMenu.Find(id);
            var obj = new MasterItemMenuModel
            {
                MasterItemMenuId = data.MasterItemMenuId,
                MasterCategoryMenuId = data.MasterCategoryMenuId,
                MasterItemMenuTitle = data.MasterItemMenuTitle,
                MasterItemMenuBreef = data.MasterItemMenuBreef,
                MasterItemMenuDesc = data.MasterItemMenuDesc,
                MasterItemMenuPrice = data.MasterItemMenuPrice,
                MasterItemMenuImageUrl = data.MasterItemMenuImageUrl,
                MasterItemMenuDate = data.MasterItemMenuDate,
                ListMasterCategoryMenu = MasterCategoryMenu.View(),
                EditId = data.EditId,
                EditDate = data.EditDate,
                CreateId = data.CreateId,
                CreateDate = data.CreateDate,
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,

            };
            return View(obj);
        }

        // POST: MasterContactUsInformationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterItemMenuModel collection)
        {
            try
            {

                string ImageName = SaveImage(collection.ItemMenuFile);


                if (ModelState.IsValid)
                {
                    var data = new MasterItemMenu
                    {
                        CreateId = collection.CreateId,
                        EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                        MasterItemMenuId = collection.MasterItemMenuId,
                        MasterCategoryMenuId = collection.MasterCategoryMenuId,
                        MasterItemMenuTitle = collection.MasterItemMenuTitle,
                        MasterItemMenuBreef = collection.MasterItemMenuBreef,
                        MasterItemMenuDesc = collection.MasterItemMenuDesc,
                        MasterItemMenuPrice = collection.MasterItemMenuPrice,
                        MasterItemMenuImageUrl = (ImageName == "" ? collection.MasterItemMenuImageUrl : ImageName),
                        MasterItemMenuDate = collection.MasterItemMenuDate,
                        IsActive = collection.IsActive,
                        IsDelete = collection.IsDelete,
                        CreateDate = collection.CreateDate,

                    };
                    MasterItemMenu.Update(id, data);
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

        // GET: MasterContactUsInformationController/Delete/5
        public ActionResult Delete(int id, MasterItemMenu collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            MasterItemMenu.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }

        public string SaveImage(IFormFile ItemMenuFile)
        {
            string ImageName = "";
            if (ItemMenuFile != null)
            {
                string PathImage = Path.Combine(Hosting.WebRootPath, "Admin/Images/ItemMenu");
                FileInfo F = new FileInfo(ItemMenuFile.FileName);
                ImageName = Guid.NewGuid().ToString() + F.Extension;
                string FullPath = Path.Combine(PathImage, ImageName);
                ItemMenuFile.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageName;
        }
    }
}
