using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinSite.Database.Enum
{
    public enum RecordStatus
    {
        Inactive = 0,
        Active = 1,
        UnAuthozied = 2,
    }
    public enum Status
    {
        Requested = 0,
        Recommended = 1,
        Approved = 2,
        Rejected = 3,
        Received = 4,
        Checked = 5,
        Revied = 6
    }
}
