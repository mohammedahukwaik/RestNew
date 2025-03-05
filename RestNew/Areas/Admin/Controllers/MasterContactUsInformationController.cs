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
    public class MasterContactUsInformationController : Controller
    {
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public IHostingEnvironment Hosting { get; }

        // GET: MasterContactUsInformationController
        public MasterContactUsInformationController(IRepository<MasterContactUsInformation> _MasterContactUsInformation, IHostingEnvironment hosting)
        {
            MasterContactUsInformation = _MasterContactUsInformation;
            Hosting = hosting;
        }
        public ActionResult Index()
        {
            var data = MasterContactUsInformation.View();
            return View(data);
        }

        public ActionResult Update_Active(int id)
        {
            MasterContactUsInformation.Active(id);
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
        public ActionResult Create(MasterContactUsInformationModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.ContactUsFile); 
            
                if (ModelState.IsValid)
                {
                    var data = new MasterContactUsInformation
                    {
                        MasterContactUsInformationId = collection.MasterContactUsInformationId,
                        MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                        MasterContactUsInformationImageUrl = ImageName,
                        MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect,
                        CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                        EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    };
                    
                    MasterContactUsInformation.Add(data);
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
            var data = MasterContactUsInformation.Find(id);
            var obj = new MasterContactUsInformationModel 
            {
                MasterContactUsInformationId = data.MasterContactUsInformationId,
                MasterContactUsInformationIdesc = data.MasterContactUsInformationIdesc,
                MasterContactUsInformationImageUrl = data.MasterContactUsInformationImageUrl,
                MasterContactUsInformationRedirect = data.MasterContactUsInformationRedirect,
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
        public ActionResult Edit(int id, MasterContactUsInformationModel collection)
        {
            try
            {

                string ImageName = SaveImage(collection.ContactUsFile);
                

                if (ModelState.IsValid) 
                {
                    var data = new MasterContactUsInformation
                    {
                        CreateId = collection.CreateId,
                        EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                        MasterContactUsInformationId = collection.MasterContactUsInformationId,
                        MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                        MasterContactUsInformationImageUrl = (ImageName == "" ? collection.MasterContactUsInformationImageUrl : ImageName),
                        MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect,
                        IsActive = collection.IsActive,
                        IsDelete = collection.IsDelete,

                        CreateDate = collection.CreateDate,

                    };
                    MasterContactUsInformation.Update(id, data);
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
        public ActionResult Delete(int id, MasterContactUsInformation collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            MasterContactUsInformation.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }

        public string SaveImage(IFormFile ContactUsFile) 
        {
            string ImageName = "";
            if (ContactUsFile != null)
            {
                string PathImage = Path.Combine(Hosting.WebRootPath, "Admin/Images/ContactUs");
                FileInfo F = new FileInfo(ContactUsFile.FileName);
                ImageName = Guid.NewGuid().ToString() + F.Extension;
                string FullPath = Path.Combine(PathImage, ImageName);
                ContactUsFile.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageName;
        }
    }
}
