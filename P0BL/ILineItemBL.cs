using System.Collections.Generic;
using P0Models;

namespace P0BL
{
    public interface ILineItemBL
    {
        List<LineItems> GetAllLineItems();

        List<LineItems> GetLineItems(string p_item);
    }
}