using System.Collections.Generic;
using P0Models;

namespace P0BL
{
    public interface IProductsBL
    {
        //List Products
        List<Products> GetAllProducts();

        //Allows product search by name
        List<Products> GetProducts(string p_prod);
    }
}