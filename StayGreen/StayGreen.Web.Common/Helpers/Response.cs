namespace StayGreen.Web.Common.Helpers
{
    public class Response
    {
        public int? ErrorCode { get; set; }
        public int? StatusCode { get; set; }
        public string UserMessage { get; set; }
        public string MoreInfo { get; set; }
    }
}
