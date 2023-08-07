using MagureanuStefan_MVC.Models;
using MagureanuStefan_MVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagureanuStefan_MVC.Controllers
{
    public class CodeSnippetsController : Controller
    {
        private readonly CodeSnippetsRepository _codeSnippetsRepository;
        private readonly MembersRepository _membersRepository;
        public CodeSnippetsController(CodeSnippetsRepository codeSnippetsRepository, MembersRepository membersRepository)
        {
            _codeSnippetsRepository = codeSnippetsRepository;
            _membersRepository = membersRepository;
        }
        // GET: CodeSnippetsController
        public ActionResult Index()
        {
            var codeSnippets = _codeSnippetsRepository.GetAllCodeSnippets();
            return View(codeSnippets);
        }

        // GET: CodeSnippetsController/Details/5
        public ActionResult Details(Guid id)
        {
            var codeSnippet = _codeSnippetsRepository.GetCodeSnippetById(id);
            return View(codeSnippet);
        }

        // GET: CodeSnippetsController/Create
        public ActionResult Create()
        {
            var members = _membersRepository.GetAllMembers();
            ViewBag.Members = members;
            return View();
        }

        // POST: CodeSnippetsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            CodeSnippetsModel model = new CodeSnippetsModel();
            try
            {
                TryUpdateModelAsync(model);
                _codeSnippetsRepository.AddCodeSnippet(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CodeSnippetsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var codeSnippet = _codeSnippetsRepository.GetCodeSnippetById(id);
            return View(codeSnippet);
        }

        // POST: CodeSnippetsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            CodeSnippetsModel model = new CodeSnippetsModel();
            try
            {
                TryUpdateModelAsync(model);
                _codeSnippetsRepository.UpdateCodeSnippet(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CodeSnippetsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var codeSnippet = _codeSnippetsRepository.GetCodeSnippetById(id);
            return View(codeSnippet);
        }

        // POST: CodeSnippetsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _codeSnippetsRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
