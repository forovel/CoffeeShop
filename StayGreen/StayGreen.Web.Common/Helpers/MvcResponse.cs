namespace StayGreen.Web.Common.Helpers
{
    public class MvcResponse
    {
        public int? ErrorCode { get; set; }
        public int? StatusCode { get; set; }
        public string UserMessage { get; set; }
        public string MoreInfo { get; set; }

        public bool ShowResponse { get; set; }

        public string DeveloperMessage { get; set; }
    }
}
