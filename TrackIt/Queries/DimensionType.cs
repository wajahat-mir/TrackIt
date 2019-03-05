using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackIt.Models;

namespace TrackIt.Queries
{
    public class DimensionType: ObjectGraphType<Dimension>
    {
        public DimensionType()
        {
            Field(x => x.Id).Description("Id of an Dimension");
            Field(x => x.length).Description("Length of an Dimension");
            Field(x => x.width).Description("Width of an Dimension");
            Field(x => x.depth).Description("Depth of an Dimension");
            Field(x => x.units).Description("Units of length, width, depth fields");
        }
    }
}
