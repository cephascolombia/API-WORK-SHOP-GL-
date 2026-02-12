namespace WorkShopGL.Shared.Results
{
    public class DbCommandResult
    {
        public int ResultCode { get; set; }
        public string ResultMsg { get; set; } = "";
        public string? EntityId { get; set; }
    }
}
