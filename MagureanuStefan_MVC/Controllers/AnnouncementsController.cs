using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MagureanuStefan_MVC.Repositories;
using MagureanuStefan_MVC.Models;
using NToastNotify;
using Microsoft.AspNetCore.Authorization;

namespace MagureanuStefan_MVC.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly AnnouncementsRepository _repository;
        private readonly IToastNotification _toastNotification;
        public AnnouncementsController(AnnouncementsRepository repository, IToastNotification toastNotification)
        {
            _repository = repository;
            _toastNotification = toastNotification;

        }
        // GET: AnnouncementsController
        public ActionResult Index()
        {
            var announcements = _repository.GetAllAnnouncements();
            _toastNotification.AddInfoToastMessage("Se incarca toate anunturile!!");
            return View(announcements);
        }

        // GET: AnnouncementsController/Details/5
        public ActionResult Details(Guid id)
        {
            var announcement = _repository.GetAnnouncementById(id);
            _toastNotification.AddInfoToastMessage("Anuntul se incarca!!");
            return View(announcement);
        }

        // GET: AnnouncementsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnnouncementsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            AnnouncementsModel model = new AnnouncementsModel();
            try
            {
                TryUpdateModelAsync(model);
                _repository.AddAnnouncement(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnnouncementsController/Edit/5
        [Authorize(Roles = "ADMIN")]
        public ActionResult Edit(Guid id)
        {
            var announcement = _repository.GetAnnouncementById(id);
            return View(announcement);
        }

        // POST: AnnouncementsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            AnnouncementsModel model = new AnnouncementsModel();
            try
            {
                TryUpdateModelAsync(model);
                _repository.UpdateAnnouncement(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnnouncementsController/Delete/5
        [Authorize(Roles = "ADMIN")]
        public ActionResult Delete(Guid id)
        {
            var announcement = _repository.GetAnnouncementById(id);
            return View(announcement);
        }

        // POST: AnnouncementsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
