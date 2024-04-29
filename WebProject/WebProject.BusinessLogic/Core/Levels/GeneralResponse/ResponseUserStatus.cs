using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.BusinessLogic.Core.Levels.GeneralResponse
{
    public class ResponseUserStatus
    {
        public bool Status { get; set; }
        public string ResponseMessage { get; set; }
        public bool IsAdmin { get; set; }
        public int ID { get; set; }
    }
}
