using System.ComponentModel.DataAnnotations;

namespace WebProject.Core.DTO.User
{
    public class PromoCodeDto
    {
        [StringLength(6)]
        public string Code { get; set; }
    }
}