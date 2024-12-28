using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.Enum
{
    //PS. Don't touch Enum values, check WebProject.BusinessLogic.MainBL.GuestBL
    public enum StatusDelivery
    {
        Pending = 1,        // Ожидание
        Processing = 2,     // Обработка
        Shipped = 3,        // Отправлено
        OutForDelivery = 4, // В пути
        Delivered = 5,      // Доставлено
        Returned = 6,       // Возвращено
        Canceled = 7        // Отменено
    }
}
