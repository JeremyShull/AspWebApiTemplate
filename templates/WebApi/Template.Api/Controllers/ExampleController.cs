using Microsoft.AspNetCore.Mvc;
using MultiValidation;
using Template.Domain.Entities;
using Template.Domain.Validators;

namespace Asp.Template.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly ILogger<ExampleController> _logger;
        private readonly MultiValidator _validator;

        public ExampleController(
            ILogger<ExampleController> logger,
            MultiValidator validator)
        {
            _logger = logger;
            _validator = validator;
        }

        /// <summary>
        /// Gets a fake person
        /// </summary>
        /// <param name="id" example="8854">The id of the requested user</param>
        /// <returns>A <see cref="Person"/></returns>
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            await _validator.For(id).Use<PersonIdValidator>()
                            .ValidateAsync();

            var person = new Person
            {
                ExampleId = id,
                Name = "Example Name",
                Description = "Example description",
                MaxPieSlicePrice = 5.24f
            };

            return Ok(person);
        }
    }
}
