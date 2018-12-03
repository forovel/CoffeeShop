namespace StayGreen.Web.Common.Helpers
{
    public class DeveloperResponse : Response
    {
        public DeveloperResponse() {}

        public DeveloperResponse(Response response)
        {
            ErrorCode = response.ErrorCode;
            StatusCode = response.StatusCode;
            UserMessage = response.UserMessage;
            MoreInfo = response.MoreInfo;
        }

        public string DeveloperMessage { get; set; }
    }
}
