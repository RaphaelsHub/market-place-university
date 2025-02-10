using WebProject.Core.Interfaces.Admin;

namespace WebProject.Dal.Repositories.Admin
{
    public class WebSiteControl : IWebSiteControl
    {
        private readonly StoreContext _context;
        
        public WebSiteControl(StoreContext context)
        {
            _context = context;
        }
        
    }
}