namespace SimpleInnApp.Application.Common.Exception;

public class ErrorResponse
{
    public required string Title { get; set; }
    public required string Reason { get; set; }
}