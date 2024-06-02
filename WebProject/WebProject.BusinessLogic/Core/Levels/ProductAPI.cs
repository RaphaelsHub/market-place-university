using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebProject.BusinessLogic.Core.Levels.GeneralResponse;
using WebProject.BusinessLogic.Core.Levels.Product;
using WebProject.Domain;
using WebProject.Domain.DB;


namespace WebProject.BusinessLogic.Core.Levels
{
    public class ProductAPI
    {
        internal DataResponse<ProductDataEF> GetSingleProductData(int id)
        {
            using (var db = new Context())
            {
                var prod = db.Products.FirstOrDefault(p => p.ProductDataId == id);

                return new DataResponse<ProductDataEF>
                {
                    Data = prod,
                    IsExist = prod != null,
                    ResponseMessage = prod != null ? "Good" : $"There is no ProductData with this id: {id}"
                };
            }
        }
        internal StandartResponse DeleteProductDataByID(int id)
        {
            var prodResponse = GetSingleProductData(id);

            if (!prodResponse.IsExist)
            {
                return new StandartResponse
                {
                    Status = false,
                    ResponseMessage = prodResponse.ResponseMessage
                };
            }

            using (var db = new Context())
            {
                try
                {
                    var productDataToDelete = prodResponse.Data;
                    db.Products.Remove(productDataToDelete);
                    db.SaveChanges();

                    return new StandartResponse { Status = true, ResponseMessage = "" };
                }
                catch (Exception ex)
                {
                    return new StandartResponse { Status = false, ResponseMessage = "Unexpected error: " + ex.Message };
                }
            }
        }
        internal StandartResponse AddProductDataToDB(ProductDataEF prod)
        {
            if (!IsValidProductData(prod)) //checking that all fields are not null and the validity of Price and Amount
            {
                return new StandartResponse
                {
                    Status = false,
                    ResponseMessage = "Incorrect ProductData data"
                };
            }

            using (var db = new Context())
            {
                try
                {
                    var sameProductData = db.Products.FirstOrDefault(p => p.Name == prod.Name);
                    if (sameProductData != null)
                    {
                        return new StandartResponse
                        {
                            Status = false,
                            ResponseMessage = "Same ProductData already exist"
                        };
                    }

                    db.Products.Add(prod);
                    db.SaveChanges();
                    return new StandartResponse
                    {
                        Status = true,
                        ResponseMessage = ""
                    };
                }
                catch (Exception ex)
                {
                    return new StandartResponse
                    {
                        Status = false,
                        ResponseMessage = "Unexpected error: " + ex.Message
                    };
                }
            }
        }
        internal bool IsValidProductData(ProductDataEF prod)
        {
            return (
                prod.Name != null &&
                prod.ShortDescription != null &&
                prod.Price > 0 && prod.FullDescription != null && prod.Amount >= 0);
        }
        internal StandartResponse ModifyProductData(ProductDataEF updatedProductData)
        {
            using (var db = new Context())
            {
                try
                {
                    var existingProductData = db.Products.FirstOrDefault(p => p.ProductDataId == updatedProductData.ProductDataId);

                    if (existingProductData != null)
                    {
                        existingProductData.Name = updatedProductData.Name;
                        existingProductData.PhotoUrls = updatedProductData.PhotoUrls;
                        existingProductData.Amount = updatedProductData.Amount;
                        existingProductData.Price = updatedProductData.Price;
                        existingProductData.ShortDescription = updatedProductData.ShortDescription;
                        existingProductData.FullDescription = updatedProductData.FullDescription;

                        db.SaveChanges();

                        return new StandartResponse
                        {
                            Status = true,
                            ResponseMessage = ""
                        };
                    }
                    else
                    {
                        return new StandartResponse
                        {
                            Status = false,
                            ResponseMessage = $"There is no ProductData with this id: {updatedProductData.ProductDataId}"
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new StandartResponse
                    {
                        Status = false,
                        ResponseMessage = "Unexpected error: " + ex.Message
                    };
                }
            }
        }
        internal DataResponse<List<ProductDataEF>> GetAllProducts()
        {
            var BigPage = new PageInfo
            {
                PageIndex = 0,
                ProductsPerPage = int.MaxValue
            };
            return GetProductsOnPages(BigPage);
        }
        internal DataResponse<List<ProductDataEF>> GetProductsOnPages(PageInfo currentPage)
        {
            uint ProductsPerPage = currentPage.ProductsPerPage;
            uint pageIndex = currentPage.PageIndex;

            uint startIndex = pageIndex * ProductsPerPage; //index of first element

            using (var db = new Context())
            {
                try
                {
                    var ProductsOnPage = db.Products
                                .OrderBy(p => p.ProductDataId)     //order ProductData by ID
                                .Skip((int)startIndex)
                                .Take((int)ProductsPerPage)
                                .ToList();
                    return new DataResponse<List<ProductDataEF>>
                    {
                        Data = ProductsOnPage,
                        IsExist = true,
                        ResponseMessage = ""
                    };
                }
                catch (Exception ex)
                {
                    return new DataResponse<List<ProductDataEF>>
                    {
                        Data = null,
                        IsExist = false,
                        ResponseMessage = "Unexpected error: " + ex.Message
                    };
                }
            }
        }



        /*



        internal const int withoutParentCategory = -1;
        //public ProductDataAPI() { }
        internal DataResponse<CategoryTypeEF> GetBaseCategory()
        {
            return GetCategoryByName("Base");
        }

        internal StandartResponse CreateBaseCategory()
        {
            var BaseCategoryResponse = GetBaseCategory();
            using (var db = new Context())
            {
                try
                {
                    if (BaseCategoryResponse.IsExist == true)
                        return new StandartResponse
                        {
                            Status = false,
                            ResponseMessage = "BaseCategory already exist"
                        };

                    var newBaseCategory = new CategoryTypeEF { CategoryName = "Base" };
                    db.CategoryTypes.Add(newBaseCategory);
                    db.SaveChanges();

                    return new StandartResponse
                    {
                        Status = true,
                        ResponseMessage = "BaseCategory created"
                    };
                }
                catch (Exception ex)
                {
                    return new StandartResponse
                    {
                        Status = false,
                        ResponseMessage = "Unexpected error: " + ex.Message
                    };
                }
            }
        }

        internal DataResponse<CategoryTypeEF> CreateCategory(string name, int parrentId = ProductAPI.withoutParentCategory)
        {
            var sameNameCategory = GetCategoryByName(name);
            if (sameNameCategory.IsExist == true)
                return new DataResponse<CategoryTypeEF>
                {
                    Data = sameNameCategory.Data,
                    IsExist = true,
                    ResponseMessage = $"Category with name: {name} already exist"
                };

            if (parrentId == ProductAPI.withoutParentCategory)
            {
                var baseCategoryResponse = GetBaseCategory();
                if (baseCategoryResponse.IsExist == true)
                    parrentId = baseCategoryResponse.Data.CategoryTypeId;
                else
                    return new DataResponse<CategoryTypeEF>
                    {
                        Data = null,
                        IsExist = false,
                        ResponseMessage = "Dont exist Base category"
                    };
            }
            else
            {
                var parrentResponse = GetCategoryById(parrentId);
                if (parrentResponse.IsExist == false)
                    return new DataResponse<CategoryTypeEF>
                    {
                        Data = null,
                        IsExist = false,
                        ResponseMessage = "Dont exist parrent category"
                    };

            }

            using (var db = new Context())
            {
                try
                {
                    var newCategory = new CategoryTypeEF { CategoryName = name, ParentCategoryId = parrentId };
                    db.CategoryTypes.Add(newCategory);
                    db.SaveChanges();

                    return new DataResponse<CategoryTypeEF>
                    {
                        Data = newCategory,
                        IsExist = true,
                        ResponseMessage = $"Category with name:{name} created"
                    };
                }
                catch (Exception ex)
                {
                    return new DataResponse<CategoryTypeEF>
                    {
                        Data = null,
                        IsExist = false,
                        ResponseMessage = "Unexpected error: " + ex.Message
                    };
                }
            }
        }

        internal DataResponse<CategoryTypeEF> GetCategoryByName(string name)
        {
            using (var db = new Context())
            {
                try
                {
                    var category = db.CategoryTypes.FirstOrDefault(p => p.CategoryName == name);

                    string resp = "";
                    if (category == null)
                    {
                        resp = $"There is no CategoryType with this name: {name}";
                    }

                    return new DataResponse<CategoryTypeEF>
                    {
                        Data = category,
                        IsExist = (category != null),
                        ResponseMessage = resp

                    };
                }
                catch (Exception ex)
                {
                    return new DataResponse<CategoryTypeEF>
                    {
                        Data = null,
                        IsExist = false,
                        ResponseMessage = "Unexpected error: " + ex.Message
                    };
                }
            }

        }

        internal DataResponse<CategoryTypeEF> GetCategoryById(int id)
        {
            using (var db = new Context())
            {
                try
                {
                    var category = db.CategoryTypes.FirstOrDefault(p => p.CategoryTypeId == id);

                    string resp = "";
                    if (category == null)
                    {
                        resp = $"There is no CategoryType with this id: {id}";
                    }

                    return new DataResponse<CategoryTypeEF>
                    {
                        Data = category,
                        IsExist = (category != null),
                        ResponseMessage = resp

                    };
                }
                catch (Exception ex)
                {
                    return new DataResponse<CategoryTypeEF>
                    {
                        Data = null,
                        IsExist = false,
                        ResponseMessage = "Unexpected error: " + ex.Message
                    };
                }
            }

        }



        internal DataResponse<List<ProductDataEff>> GetProductsByCategory(CategoryTypeEF category)
        {
            using (var dbContext = new Context())
            {
                try
                {
                    ProductDataEff a = new ProductDataEff();
                    var ProductsWithPrice = dbContext.Products
                    .Where(p => p.Category.CategoryName == category.CategoryName)
                    .ToList();

                    string resp = "";
                    if (ProductsWithPrice != null && !ProductsWithPrice.Any())
                    {
                        resp = $"There is no ProductData with category: {category.CategoryName}";
                    }

                    return new DataResponse<List<ProductDataEff>>
                    {
                        Data = ProductsWithPrice,
                        IsExist = (ProductsWithPrice != null && ProductsWithPrice.Any()),
                        ResponseMessage = resp
                    };
                }
                catch (Exception ex)
                {
                    return new DataResponse<List<ProductDataEff>>
                    {
                        Data = null,
                        IsExist = false,
                        ResponseMessage = "Unexpected error: " + ex.Message
                    };
                }
            }
        }

        internal DataResponse<List<ProductDataEff>> GetProductsByPrice(PriceRange priceRange)
        {
            using (var dbContext = new Context())
            {
                try
                {
                    var ProductsWithPrice = dbContext.Products
                        .Where(p => p.Price >= priceRange.Min && p.Price <= priceRange.Max)
                        .ToList();

                    string resp = "";
                    if (ProductsWithPrice != null && !ProductsWithPrice.Any())
                    {
                        resp = $"There is no ProductData with price from: {priceRange.Min} to {priceRange.Max}";
                    }

                    return new DataResponse<List<ProductDataEff>>
                    {
                        Data = ProductsWithPrice,
                        IsExist = (ProductsWithPrice != null && ProductsWithPrice.Any()),
                        ResponseMessage = resp
                    };
                }
                catch (Exception ex)
                {
                    return new DataResponse<List<ProductDataEff>>
                    {
                        Data = null,
                        IsExist = false,
                        ResponseMessage = "Unexpected error: " + ex.Message
                    };
                }
            }
        }

        internal DataResponse<List<ProductDataEff>> GetProductsByName(string subString)
        {
            using (var dbContext = new Context())
            {
                try
                {
                    var ProductsWithName = dbContext.Products
                        .Where(p => p.Name.Contains(subString))
                        .ToList();

                    string resp = "";
                    if (ProductsWithName != null && !ProductsWithName.Any())
                    {
                        resp = $"There is no ProductData with sub word: {subString}";
                    }

                    return new DataResponse<List<ProductDataEff>>
                    {
                        Data = ProductsWithName,
                        IsExist = (ProductsWithName != null && ProductsWithName.Any()),
                        ResponseMessage = resp
                    };
                }
                catch (Exception ex)
                {
                    return new DataResponse<List<ProductDataEff>>
                    {
                        Data = null,
                        IsExist = false,
                        ResponseMessage = "Unexpected error: " + ex.Message
                    };
                }
            }
        }

        internal DataResponse<ProductDataEff> GetSingleProductByName(string name)
        {
            using (var dbContext = new Context())
            {
                try
                {
                    var ProductsWithName = dbContext.Products.FirstOrDefault(p => p.Name == name);

                    string resp = "";
                    if (ProductsWithName == null)
                    {
                        resp = $"There is no ProductData with name: {name}";
                    }

                    return new DataResponse<ProductDataEff>
                    {
                        Data = ProductsWithName,
                        IsExist = (ProductsWithName != null),
                        ResponseMessage = resp
                    };
                }
                catch (Exception ex)
                {
                    return new DataResponse<ProductDataEff>
                    {
                        Data = null,
                        IsExist = false,
                        ResponseMessage = "Unexpected error: " + ex.Message
                    };
                }
            }
        }








        private string DetailsInvalidProductDataPesponse(ProductDataEff prod)
        {
            return
                (
                "\nprod.Name != null     : " + (prod.Name != null).ToString() +
                "\nprod.Category != null : " + (prod.Category != null).ToString() +
                "\nprod.Details != null  : " + (prod.Details != null).ToString() +
                "\nprod.ShortDescription != null : " + (prod.ShortDescription != null).ToString() +
                "\nprod.Price > 0        : " + (prod.Price > 0).ToString()
                //"\nprod.Amount >= 0      : " + (prod.Amount >= 0).ToString()
                );
        }*/
    }
}
