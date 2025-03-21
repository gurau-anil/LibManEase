using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace LibManEase.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {

        protected async Task<ActionResult> ValidateAndExecuteAsync<T>(T model, Func<Task<ActionResult>> action)
        {
            IValidator<T> validator = Request.HttpContext.RequestServices.GetService(typeof(IValidator<T>)) as IValidator<T>;
            var validationResult = await validator.ValidateAsync(new ValidationContext<object>(model));

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return await action();
        }
    }
}
