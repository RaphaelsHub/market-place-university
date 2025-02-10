using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects.HelpFull;

namespace ECommerce.App.Interfaces
{
    public interface ILogErrorService
    { 
        Task CreateLogErrorAsync(ErrorAnalyticDto logErrorDto);
    }
}