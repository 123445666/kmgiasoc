namespace kmgiasoc.Permissions
{
    public static class kmgiasocPermissions
    {
        public const string GroupName = "kmgiasoc";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class DealCategory
        {
            public const string Default = GroupName + ".DealCategory";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Deal
        {
            public const string Default = GroupName + ".Deal";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Country
        {
            public const string Default = GroupName + ".Country";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class City
        {
            public const string Default = GroupName + ".City";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
