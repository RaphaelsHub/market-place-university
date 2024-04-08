using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.Enum
{
    public enum StatusDelivery
    {
        Pending,        // Ожидание
        Processing,     // Обработка
        Shipped,        // Отправлено
        OutForDelivery, // В пути
        Delivered,      // Доставлено
        Returned,       // Возвращено
        Canceled        // Отменено
    }
}
