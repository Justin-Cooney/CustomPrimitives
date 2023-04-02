using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace CustomPrimitives.AspNetCore.Tests.WebApiTests;

public class GuidPrimitiveTests
{
    private HttpClient _client;

    public GuidPrimitiveTests()
    {
        var factory = new WebApplicationFactory<Program>();
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task FromRoute_Succeeds()
    {
        var result = await _client.GetAsync("GuidTests/FromRoute/a8d9289a-22a4-4297-8c43-cc42b8637e2c");
        (await result.Content.ReadAsStringAsync()).Should().Be("\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"");
	}

	[Fact]
	public async Task FromRouteWithType_Succeeds()
	{
		var result = await _client.GetAsync("GuidTests/FromRouteWithType/a8d9289a-22a4-4297-8c43-cc42b8637e2c");
		(await result.Content.ReadAsStringAsync()).Should().Be("\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"");
	}

	[Fact]
	public async Task FromQuery_Succeeds()
	{
		var result = await _client.GetAsync("GuidTests/FromQuery?custom=a8d9289a-22a4-4297-8c43-cc42b8637e2c");
		(await result.Content.ReadAsStringAsync()).Should().Be("\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"");
	}

	[Fact]
	public async Task FromHeader_Succeeds()
	{
		_client.DefaultRequestHeaders.Add("custom", "a8d9289a-22a4-4297-8c43-cc42b8637e2c");
		var result = await _client.GetAsync("GuidTests/FromHeader");
		(await result.Content.ReadAsStringAsync()).Should().Be("\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"");
	}

	[Fact]
	public async Task FromForm_Succeeds()
	{
		var formData = new MultipartFormDataContent
		{
			{ new StringContent("a8d9289a-22a4-4297-8c43-cc42b8637e2c"), "custom" }
		};
		var result = await _client.PostAsync("GuidTests/FromForm", formData);
		(await result.Content.ReadAsStringAsync()).Should().Be("\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"");
	}

	[Fact]
	public async Task FromBody_Succeeds()
	{
		var result = await _client.PostAsync("GuidTests/FromBody", new StringContent("a8d9289a-22a4-4297-8c43-cc42b8637e2c", System.Text.Encoding.UTF8, "application/json"));
		(await result.Content.ReadAsStringAsync()).Should().Be("\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"");
	}

	[Fact]
	public async Task FromModel_Succeeds()
	{
		var result = await _client.PostAsync("GuidTests/FromModel", new StringContent("{\"Property\":\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"}", System.Text.Encoding.UTF8, "application/json"));
		(await result.Content.ReadAsStringAsync()).Should().Be("\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"");
	}
}