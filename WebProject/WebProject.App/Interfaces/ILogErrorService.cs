using System.Threading.Tasks;
using WebProject.Core.DTO;
using WebProject.Core.DTO.HelpFull;

namespace WebProject.App.Interfaces
{
    public interface ILogErrorService
    { 
        Task CreateLogErrorAsync(ErrorAnalyticDto logErrorDto);
    }
}