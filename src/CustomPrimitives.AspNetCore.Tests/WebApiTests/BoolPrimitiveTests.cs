using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace CustomPrimitives.AspNetCore.Tests.WebApiTests;

public class BoolPrimitiveTests
{
    private HttpClient _client;

    public BoolPrimitiveTests()
    {
        var factory = new WebApplicationFactory<Program>();
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task FromRoute_Succeeds()
    {
        var result = await _client.GetAsync("BoolTests/FromRoute/true");
        (await result.Content.ReadAsStringAsync()).Should().Be("true");
	}

	[Fact]
	public async Task FromRouteWithType_Succeeds()
	{
		var result = await _client.GetAsync("BoolTests/FromRouteWithType/true");
		(await result.Content.ReadAsStringAsync()).Should().Be("true");
	}

	[Fact]
	public async Task FromQuery_Succeeds()
	{
		var result = await _client.GetAsync("BoolTests/FromQuery?custom=true");
		(await result.Content.ReadAsStringAsync()).Should().Be("true");
	}

	[Fact]
	public async Task FromHeader_Succeeds()
	{
		_client.DefaultRequestHeaders.Add("custom", "true");
		var result = await _client.GetAsync("BoolTests/FromHeader");
		(await result.Content.ReadAsStringAsync()).Should().Be("true");
	}

	[Fact]
	public async Task FromForm_Succeeds()
	{
		var formData = new MultipartFormDataContent
		{
			{ new StringContent("true"), "custom" }
		};
		var result = await _client.PostAsync("BoolTests/FromForm", formData);
		(await result.Content.ReadAsStringAsync()).Should().Be("true");
	}

	[Fact]
	public async Task FromBody_Succeeds()
	{
		var result = await _client.PostAsync("BoolTests/FromBody", new StringContent("true", System.Text.Encoding.UTF8, "application/json"));
		(await result.Content.ReadAsStringAsync()).Should().Be("true");
	}

	[Fact]
	public async Task FromModel_Succeeds()
	{
		var result = await _client.PostAsync("BoolTests/FromModel", new StringContent("{\"Property\":true}", System.Text.Encoding.UTF8, "application/json"));
		(await result.Content.ReadAsStringAsync()).Should().Be("true");
	}
}