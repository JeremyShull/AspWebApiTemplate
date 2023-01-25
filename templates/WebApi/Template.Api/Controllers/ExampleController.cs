using Microsoft.AspNetCore.Mvc;
using MultiValidation;
using Template.Domain.Entities;
using Template.Domain.Validators;

namespace Asp.Template.Api.Controllers
{
    /// <summary>
    /// An example of a controller
    /// </summary>
    [ApiController]
    [Route("/api/v1")]
    public class ExampleController : ControllerBase
    {
        private readonly ILogger<ExampleController> _logger;
        private readonly MultiValidator _validator;

        /// <summary>
        /// Constructs an instance of an object
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="validator"></param>
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
        [HttpGet("example")]
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
