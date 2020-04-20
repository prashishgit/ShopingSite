using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSite.Database.Entity.Enum
{
    public enum RecordStatus
    {
        Inactive = 0,
        Active = 1,
        Unauthorized = 2,
    }
    public enum Status
    {
        Requested = 0,
        Recommended = 1,
        Approveed = 2,
        Rejected = 3,
        Received = 4,
        Checked = 5,
        Revied = 6

    }
}
