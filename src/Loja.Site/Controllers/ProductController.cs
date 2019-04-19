using System;
using Microsoft.AspNetCore.Mvc;
using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using MediatR;
using Loja.Domain.Core.Notifications;

namespace Loja.Site.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService,
            INotificationHandler<Notification> notifications) : base(notifications)
        {
            _productAppService = productAppService;
        }

        public IActionResult Index()
        {
            return View(_productAppService.GetAll());
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productAppService.GetById(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return View(productViewModel);

            _productAppService.Register(productViewModel);

            if (!IsValid())
            {
                NotifyErrors();
                return View(productViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productAppService.GetById(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return View(productViewModel);

            _productAppService.Update(productViewModel);

            if (!IsValid())
            {
                NotifyErrors();
                return View(productViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productAppService.GetById(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _productAppService.Remove(id);

            if (!IsValid())
            {
                NotifyErrors();
                return View();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
