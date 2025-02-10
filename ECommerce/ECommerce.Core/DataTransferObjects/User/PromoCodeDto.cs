using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.DataTransferObjects.User
{
    public class PromoCodeDto
    {
        [StringLength(6)]
        public string Code { get; set; }
    }
}