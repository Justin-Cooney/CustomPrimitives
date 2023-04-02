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
    public async Task FromRoute_SucceedsWhenValid()
    {
        var result = await _client.GetAsync("GuidTests/FromRoute/a8d9289a-22a4-4297-8c43-cc42b8637e2c");
		result.EnsureSuccessStatusCode();
        (await result.Content.ReadAsStringAsync()).Should().Be("\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"");
	}

	[Fact]
	public async Task FromRoute_FailsWhenInvalid()
	{
		var result = await _client.GetAsync("GuidTests/FromRoute/00000000-0000-0000-0000-000000000000");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must not be empty.");
	}

	[Fact]
	public async Task FromRouteWithType_SucceedsWhenValid()
	{
		var result = await _client.GetAsync("GuidTests/FromRoute/a8d9289a-22a4-4297-8c43-cc42b8637e2c");
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"");
	}

	[Fact]
	public async Task FromRouteWithType_FailsWhenInvalid()
	{
		var result = await _client.GetAsync("GuidTests/FromRoute/00000000-0000-0000-0000-000000000000");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must not be empty.");
	}

	[Fact]
	public async Task FromQuery_SucceedsWhenValid()
	{
		var result = await _client.GetAsync("GuidTests/FromQuery?custom=a8d9289a-22a4-4297-8c43-cc42b8637e2c");
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"");
	}

	[Fact]
	public async Task FromQuery_FailsWhenInvalid()
	{
		var result = await _client.GetAsync("GuidTests/FromQuery?custom=00000000-0000-0000-0000-000000000000");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must not be empty.");
	}

	[Fact]
	public async Task FromHeader_SucceedsWhenValid()
	{
		_client.DefaultRequestHeaders.Add("custom", "a8d9289a-22a4-4297-8c43-cc42b8637e2c");
		var result = await _client.GetAsync("GuidTests/FromHeader");
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"");
	}

	[Fact]
	public async Task FromHeader_FailsWhenInvalid()
	{
		_client.DefaultRequestHeaders.Add("custom", "00000000-0000-0000-0000-000000000000");
		var result = await _client.GetAsync("GuidTests/FromHeader");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must not be empty.");
	}

	[Fact]
	public async Task FromForm_SucceedsWhenValid()
	{
		var formData = new MultipartFormDataContent
		{
			{ new StringContent("a8d9289a-22a4-4297-8c43-cc42b8637e2c"), "custom" }
		};
		var result = await _client.PostAsync("GuidTests/FromForm", formData);
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"");
	}

	[Fact]
	public async Task FromForm_FailsWhenInvalid()
	{
		var formData = new MultipartFormDataContent
		{
			{ new StringContent("00000000-0000-0000-0000-000000000000"), "custom" }
		};
		var result = await _client.PostAsync("GuidTests/FromForm", formData);
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must not be empty.");
	}

	[Fact]
	public async Task FromBody_SucceedsWhenValid()
	{
		var result = await _client.PostAsync("GuidTests/FromBody", new StringContent("a8d9289a-22a4-4297-8c43-cc42b8637e2c", System.Text.Encoding.UTF8, "application/json"));
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"");
	}

	[Fact]
	public async Task FromBody_FailsWhenInvalid()
	{
		var result = await _client.PostAsync("GuidTests/FromBody", new StringContent("00000000-0000-0000-0000-000000000000", System.Text.Encoding.UTF8, "application/json"));
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must not be empty.");
	}

	[Fact]
	public async Task FromModel_SucceedsWhenValid()
	{
		var result = await _client.PostAsync("GuidTests/FromModel", new StringContent("{\"Property\":\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"}", System.Text.Encoding.UTF8, "application/json"));
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("\"a8d9289a-22a4-4297-8c43-cc42b8637e2c\"");
	}

	[Fact]
	public async Task FromModel_FailsWhenInvalid()
	{
		var result = await _client.PostAsync("GuidTests/FromModel", new StringContent("{\"Property\":\"00000000-0000-0000-0000-000000000000\"}", System.Text.Encoding.UTF8, "application/json"));
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must not be empty.");
	}
}