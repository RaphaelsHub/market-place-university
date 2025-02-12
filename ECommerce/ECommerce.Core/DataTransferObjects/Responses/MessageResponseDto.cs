using ECommerce.Core.Enums.Operation;

namespace ECommerce.Core.DataTransferObjects.Responses
{
    public class MessageResponseDto
    {
        public int IdTrack { get; private set; }
        public string Message { get; private set; }
        public RequestStatus Status { get; private set; }

        public MessageResponseDto()
        {
            IdTrack = 0;
            Message = "An unexpected error occurred, please try again later !";
            Status = RequestStatus.Error;
        }
        
        public MessageResponseDto(int idTrack, string message, RequestStatus requestStatus = RequestStatus.Error)
        {
            Status = requestStatus;
            IdTrack = idTrack;
            Message = message;
        }
    }
}