namespace ECommerce.Core.DataTransferObjects.Responses
{
    public class ErrorResponseDto
    {
        public int Code { get; }
        public string ErrorMessage { get; }

        public ErrorResponseDto()
        {
            Code = 404;
            ErrorMessage = "Page Not Found. The requested resource could not be found on the server.";
        }

        public ErrorResponseDto(int errorCode, string errorMessage)
        {
            Code = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}