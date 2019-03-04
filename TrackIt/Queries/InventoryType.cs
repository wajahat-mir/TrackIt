using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackIt.Models;

namespace TrackIt.Queries
{
    public class InventoryType : ObjectGraphType<InventoryItem>
    {
        public InventoryType()
        {
            Field(x => x.Id).Description("Id of an Inventory Item");
            Field(x => x.ItemName).Description("Name of an Inventory Item");
            Field(x => x.Cost).Description("Cost of the Inventory Item");
            Field(x => x.Quantity).Description("Number of units available");
        }
    }
}
