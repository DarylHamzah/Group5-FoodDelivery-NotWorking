using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Client.Static
{
    public static class EndPoints
    {
        private static readonly string Prefix = "api";

        public static readonly string RiderEndPoint = $"{Prefix }/riders";

        public static readonly string CustomersEndPoint = $"{Prefix }/customers";

        public static readonly string OrdersEndPoint = $"{Prefix}/order";

        public static readonly string MenuItemsEndPoint = $"{Prefix }/menus";

        public static readonly string PaymentEndPoint = $"{Prefix }/payments";
    }
}
