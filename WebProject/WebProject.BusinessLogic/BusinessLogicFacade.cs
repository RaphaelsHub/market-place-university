using WebProject.BusinessLogic.MainBL;
using WebProject.Domain.Enum;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic
{
    public class BusinessLogicFacade
    {
        public UserBaseBL User;

        public BusinessLogicFacade()
        {
            User = new GuestBL();
        }

        public void UpdateUser(UserData userData)
        {
            switch (userData.StatusUser)
            {
                case StatusUser.Admin:
                    User = new AdminBL();
                    break;
                case StatusUser.User:
                    User = new UserBL();
                    break;
                default:
                    User = new UserBL();
                    break;
            }
        }
    }
}