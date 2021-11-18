using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace kmgiasoc.Deals
{
    public static class DealConsts
    {
        public static int MaxTitleLength { get; set; } = 1024;

        public static int MaxSlugLength { get; set; } = 1024;

        public static int MinSlugLength { get; set; } = 2;

        public static int MaxShortDescriptionLength { get; set; } = 120;

        public static int MaxContentLength { get; set; } = int.MaxValue;

        public const string EntityType = "Deal";
        public enum Status
        {
            [Description("Mới tạo")]
            Draft = -100,
            [Description("Không duyệt")]
            Discontinued = -2,
            [Description("Đã xóa")]
            Deleted = -1,
            [Description("Đã duyệt")]
            Approved = 1,
            [Description("Đã đăng")]
            Published = 5
        }
    }
}
