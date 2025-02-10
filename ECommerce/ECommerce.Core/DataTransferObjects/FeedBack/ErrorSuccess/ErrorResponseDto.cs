namespace ECommerce.Core.DataTransferObjects.FeedBack.ErrorSuccess
{
    public class ErrorResponseDto
    {
        public int Code { get; set; } = 500;
        public string ErrorMessage { get; set; } = "An unexpected error occurred, please try again later !";
        
        public ErrorResponseDto() { }
        
        public ErrorResponseDto(int errorCode, string errorMessage)
        {
            Code = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}