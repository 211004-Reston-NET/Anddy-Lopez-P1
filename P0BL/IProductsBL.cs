using System.Collections.Generic;
using P0Models;

namespace P0BL
{
    public interface IProductsBL
    {
        List<Products> GetAllProducts();

        List<Products> GetProducts(string p_prod);
    }
}