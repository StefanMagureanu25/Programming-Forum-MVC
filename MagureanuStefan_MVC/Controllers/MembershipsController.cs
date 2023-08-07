using MagureanuStefan_MVC.Models;
using MagureanuStefan_MVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagureanuStefan_MVC.Controllers
{
    public class MembershipsController : Controller
    {
        private readonly MembershipsRepository _membershipsRepository;
        public MembershipsController(MembershipsRepository membershipsRepository)
        {
            _membershipsRepository = membershipsRepository;
        }
        // GET: MembershipsController
        public ActionResult Index()
        {
            var memberships = _membershipsRepository.GetAllMemberships();
            return View(memberships);
        }

        // GET: MembershipsController/Details/5
        public ActionResult Details(Guid id)
        {
            var membership = _membershipsRepository.GetMembershipById(id);
            return View(membership);
        }

        // GET: MembershipsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembershipsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            MembershipsModel model = new MembershipsModel();
            try
            {
                TryUpdateModelAsync(model);
                _membershipsRepository.AddMembership(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembershipsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var membership = _membershipsRepository.GetMembershipById(id);
            return View(membership);
        }

        // POST: MembershipsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            MembershipsModel model = new MembershipsModel();
            try
            {
                TryUpdateModelAsync(model);
                _membershipsRepository.UpdateMembership(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembershipsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var membership = _membershipsRepository.GetMembershipById(id);
            return View(membership);
        }

        // POST: MembershipsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _membershipsRepository.DeleteMembership(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
