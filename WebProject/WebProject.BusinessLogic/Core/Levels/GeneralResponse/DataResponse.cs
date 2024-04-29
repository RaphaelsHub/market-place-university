using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.BusinessLogic.Core.Levels.GeneralResponse
{
    public class DataResponse<DataType>
    {
        public DataType Data { get; set; }
        public bool IsExist { get; set; }
        public string ResponseMessage { get; set; }
    }
}
