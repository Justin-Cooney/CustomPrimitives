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
    public async Task FromRoute_SucceedsWhenValid()
    {
        var result = await _client.GetAsync("BoolTests/FromRoute/true");
		result.EnsureSuccessStatusCode();
        (await result.Content.ReadAsStringAsync()).Should().Be("true");
	}

	[Fact]
	public async Task FromRoute_FailsWhenInvalid()
	{
		var result = await _client.GetAsync("BoolTests/FromRoute/false");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must be equal to 'True'");
	}

	[Fact]
	public async Task FromRouteWithType_SucceedsWhenValid()
	{
		var result = await _client.GetAsync("BoolTests/FromRoute/true");
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("true");
	}

	[Fact]
	public async Task FromRouteWithType_FailsWhenInvalid()
	{
		var result = await _client.GetAsync("BoolTests/FromRoute/false");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must be equal to 'True'");
	}

	[Fact]
	public async Task FromQuery_SucceedsWhenValid()
	{
		var result = await _client.GetAsync("BoolTests/FromQuery?custom=true");
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("true");
	}

	[Fact]
	public async Task FromQuery_FailsWhenInvalid()
	{
		var result = await _client.GetAsync("BoolTests/FromQuery?custom=false");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must be equal to 'True'");
	}

	[Fact]
	public async Task FromHeader_SucceedsWhenValid()
	{
		_client.DefaultRequestHeaders.Add("custom", "true");
		var result = await _client.GetAsync("BoolTests/FromHeader");
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("true");
	}

	[Fact]
	public async Task FromHeader_FailsWhenInvalid()
	{
		_client.DefaultRequestHeaders.Add("custom", "false");
		var result = await _client.GetAsync("BoolTests/FromHeader");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must be equal to 'True'");
	}

	[Fact]
	public async Task FromForm_SucceedsWhenValid()
	{
		var formData = new MultipartFormDataContent
		{
			{ new StringContent("true"), "custom" }
		};
		var result = await _client.PostAsync("BoolTests/FromForm", formData);
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("true");
	}

	[Fact]
	public async Task FromForm_FailsWhenInvalid()
	{
		var formData = new MultipartFormDataContent
		{
			{ new StringContent("false"), "custom" }
		};
		var result = await _client.PostAsync("BoolTests/FromForm", formData);
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must be equal to 'True'");
	}

	[Fact]
	public async Task FromBody_SucceedsWhenValid()
	{
		var result = await _client.PostAsync("BoolTests/FromBody", new StringContent("true", System.Text.Encoding.UTF8, "application/json"));
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("true");
	}

	[Fact]
	public async Task FromBody_FailsWhenInvalid()
	{
		var result = await _client.PostAsync("BoolTests/FromBody", new StringContent("false", System.Text.Encoding.UTF8, "application/json"));
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must be equal to 'True'");
	}

	[Fact]
	public async Task FromModel_SucceedsWhenValid()
	{
		var result = await _client.PostAsync("BoolTests/FromModel", new StringContent("{\"Property\":true}", System.Text.Encoding.UTF8, "application/json"));
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("true");
	}

	[Fact]
	public async Task FromModel_FailsWhenInvalid()
	{
		var result = await _client.PostAsync("BoolTests/FromModel", new StringContent("{\"Property\":false}", System.Text.Encoding.UTF8, "application/json"));
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must be equal to 'True'");
	}
}