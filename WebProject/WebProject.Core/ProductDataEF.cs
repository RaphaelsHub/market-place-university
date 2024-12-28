using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.DB
{
    public class ProductDataEF
    {
        [Key]
        public int ProductDataId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string PhotoUrls { get; set; }

        public int CategoryDataId { get; set; }
        
        [ForeignKey("CategoryDataId")]
        public CategoryDataEF CategoryData { get; set; } = new CategoryDataEF();


        public List<string> GetPhotos()
        {
            return new List<string>(PhotoUrls.Split(' '));
        }
        public bool SetPhotos(List<string> listData)
        {
            string photoUrls = "";
            foreach (string photoUrl in listData)
                photoUrls += photoUrl + " ";
            if (photoUrls != "")
            {
                PhotoUrls = photoUrls;
                return true;
            }
            return false;
        }
    }
}
