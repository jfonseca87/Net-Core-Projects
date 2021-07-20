namespace WebAPICookiesTest.Models
{
    public class APIResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
