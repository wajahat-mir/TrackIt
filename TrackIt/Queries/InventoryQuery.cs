using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackIt.Services;

namespace TrackIt.Queries
{
    public class InventoryQuery : ObjectGraphType
    {
        public InventoryQuery(InventoryService inventoryService, BrandService brandservice)
        {
            Field<InventoryType>(
                name: "inventory",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return inventoryService.GetInventoryById(id);
                }
            );
            Field<BrandType>(
                name: "brand",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");

                    return brandservice.GetBrandById(id);

                }
            );

        }
    }
}
