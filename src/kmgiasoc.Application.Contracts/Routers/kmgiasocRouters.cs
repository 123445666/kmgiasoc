using System;
using System.Collections.Generic;
using System.Text;

namespace kmgiasoc.Routers
{
    public static class kmgiasocRouters
    {
        public class DealCategory
        {
            public const string Default = "/dealcategory";
            public const string Update = Default + "/Update";
            public const string Create = Default + "/Create";
            public const string Delete = Default + "/Delete";
        }

        public class Deal
        {
            public const string Default = "/deal";
            public const string Update = Default + "/update";
            public const string Create = Default + "/create";
            public const string Delete = Default + "/delete";
        }
    }
}
