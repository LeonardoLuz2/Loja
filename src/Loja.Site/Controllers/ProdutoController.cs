using System;
using Microsoft.AspNetCore.Mvc;
using Loja.Application.Interfaces;
using Loja.Application.ViewModels;

namespace Loja.Site.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        public IActionResult Index()
        {
            return View(_produtoAppService.GetAll());
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = _produtoAppService.GetById(id.Value);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informe dados válidos!");
            }

            _produtoAppService.Register(produtoViewModel);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = _produtoAppService.GetById(id.Value);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informe dados válidos!");
            }

            _produtoAppService.Update(produtoViewModel);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = _produtoAppService.GetById(id.Value);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _produtoAppService.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
