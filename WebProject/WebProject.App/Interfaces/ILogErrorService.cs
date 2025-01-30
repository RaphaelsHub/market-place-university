using System.Threading.Tasks;
using WebProject.Core.DTO;

namespace WebProject.App.Interfaces
{
    public interface ILogErrorService
    { 
        Task CreateLogErrorAsync(ErrorDto logErrorDto);
    }
}