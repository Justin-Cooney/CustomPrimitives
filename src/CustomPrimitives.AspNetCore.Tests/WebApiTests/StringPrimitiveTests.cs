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
    public async Task FromRoute_Succeeds()
    {
        var result = await _client.GetAsync("StringTests/FromRoute/abcd1234");
        (await result.Content.ReadAsStringAsync()).Should().Be("abcd1234");
	}

	[Fact]
	public async Task FromQuery_Succeeds()
	{
		var result = await _client.GetAsync("StringTests/FromQuery?custom=abcd1234");
		(await result.Content.ReadAsStringAsync()).Should().Be("abcd1234");
	}

	[Fact]
	public async Task FromHeader_Succeeds()
	{
		_client.DefaultRequestHeaders.Add("custom", "abcd1234");
		var result = await _client.GetAsync("StringTests/FromHeader");
		(await result.Content.ReadAsStringAsync()).Should().Be("abcd1234");
	}

	[Fact]
	public async Task FromForm_Succeeds()
	{
		var formData = new MultipartFormDataContent
		{
			{ new StringContent("abcd1234"), "custom" }
		};
		var result = await _client.PostAsync("StringTests/FromForm", formData);
		(await result.Content.ReadAsStringAsync()).Should().Be("abcd1234");
	}

	[Fact]
	public async Task FromBody_Succeeds()
	{
		var result = await _client.PostAsync("StringTests/FromBody", new StringContent("abcd1234", System.Text.Encoding.UTF8, "application/json"));
		(await result.Content.ReadAsStringAsync()).Should().Be("abcd1234");
	}

	[Fact]
	public async Task FromModel_Succeeds()
	{
		var result = await _client.PostAsync("StringTests/FromModel", new StringContent("{\"Property\":\"abcd1234\"}", System.Text.Encoding.UTF8, "application/json"));
		(await result.Content.ReadAsStringAsync()).Should().Be("abcd1234");
	}
}