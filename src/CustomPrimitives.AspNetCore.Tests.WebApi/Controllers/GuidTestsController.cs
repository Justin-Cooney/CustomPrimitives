using CustomPrimitives.AspNetCore.Tests.WebApi.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace CustomPrimitives.AspNetCore.Tests.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public partial class GuidTestsController : ControllerBase
{
	[HttpGet("FromRoute/{custom}")]
	public Guid FromRoute([FromRoute] CustomGuid custom)
		=> custom;

	[HttpGet("FromRouteWithType/{custom:guid}")]
	public Guid FromRouteWithType([FromRoute] CustomGuid custom)
		=> custom;

	[HttpGet("FromQuery")]
	public Guid FromQuery([FromQuery] CustomGuid custom)
		=> custom;

	[HttpGet("FromHeader")]
	public Guid FromHeader([FromHeader] CustomGuid custom)
		=> custom;

	[HttpPost("FromForm")]
	public Guid FromForm([FromForm] CustomGuid custom)
		=> custom;

	[HttpPost("FromBody")]
	public Guid FromBody([FromBody] CustomGuid custom)
		=> custom;

	[HttpPost("FromModel")]
	public Guid FromModel([FromBody] CustomGuidModel custom)
		=> custom.Property;
}