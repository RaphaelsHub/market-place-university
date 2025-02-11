namespace ECommerce.Core.DataTransferObjects.FeedBack.ErrorSuccess
{
    public class ErrorResponseDto
    {
        public int Code { get; }
        public string ErrorMessage { get; }

        public ErrorResponseDto()
        {
            Code = 500;
            ErrorMessage = "An unexpected error occurred, please try again later !";
        }

        public ErrorResponseDto(int errorCode = 500,
            string errorMessage = "An unexpected error occurred, please try again later !")
        {
            Code = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}