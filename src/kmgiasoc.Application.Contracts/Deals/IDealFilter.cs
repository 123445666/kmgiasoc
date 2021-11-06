using System;
using System.Collections.Generic;
using System.Text;

namespace kmgiasoc.Deals
{
    class IDealFilter
    {
    }
    public interface IIsActive
    {
        bool IsActive { get; }
    }
    public interface IIsPublished
    {
        bool IsPublished { get; }
    }
    public interface IIsApproved
    {
        bool IsApproved { get;  }
    }
}
