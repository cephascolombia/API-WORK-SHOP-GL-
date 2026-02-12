namespace WorkShopGL.Shared.Results
{
    public class ApiResult
    {
        public bool Success { get; init; }
        public string? Message { get; init; }
        public object? Data { get; init; }

        public static ApiResult Ok(object? data = null)
            => new() { Success = true, Data = data };

        public static ApiResult Fail(string message)
            => new() { Success = false, Message = message };
    }
}
