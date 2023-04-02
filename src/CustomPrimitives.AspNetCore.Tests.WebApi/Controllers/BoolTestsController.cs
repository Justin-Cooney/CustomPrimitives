using CustomPrimitives.AspNetCore.Tests.WebApi.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace CustomPrimitives.AspNetCore.Tests.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public partial class BoolTestsController : ControllerBase
{
	[HttpGet("FromRoute/{custom}")]
	public bool FromRoute([FromRoute] CustomBool custom)
		=> custom;

	[HttpGet("FromRouteWithType/{custom:bool}")]
	public bool FromRouteWithType([FromRoute] CustomBool custom)
		=> custom;

	[HttpGet("FromQuery")]
	public bool FromQuery([FromQuery] CustomBool custom)
		=> custom;

	[HttpGet("FromHeader")]
	public bool FromHeader([FromHeader] CustomBool custom)
		=> custom;

	[HttpPost("FromForm")]
	public bool FromForm([FromForm] CustomBool custom)
		=> custom;

	[HttpPost("FromBody")]
	public bool FromBody([FromBody] CustomBool custom)
		=> custom;

	[HttpPost("FromModel")]
	public bool FromModel([FromBody] CustomBoolModel custom)
		=> custom.Property;
}