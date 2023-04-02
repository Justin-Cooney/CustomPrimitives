using CustomPrimitives.FluentValidation.AspNetCore.Tests.WebApi.Models;
using CustomPrimitives.FluentValidation.AspNetCore.Tests.WebApi.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace CustomPrimitives.FluentValidation.AspNetCore.Tests.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class IntTestsController : ControllerBase
{
	[HttpGet("FromRoute/{custom}")]
	public int FromRoute([FromRoute] CustomInt custom)
		=> custom;

	[HttpGet("FromRouteWithType/{custom:int}")]
	public int FromRouteWithType([FromRoute] CustomInt custom)
		=> custom;

	[HttpGet("FromQuery")]
	public int FromQuery([FromQuery] CustomInt custom)
		=> custom;

	[HttpGet("FromHeader")]
	public int FromHeader([FromHeader] CustomInt custom)
		=> custom;

	[HttpPost("FromForm")]
	public int FromForm([FromForm] CustomInt custom)
		=> custom;

	[HttpPost("FromBody")]
	public int FromBody([FromBody] CustomInt custom)
		=> custom;

	[HttpPost("FromModel")]
	public int FromModel([FromBody] CustomIntModel custom)
		=> custom.Property;
}