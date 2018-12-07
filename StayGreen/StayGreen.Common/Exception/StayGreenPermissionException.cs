using System.Net;
using ErrorCodes = StayGreen.Common.Enums.ErrorCode;

namespace StayGreen.Common.Exception
{
    public sealed class StayGreenPermissionException : StayGreenException
    {
        public StayGreenPermissionException()
        {
            StatusCode = (int)HttpStatusCode.Forbidden;
            ErrorCode = (int)ErrorCodes.NoPermission;
            DeveloperMessage = Message;
        }

        public override string UserMessage => "Does not have permissions for this action";
    }
}
