using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace CustomPrimitives.AspNetCore.Tests.WebApiTests;

public class StringPrimitiveTests
{
    private HttpClient _client;

    public StringPrimitiveTests()
    {
        var factory = new WebApplicationFactory<Program>();
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task FromRoute_SucceedsWhenValid()
    {
        var result = await _client.GetAsync("StringTests/FromRoute/abcde");
		result.EnsureSuccessStatusCode();
        (await result.Content.ReadAsStringAsync()).Should().Be("abcde");
	}

	[Fact]
	public async Task FromRoute_FailsWhenInvalid()
	{
		var result = await _client.GetAsync("StringTests/FromRoute/abcd");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("The length of this value must be at least 5 characters. You entered 4 characters.");
	}

	[Fact]
	public async Task FromQuery_SucceedsWhenValid()
	{
		var result = await _client.GetAsync("StringTests/FromQuery?custom=abcde");
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("abcde");
	}

	[Fact]
	public async Task FromQuery_FailsWhenInvalid()
	{
		var result = await _client.GetAsync("StringTests/FromQuery?custom=abcd");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("The length of this value must be at least 5 characters. You entered 4 characters.");
	}

	[Fact]
	public async Task FromHeader_SucceedsWhenValid()
	{
		_client.DefaultRequestHeaders.Add("custom", "abcde");
		var result = await _client.GetAsync("StringTests/FromHeader");
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("abcde");
	}

	[Fact]
	public async Task FromHeader_FailsWhenInvalid()
	{
		_client.DefaultRequestHeaders.Add("custom", "abcd");
		var result = await _client.GetAsync("StringTests/FromHeader");
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("The length of this value must be at least 5 characters. You entered 4 characters.");
	}

	[Fact]
	public async Task FromForm_SucceedsWhenValid()
	{
		var formData = new MultipartFormDataContent
		{
			{ new StringContent("abcde"), "custom" }
		};
		var result = await _client.PostAsync("StringTests/FromForm", formData);
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("abcde");
	}

	[Fact]
	public async Task FromForm_FailsWhenInvalid()
	{
		var formData = new MultipartFormDataContent
		{
			{ new StringContent("abcd"), "custom" }
		};
		var result = await _client.PostAsync("StringTests/FromForm", formData);
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("The length of this value must be at least 5 characters. You entered 4 characters.");
	}

	[Fact]
	public async Task FromBody_SucceedsWhenValid()
	{
		var result = await _client.PostAsync("StringTests/FromBody", new StringContent("abcde", System.Text.Encoding.UTF8, "application/json"));
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("abcde");
	}

	[Fact]
	public async Task FromBody_FailsWhenInvalid()
	{
		var result = await _client.PostAsync("StringTests/FromBody", new StringContent("abcd", System.Text.Encoding.UTF8, "application/json"));
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("The length of this value must be at least 5 characters. You entered 4 characters.");
	}

	[Fact]
	public async Task FromModel_SucceedsWhenValid()
	{
		var result = await _client.PostAsync("StringTests/FromModel", new StringContent("{\"Property\":\"abcde\"}", System.Text.Encoding.UTF8, "application/json"));
		result.EnsureSuccessStatusCode();
		(await result.Content.ReadAsStringAsync()).Should().Be("abcde");
	}

	[Fact]
	public async Task FromModel_FailsWhenInvalid()
	{
		var result = await _client.PostAsync("StringTests/FromModel", new StringContent("{\"Property\":\"abcd\"}", System.Text.Encoding.UTF8, "application/json"));
		result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
		(await result.Content.ReadAsStringAsync()).Should().Contain("The length of this value must be at least 5 characters. You entered 4 characters.");
	}
}