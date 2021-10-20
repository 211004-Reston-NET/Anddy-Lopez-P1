using System.Collections.Generic;
using P0DL;
using P0Models;

namespace P0BL
{
    public class ProductsBL : IProductsBL
    {
        private IRepository _repo;
        public ProductsBL(IRepository p_repo) 
        {
            _repo = p_repo;
        }
        
        public List<Products> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        //Update if you want to search product by name
        // public List<Products> GetProducts(string p_pname)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}