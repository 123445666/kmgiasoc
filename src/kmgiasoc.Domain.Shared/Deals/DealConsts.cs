using System;
using System.Collections.Generic;
using System.Text;

namespace kmgiasoc.Deals
{
    public static class DealConsts
    {
        public static int MaxTitleLength { get; set; } = 64;

        public static int MaxSlugLength { get; set; } = 256;

        public static int MinSlugLength { get; set; } = 2;

        public static int MaxShortDescriptionLength { get; set; } = 256;

        public static int MaxContentLength { get; set; } = int.MaxValue;

        public const string EntityType = "Deal";
    }
}
