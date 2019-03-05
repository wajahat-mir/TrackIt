using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackIt.Models;

namespace TrackIt.Queries
{
    public class BrandType : ObjectGraphType<Brand>
    {
        public BrandType()
        {
            Field(x => x.Id).Description("Id of a Brand");
            Field(x => x.Name).Description("Name of the Brand");
            Field(x => x.ContactPhone).Description("Contact Phone of the Brand");
            Field<AddressType>("companyaddress");
        }
    }
}
