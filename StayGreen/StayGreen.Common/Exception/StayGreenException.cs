using SystemExeption = System.Exception;

namespace StayGreen.Common.Exception
{
    public class StayGreenException : SystemExeption
    {
        public StayGreenException() {}

        public StayGreenException(
            int errorCode = default(int), 
            int statusCode = default(int),
            string userMessage = null,
            string developerMessage = null)
        {
            if (errorCode > 0)
            {
                ErrorCode = errorCode;
            }
            if (statusCode > 0)
            {
                StatusCode = statusCode;
            }
            if (!string.IsNullOrWhiteSpace(userMessage))
            {
                UserMessage = userMessage;
            }
            if (!string.IsNullOrWhiteSpace(developerMessage))
            {
                DeveloperMessage = developerMessage;
            }
        }

        public int ErrorCode { get; set; }
        public int StatusCode { get; set; }
        public virtual string UserMessage { get; set; }
        public string DeveloperMessage { get; set; }
    }
}
