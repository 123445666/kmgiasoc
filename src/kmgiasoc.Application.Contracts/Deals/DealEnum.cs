using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace kmgiasoc.Deals
{
    public static class DealEnum
    {
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
