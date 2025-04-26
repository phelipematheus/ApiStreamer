namespace Application.Common;

public class ApiResponse<T>(IEnumerable<T> data)
{
    public IEnumerable<T> Data { get; set; } = data;

    public static ApiResponse<T> CreateSimple(IEnumerable<T> data) => new(data);
}
