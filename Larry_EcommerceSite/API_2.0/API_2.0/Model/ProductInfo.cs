using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;


[Serializable]
public class ProductInfo
{
    public ProductInfo(Product product)
    {
        ProductId = product.Id;
        ProductName = product.Name;
        ProductPhoto = product.Photo;
        ProductPrice = product.Price;
        ProductUPC = product.UPC_Code;
        ProductTypeId = product.ProductTypeId.Value;

        
    }

    public int ProductId { get; }
    public string ProductPhoto { get; }
    public string ProductName { get; }
    public decimal? ProductPrice { get; }
    public int? ProductUPC { get; }
    public int ProductTypeId { get; }
    public string ProductType { get; }
    

}




