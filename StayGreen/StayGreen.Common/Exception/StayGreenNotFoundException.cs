using System.Net;
using ErrorCodes = StayGreen.Common.Enums.ErrorCode;

namespace StayGreen.Common.Exception
{
    public class StayGreenNotFoundException : StayGreenException
    {
        readonly string _entityName;

        public StayGreenNotFoundException()
        {
            ErrorCode = (int)ErrorCodes.NotFound;
            StatusCode = (int)HttpStatusCode.NotFound;
            DeveloperMessage = Message;
            _entityName = "Entity";
        }

        public StayGreenNotFoundException(string entityName) : this()
        {
            _entityName = entityName;
        }

        public override string Message => $"{_entityName} entity was not found";
    }
}
