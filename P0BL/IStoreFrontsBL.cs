using System.Collections.Generic;
using P0Models;

namespace P0BL
{
    public interface IStoreFrontsBL
    {
        //List store fronts
        List<StoreFronts> GetAllStoreFronts();

        //Allows store fronts search by name
        List<StoreFronts> GetStoreFronts(string p_sname);
        //Adds a store
        StoreFronts AddStore(StoreFronts p_store);

        //list the orders from stores
        List<Orders> GetAllStoreOrders(StoreFronts p_store);
        /// <summary>
        /// Returns a specific store based on ID
        /// </summary>
        /// <param name="p_Id">ID that it will check</param>
        /// <returns>Returns store</returns>
        StoreFronts GetStoresById(int p_Id);
    }
}