using Functional;
using Microsoft.AspNetCore.Mvc;

namespace CustomPrimitives.Example.WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TestPrimitivesController : ControllerBase
	{
		[HttpPost("{email}/{id:guid}")]
		public Guid Post([FromBody] TestModel model, [FromRoute] Email email, [FromRoute] PersonId id)
		{
			//Email test = Email.Create("testtest").ThrowOnFailure(ex => new Exception(string.Join("'", ex.Errors.Select(x => x.ErrorMessage))));

			return id;
		}
	}
}
