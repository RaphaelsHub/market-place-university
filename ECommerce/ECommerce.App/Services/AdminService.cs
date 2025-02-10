using WebProject.App.Interfaces;
using WebProject.Core.Interfaces.Admin;

namespace WebProject.App.Services
{
    public class AdminService  : IAdminService
    {
        private readonly IWebSiteControl _adminRepository;
        
        public AdminService(IWebSiteControl adminRepository)
        {
            _adminRepository = adminRepository;
        }
        
        public void ChangeWorkingNumber(uint newNumber)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeWorkingEmail(string newEmail)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeWorkingAddress(string newAddress)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeWorkingName(string newName)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeShopDescription(string newDescription)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeShopPhoto(string newPhoto)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeShopLogo(string newLogo)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeSupportEmail(string newEmail)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeSupportNumber(uint newNumber)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeInfoEmail(string newEmail)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeInfoNumber(uint newNumber)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeInstagramLink(string newLink)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeFacebookLink(string newLink)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeTwitterLink(string newLink)
        {
            throw new System.NotImplementedException();
        }

        public void AddAnAd(string ad)
        {
            throw new System.NotImplementedException();
        }
    }
}
