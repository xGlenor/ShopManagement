namespace ShopManagementService.Application.Common.Responses;

public record Response<T>
{
    public T Data { get; init; }
    public bool Success { get; init; }
    public string Message { get; init; }
}