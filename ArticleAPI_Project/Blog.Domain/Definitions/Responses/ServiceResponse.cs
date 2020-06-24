namespace Blog.Domain.Definitions.Responses
{
    public sealed class ServiceResponse : ServiceResponse<object>
    {
    }

    public class ServiceResponse<TResult>
    {
        public TResult Data { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}