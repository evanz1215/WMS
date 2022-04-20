using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PurchaseOrders
{
    public enum PurchaseOrderStatusType
    {
        [Description("新建單")]
        New = 1,

        [Description("待審核")]
        Submit = 2,

        [Description("退回")]
        Return = 3,

        [Description("已審核")]
        Approved = 4

    }
}
