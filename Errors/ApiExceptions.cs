

namespace API.Errors;

public class ApiExceptions(int statusCode, string message = null, string? details = null)
{
    public int StatusCode { get; set; }= statusCode;
    public string Message { get; set; }= message ?? "Something went wrong";
    public string? Details { get; set; }= details;

}
