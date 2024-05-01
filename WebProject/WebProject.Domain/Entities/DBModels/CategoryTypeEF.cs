using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.Entities.DBModels
{
    //мега крутая рекурсивная архитектура
    //дэ факто архитектура наследования ввиде дерева
    public class CategoryTypeEF
    {
        //[Key]
        public int CategoryTypeId { get; set; }
        public string CategoryName { get; set; }

        // Коллекция фильтров для катеогрии товара
        // public virtual ICollection<Filter> Filters { get; set; }


        // Навигационное свойство на родительскую категорию
        public int? ParentCategoryId { get; set; }

        //[ForeignKey("ParentCategoryId")]
        public virtual CategoryTypeEF ParentCategory { get; set; }

        // Коллекция дочерних категорий
        public virtual ICollection<CategoryTypeEF> ChildCategories { get; set; }
    }
}
