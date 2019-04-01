using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loja.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_produtoAppService.GetAll());
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_produtoAppService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
                return ResponseError();

            _produtoAppService.Register(produtoViewModel);

            return Response(produtoViewModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody]ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
                return ResponseError();

            _produtoAppService.Update(produtoViewModel);

            return Response(produtoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _produtoAppService.Remove(id);

            return Response();
        }
    }
}