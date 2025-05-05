using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using RiverBooks.Books.Endpoints;
using Xunit.Abstractions;

namespace RiverBooks.Books.Tests.Endpoints
{
    public class BookGetById(Fixture fixture, ITestOutputHelper outputHelper) : TestClass<Fixture>(fixture, outputHelper)
    {
        [Theory]
        [InlineData("ca4ae756-5f8e-43e6-9a19-00cd9b1ecf41", "The Lord of the Rings")]
        [InlineData("54f8ec8c-0a5c-4cbd-bb0d-0e7dc86279bd", "The Silmarillion")]
        [InlineData("21def808-7199-4d5f-9707-b3d3a76d5d85", "The Hobbit")]
        public async Task ReturnsExpectedBookGivenIdAsync(string validId, string expectedTitle)
        {
            Guid id = Guid.Parse(validId);
            var request = new GetBookByIdRequest { Id = id };
            var testResult = await Fixture.Client.GETAsync<GetById, GetBookByIdRequest, BookDto>(request);

            testResult.Response.EnsureSuccessStatusCode();
            testResult.Result.Title.Should().Be(expectedTitle);
        }
    }
}
