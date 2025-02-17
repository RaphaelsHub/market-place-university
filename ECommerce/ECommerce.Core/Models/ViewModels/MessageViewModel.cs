using ECommerce.Core.Enums.Message;

namespace ECommerce.Core.Models.ViewModels
{
    public class MessageViewModel
    {
        public int IdTrack { get; private set; }
        public string Message { get; private set; }
        public RequestStatus Status { get; private set; }

        public MessageViewModel()
        {
            IdTrack = 0;
            Message = "An unexpected error occurred, please try again later !";
            Status = RequestStatus.Error;
        }
        
        public MessageViewModel(int idTrack, string message, RequestStatus requestStatus = RequestStatus.Error)
        {
            Status = requestStatus;
            IdTrack = idTrack;
            Message = message;
        }
    }
}