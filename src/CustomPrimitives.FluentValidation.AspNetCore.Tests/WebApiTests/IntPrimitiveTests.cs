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
    public async Task FromRoute_SucceedsWhenValid()
    {
        var result = await _client.GetAsync("IntTests/FromRoute/5");
		result.EnsureSuccessStatusCode();
        (await result.Content.ReadAsStringAsync()).Should().Be("5");
	}

	[Fact]
	public async Task FromRoute_FailsWhenInvalid()
	{
		var result = await _client.GetAsync("IntTests/FromRoute/4");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must be greater than '4'.");
	}

	[Fact]
	public async Task FromRouteWithType_SucceedsWhenValid()
	{
		var result = await _client.GetAsync("IntTests/FromRoute/5");
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("5");
	}

	[Fact]
	public async Task FromRouteWithType_FailsWhenInvalid()
	{
		var result = await _client.GetAsync("IntTests/FromRoute/4");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must be greater than '4'.");
	}

	[Fact]
	public async Task FromQuery_SucceedsWhenValid()
	{
		var result = await _client.GetAsync("IntTests/FromQuery?custom=5");
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("5");
	}

	[Fact]
	public async Task FromQuery_FailsWhenInvalid()
	{
		var result = await _client.GetAsync("IntTests/FromQuery?custom=4");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must be greater than '4'.");
	}

	[Fact]
	public async Task FromHeader_SucceedsWhenValid()
	{
		_client.DefaultRequestHeaders.Add("custom", "5");
		var result = await _client.GetAsync("IntTests/FromHeader");
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("5");
	}

	[Fact]
	public async Task FromHeader_FailsWhenInvalid()
	{
		_client.DefaultRequestHeaders.Add("custom", "4");
		var result = await _client.GetAsync("IntTests/FromHeader");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must be greater than '4'.");
	}

	[Fact]
	public async Task FromForm_SucceedsWhenValid()
	{
		var formData = new MultipartFormDataContent
		{
			{ new StringContent("5"), "custom" }
		};
		var result = await _client.PostAsync("IntTests/FromForm", formData);
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("5");
	}

	[Fact]
	public async Task FromForm_FailsWhenInvalid()
	{
		var formData = new MultipartFormDataContent
		{
			{ new StringContent("4"), "custom" }
		};
		var result = await _client.PostAsync("IntTests/FromForm", formData);
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must be greater than '4'.");
	}

	[Fact]
	public async Task FromBody_SucceedsWhenValid()
	{
		var result = await _client.PostAsync("IntTests/FromBody", new StringContent("5", System.Text.Encoding.UTF8, "application/json"));
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("5");
	}

	[Fact]
	public async Task FromBody_FailsWhenInvalid()
	{
		var result = await _client.PostAsync("IntTests/FromBody", new StringContent("4", System.Text.Encoding.UTF8, "application/json"));
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must be greater than '4'.");
	}

	[Fact]
	public async Task FromModel_SucceedsWhenValid()
	{
		var result = await _client.PostAsync("IntTests/FromModel", new StringContent("{\"Property\":5}", System.Text.Encoding.UTF8, "application/json"));
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("5");
	}

	[Fact]
	public async Task FromModel_FailsWhenInvalid()
	{
		var result = await _client.PostAsync("IntTests/FromModel", new StringContent("{\"Property\":4}", System.Text.Encoding.UTF8, "application/json"));
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("This value must be greater than '4'.");
	}
}