namespace ECommerce.App.Interfaces
{
    public interface IAdminService
    {
        void ChangeWorkingNumber(uint newNumber);
        void ChangeWorkingEmail(string newEmail);
        void ChangeWorkingAddress(string newAddress);
        void ChangeWorkingName(string newName);
        void ChangeShopDescription(string newDescription);
        void ChangeShopPhoto(string newPhoto);
        void ChangeShopLogo(string newLogo);
        void ChangeSupportEmail(string newEmail);
        void ChangeSupportNumber(uint newNumber);
        void ChangeInfoEmail(string newEmail);
        void ChangeInfoNumber(uint newNumber);
        void ChangeInstagramLink(string newLink);
        void ChangeFacebookLink(string newLink);
        void ChangeTwitterLink(string newLink);
        void AddAnAd (string ad);
        
    }
}