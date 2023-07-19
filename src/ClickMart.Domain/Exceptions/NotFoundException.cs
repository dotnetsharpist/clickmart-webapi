using System.Net;

namespace ClickMart.Domain.Exceptions;

public class NotFoundException
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public string TitleMessage { get; protected set; } = String.Empty;
}