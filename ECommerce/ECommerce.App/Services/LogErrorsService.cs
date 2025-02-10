using System.Threading.Tasks;
using ECommerce.App.Interfaces;
using ECommerce.Core.DataTransferObjects.HelpFull;

namespace ECommerce.App.Services
{
    public class LogErrorsService : ILogErrorService
    {
        public Task CreateLogErrorAsync(ErrorAnalyticDto logErrorDto)
        {
            throw new System.NotImplementedException();
        }
    }
}