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
    public class MasterOfferController : Controller
    {
        public IRepository<MasterOffer> MasterOffer { get; }
        public IHostingEnvironment Hosting { get; }

        // GET: MasterOfferController
        public MasterOfferController(IRepository<MasterOffer> _MasterOffer, IHostingEnvironment hosting)
        {
            MasterOffer = _MasterOffer;
            Hosting = hosting;
        }
        public ActionResult Index()
        {
            var data = MasterOffer.View();
            return View(data);
        }

        public ActionResult Update_Active(int id)
        {
            MasterOffer.Active(id);
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
            return View();
        }

        // POST: MasterContactUsInformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterOfferModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.OfferFile!);

                if (ModelState.IsValid)
                {
                    var data = new MasterOffer
                    {
                        MasterOfferId = collection.MasterOfferId,
                        MasterOfferTitle = collection.MasterOfferTitle,
                        MasterOfferBreef = collection.MasterOfferBreef,
                        MasterOfferDesc = collection.MasterOfferDesc,
                        MasterOfferImageUrl = ImageName,
                        CreateId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value,
                        EditId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value,
                    };

                    MasterOffer.Add(data);
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
            var data = MasterOffer.Find(id);
            var obj = new MasterOfferModel
            {
                MasterOfferId = data.MasterOfferId,
                MasterOfferTitle = data.MasterOfferTitle,
                MasterOfferBreef = data.MasterOfferBreef,
                MasterOfferDesc = data.MasterOfferDesc,
                MasterOfferImageUrl = data.MasterOfferImageUrl,
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
        public ActionResult Edit(int id, MasterOfferModel collection)
        {
            try
            {

                string ImageName = SaveImage(collection.OfferFile!);


                if (ModelState.IsValid)
                {
                    var data = new MasterOffer
                    {
                        CreateId = collection.CreateId,
                        EditId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value,

                        MasterOfferId = collection.MasterOfferId,
                        MasterOfferTitle = collection.MasterOfferTitle,
                        MasterOfferBreef = collection.MasterOfferBreef,
                        MasterOfferDesc = collection.MasterOfferDesc,
                        MasterOfferImageUrl = (ImageName == "" ? collection.MasterOfferImageUrl : ImageName),
                        IsActive = collection.IsActive,
                        IsDelete = collection.IsDelete,

                        CreateDate = collection.CreateDate,

                    };
                    MasterOffer.Update(id, data);
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
        public ActionResult Delete(int id, MasterOffer collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            MasterOffer.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }

        public string SaveImage(IFormFile OfferFile)
        {
            string ImageName = "";
            if (OfferFile != null)
            {
                string PathImage = Path.Combine(Hosting.WebRootPath, "Admin/Images/Offer");
                FileInfo F = new FileInfo(OfferFile.FileName);
                ImageName = Guid.NewGuid().ToString() + F.Extension;
                string FullPath = Path.Combine(PathImage, ImageName);
                OfferFile.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageName;
        }
    }
}
