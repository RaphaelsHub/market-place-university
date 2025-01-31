namespace WebProject.Core.DTO.ResponcesDto
{
    public class MessageResponseDto
    {
        public string Success { get; set; }
        public int IdTrack { get; set; }
        public string Message { get; set; }
        
        public MessageResponseDto(string message = "No message found!", string success = "Error", int idTrack = -1)
        {
            Success = success;
            IdTrack = idTrack;
            Message = message;
        }
    }
}