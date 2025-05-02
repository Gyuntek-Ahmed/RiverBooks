using FastEndpoints;

namespace RiverBooks.Books.Endpoints;

internal class List(IBookService bookService) : EndpointWithoutRequest<ListBooksResponse>
{
    public override void Configure()
    {
        Get("/books");
        AllowAnonymous();
    }

    private readonly IBookService _bookService = bookService;
    public override async Task HandleAsync(CancellationToken ct = default)
    {
        var books = await _bookService.ListBooksAsync();

        await SendAsync(new ListBooksResponse()
        {
            Books = books
        });
    }
}
