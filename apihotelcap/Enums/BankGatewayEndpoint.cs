using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Enums
{
    public enum BankGatewayEndpoint
    {
        [Description("/api/Operation/MakeTransfer")]
        Transfer
    }
}
