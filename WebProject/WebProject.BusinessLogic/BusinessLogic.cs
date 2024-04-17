using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.BusinessLogic.Interfaces;
using WebProject.BusinessLogic.MainBL;

namespace WebProject.BusinessLogic
{
    public class BusinessLogic
    {
        public AdminBL AdminBL { get; }
        public UserBL UserBL { get; }
        public GuestBL GuestBL { get; }
        public ProductBL ProductBL { get; }

        public BusinessLogic()
        {
            AdminBL = new AdminBL();
            UserBL = new UserBL();
            GuestBL = new GuestBL();
            ProductBL = new ProductBL();
        }
    }
}