using System.Collections.Generic;
using System.Linq;
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

        public List<Products> GetProducts(string p_prod)
        {
            List<Products> listOfProds = _repo.GetAllProducts();

            return listOfProds.Where(prod => prod.PName.Contains(p_prod)).ToList();
        }
    }
}