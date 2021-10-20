using System.Collections.Generic;
using P0Models;

namespace P0BL
{
    public interface IProductsBL
    {
        //List products
        List<Products> GetAllProducts();

        //Allows Product search by name - Do I need to?
        // List<Products> GetProducts(string p_pname);
    }
}