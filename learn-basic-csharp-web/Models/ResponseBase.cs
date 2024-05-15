namespace learn_basic_csharp_web.Models
{
    public class ResponseBase
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
