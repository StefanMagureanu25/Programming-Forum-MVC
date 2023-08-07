using MagureanuStefan_MVC.Models;
using MagureanuStefan_MVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagureanuStefan_MVC.Controllers
{
    public class MembershipTypesController : Controller
    {
        private readonly MembershipTypesRepository _membershipTypesRepository;
        public MembershipTypesController(MembershipTypesRepository membershipTypesRepository)
        {
            _membershipTypesRepository = membershipTypesRepository;
        }

        // GET: MembershipTypesController
        public ActionResult Index()
        {
            var membershipTypes = _membershipTypesRepository.GetAllMembershipTypes();
            return View(membershipTypes);
        }

        // GET: MembershipTypesController/Details/5
        public ActionResult Details(Guid id)
        {
            var membershipType = _membershipTypesRepository.GetMembershipTypeById(id);
            return View(membershipType);
        }

        // GET: MembershipTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembershipTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            MembershipTypesModel model = new MembershipTypesModel();
            try
            {
                TryUpdateModelAsync(model);
                _membershipTypesRepository.AddMembershipType(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembershipTypesController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var membershipType = _membershipTypesRepository.GetMembershipTypeById(id);
            return View(membershipType);
        }

        // POST: MembershipTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            MembershipTypesModel model = new MembershipTypesModel();
            try
            {
                TryUpdateModelAsync(model);
                _membershipTypesRepository.UpdateMembershipType(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembershipTypesController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var membershipType = _membershipTypesRepository.GetMembershipTypeById(id);
            return View(membershipType);
        }

        // POST: MembershipTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _membershipTypesRepository.DeleteMembershipType(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
