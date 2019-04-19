using System;
using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Loja.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Loja.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiController
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService,
            INotificationHandler<Notification> notifications) : base(notifications)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_productAppService.GetAll());
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_productAppService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
                return ResponseError();

            _productAppService.Register(productViewModel);

            return Response(productViewModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody]ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
                return ResponseError();

            _productAppService.Update(productViewModel);

            return Response(productViewModel);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _productAppService.Remove(id);

            return Response();
        }
    }
}