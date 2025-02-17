namespace ECommerce.Core.Models.ViewModels
{
    public class ErrorViewModel
    {
        public int Code { get; }
        public string ErrorMessage { get; }

        public ErrorViewModel()
        {
            Code = 404;
            ErrorMessage = "Page Not Found. The requested resource could not be found on the server.";
        }

        public ErrorViewModel(int errorCode, string errorMessage)
        {
            Code = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}