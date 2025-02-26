using ECommerce.Core.Enums.Request;

namespace ECommerce.Core.Models.ViewModels
{
    public class ConfirmationViewModel
    {
        public string Message { get; private set; }
        public OperationStatus Status { get; private set; }

        public ConfirmationViewModel(OperationStatus operationStatus = OperationStatus.Error, string message = "An unexpected error occurred, please try again later !")
        {
            Status = operationStatus;
            Message = message;
        }
    }
}