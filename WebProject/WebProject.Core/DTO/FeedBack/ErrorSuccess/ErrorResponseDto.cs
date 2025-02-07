using WebProject.Helper;

namespace WebProject.Core.DTO.FeedBack.ErrorSuccess
{
    public class ErrorResponseDto
    {
        public int Code { get; }
        public string ErrorMessage { get; }
        
        public ErrorResponseDto(int errorCode = 500)
        {
            Code = errorCode;
            ErrorMessage = ErrorHelper.GetErrorMessage(errorCode);
        }
    }
}