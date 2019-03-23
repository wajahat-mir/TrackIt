using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackIt.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string DBConnectionString { get; set; }
        public string DatabaseDB { get; set; }
        public string CollectionInventory { get; set; }
        public string endpoint { get; set; }
        public string authKey { get; set; }
    }
}
