using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace CustomPrimitives.AspNetCore.Tests.WebApiTests;

public class IntPrimitiveTests
{
    private HttpClient _client;

    public IntPrimitiveTests()
    {
        var factory = new WebApplicationFactory<Program>();
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task FromRoute_Succeeds()
    {
        var result = await _client.GetAsync("IntTests/FromRoute/1234");
        (await result.Content.ReadAsStringAsync()).Should().Be("1234");
	}

	[Fact]
	public async Task FromRouteWithType_Succeeds()
	{
		var result = await _client.GetAsync("IntTests/FromRouteWithType/1234");
		(await result.Content.ReadAsStringAsync()).Should().Be("1234");
	}

	[Fact]
	public async Task FromQuery_Succeeds()
	{
		var result = await _client.GetAsync("IntTests/FromQuery?custom=1234");
		(await result.Content.ReadAsStringAsync()).Should().Be("1234");
	}

	[Fact]
	public async Task FromHeader_Succeeds()
	{
		_client.DefaultRequestHeaders.Add("custom", "1234");
		var result = await _client.GetAsync("IntTests/FromHeader");
		(await result.Content.ReadAsStringAsync()).Should().Be("1234");
	}

	[Fact]
	public async Task FromForm_Succeeds()
	{
		var formData = new MultipartFormDataContent
		{
			{ new StringContent("1234"), "custom" }
		};
		var result = await _client.PostAsync("IntTests/FromForm", formData);
		(await result.Content.ReadAsStringAsync()).Should().Be("1234");
	}

	[Fact]
	public async Task FromBody_Succeeds()
	{
		var result = await _client.PostAsync("IntTests/FromBody", new StringContent("1234", System.Text.Encoding.UTF8, "application/json"));
		(await result.Content.ReadAsStringAsync()).Should().Be("1234");
	}

	[Fact]
	public async Task FromModel_Succeeds()
	{
		var result = await _client.PostAsync("IntTests/FromModel", new StringContent("{\"Property\":1234}", System.Text.Encoding.UTF8, "application/json"));
		(await result.Content.ReadAsStringAsync()).Should().Be("1234");
	}
}