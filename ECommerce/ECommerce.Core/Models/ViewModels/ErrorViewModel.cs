namespace ECommerce.Core.Models.ViewModels
{
    public class ErrorViewModel
    {
        public int Code { get; private set; }
        public string ErrorMessage { get; private set; }

        public ErrorViewModel(int errorCode, string errorMessage)
        {
            Code = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}