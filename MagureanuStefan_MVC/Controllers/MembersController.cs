using MagureanuStefan_MVC.Models;
using MagureanuStefan_MVC.Repositories;
using MagureanuStefan_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace MagureanuStefan_MVC.Controllers
{
    [Authorize(Roles = "ADMIN,USER")]
    public class MembersController : Controller
    {
        private readonly MembersRepository _membersRepository;
        private readonly IToastNotification _toastNotification;
        public MembersController(MembersRepository membersRepository, IToastNotification toastNotification)
        {
            _membersRepository = membersRepository;
            _toastNotification = toastNotification;
        }

        // GET: MembersController
        public ActionResult Index()
        {
            var members = _membersRepository.GetAllMembers();
            return View(members);
        }

        // GET: MembersController/Details/5
        public ActionResult Details(Guid id)
        {
            var member = _membersRepository.GetMemberById(id);
            return View(member);
        }

        // GET: MembersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            MembersModel model = new MembersModel();
            try
            {
                TryUpdateModelAsync(model);
                _membersRepository.AddMember(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembersController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var member = _membersRepository.GetMemberById(id);
            return View(member);
        }

        // POST: MembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            MembersModel model = new MembersModel();
            try
            {
                TryUpdateModelAsync(model);
                _membersRepository.UpdateMember(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembersController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var member = _membersRepository.GetMemberById(id);
            return View(member);
        }

        // POST: MembersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                if (_membersRepository.HasCodeSnippets(id))
                {
                    _toastNotification.AddErrorToastMessage("Membrul nu poate fi sters pentru ca are cod adaugat!");
                }
                else
                {
                    _membersRepository.DeleteMember(id);
                    _toastNotification.AddErrorToastMessage("Membrul a fost sters cu succes!");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult DetailsWithCodeSnippets(Guid idMember)
        {
            MemberCodeSnippetsViewModel viewModel = _membersRepository.GetMemberCodeSnippets(idMember);
            return View(viewModel);
        }
    }
}
