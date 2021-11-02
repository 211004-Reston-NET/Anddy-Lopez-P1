using System.Collections.Generic;
using P0Models;

namespace P0BL
{
    public interface ILineItemBL
    {
        //List Line Items
        List<LineItems> GetAllLineItems(LineItems p_item);

        //Allows item search -- not implemented in Irepo
        List<LineItems> GetLineItems(string p_item);

        //Allows LineItem modification
        void UpdateLineItem(int p_itemID, int p_quan);

        //returns items based on ID
        LineItems GetItemsByID(int p_itemId);
    }
}