using System.Collections.Generic;
using P0Models;

namespace P0BL
{
    public interface ILineItemBL
    {
        //List Line Items
        List<LineItems> GetAllLineItems();

        //Allows item search
        List<LineItems> GetLineItems(string p_item);

        //Allows LineItem addition
        LineItems AddLineItem(LineItems p_item);
    }
}