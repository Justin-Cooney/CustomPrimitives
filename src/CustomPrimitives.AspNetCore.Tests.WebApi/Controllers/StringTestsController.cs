using CustomPrimitives.AspNetCore.Tests.WebApi.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace CustomPrimitives.AspNetCore.Tests.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public partial class StringTestsController : ControllerBase
{
	[HttpGet("FromRoute/{custom}")]
	public string FromRoute([FromRoute] CustomString custom)
		=> custom;

	[HttpGet("FromQuery")]
	public string FromQuery([FromQuery] CustomString custom)
		=> custom;

	[HttpGet("FromHeader")]
	public string FromHeader([FromHeader] CustomString custom)
		=> custom;

	[HttpPost("FromForm")]
	public string FromForm([FromForm] CustomString custom)
		=> custom;

	[HttpPost("FromBody")]
	public string FromBody([FromBody] CustomString custom)
		=> custom;

	[HttpPost("FromModel")]
	public string FromModel([FromBody] CustomStringModel custom)
		=> custom.Property;
}