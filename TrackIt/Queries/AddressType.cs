using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackIt.Models;

namespace TrackIt.Queries
{
    public class AddressType : ObjectGraphType<Address>
    {
        public AddressType()
        {
            Field(x => x.Id).Description("Id of Address");
            Field(x => x.AddressLine1).Description("Address Line 1 of the Address");
            Field(x => x.AddressLine2).Description("Address Line 2 of the Address");
            Field(x => x.City).Description("City of the Address");
            Field(x => x.State).Description("State of the Address");
            Field(x => x.PostalCode).Description("Postal Code of the Address");
            Field(x => x.Country).Description("Country of the Address");
        }
    }
}
