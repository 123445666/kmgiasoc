using System;
using System.Collections.Generic;
using System.Text;

namespace kmgiasoc.Utilities
{
    public static class UrlFilter
    {
        public static string BuildCreateDealUrl()
        {
            return "/deal/create";
        }
        public static string BuildCategoryDealUrl(string slug)
        {
            return "/cat/" + slug + "/";
        }
        public static string BuildDealUrl(string slug)
        {
            return "/deal/" + slug + "/";
        }

        public static string BuildImageUrl(Guid? CoverImageMediaId)
        {
            if (CoverImageMediaId == null) return "#";
            return "/api/media/" + CoverImageMediaId;
        }
    }
}
