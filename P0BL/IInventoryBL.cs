using System.Collections.Generic;
using P0Models;

namespace P0BL
{
    public interface IInventoryBL
    {
        //List the invetory
        List<LineItems> GetAllLineItems();

        //Allows inventory search -- might not need
        List<LineItems> GetLineItems(string p_item);
    }
}