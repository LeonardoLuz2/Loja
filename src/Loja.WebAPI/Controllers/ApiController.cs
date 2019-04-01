using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Loja.WebAPI.Controllers
{
    public class ApiController : ControllerBase
    {
        protected new IActionResult Response(object result = null)
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        protected IActionResult ResponseError()
        {
            var errors = ModelState.Values.SelectMany(p => p.Errors);

            return BadRequest(new
            {
                success = false,
                errors = errors.Select(p => p.ErrorMessage)
            });
        }
    }
}
