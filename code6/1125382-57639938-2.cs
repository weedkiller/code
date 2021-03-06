    internal static class NativeMethods
    {
        [DllImport("iphlpapi", CharSet = CharSet.Auto)]
        public extern static int GetIpForwardTable(IntPtr /*PMIB_IPFORWARDTABLE*/ pIpForwardTable, ref int /*PULONG*/ pdwSize, bool bOrder);
        [DllImport("iphlpapi", CharSet = CharSet.Auto)]
        //public extern static int CreateIpForwardEntry(ref /*PMIB_IPFORWARDROW*/ Ip4RouteTable.PMIB_IPFORWARDROW pRoute);  Can do by reference or by Pointer
        public extern static int CreateIpForwardEntry(IntPtr /*PMIB_IPFORWARDROW*/ pRoute);
        [DllImport("iphlpapi", CharSet = CharSet.Auto)]
        public extern static int DeleteIpForwardEntry(IntPtr /*PMIB_IPFORWARDROW*/ pRoute);
    }
    public class Ip4RouteTable
    {
        [ComVisible(false), StructLayout(LayoutKind.Sequential)]
        internal struct IPForwardTable
        {
            public uint Size;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public PMIB_IPFORWARDROW[] Table;
        };
        [ComVisible(false), StructLayout(LayoutKind.Sequential)]
        internal struct PMIB_IPFORWARDROW
        {
            internal uint /*DWORD*/ dwForwardDest;
            internal uint /*DWORD*/ dwForwardMask;
            internal uint /*DWORD*/ dwForwardPolicy;
            internal uint /*DWORD*/ dwForwardNextHop;
            internal uint /*DWORD*/ dwForwardIfIndex;
            internal uint /*DWORD*/ dwForwardType;
            internal uint /*DWORD*/ dwForwardProto;
            internal uint /*DWORD*/ dwForwardAge;
            internal uint /*DWORD*/ dwForwardNextHopAS;
            internal uint /*DWORD*/ dwForwardMetric1;
            internal uint /*DWORD*/ dwForwardMetric2;
            internal uint /*DWORD*/ dwForwardMetric3;
            internal uint /*DWORD*/ dwForwardMetric4;
            internal uint /*DWORD*/ dwForwardMetric5;
        };
        static IPForwardTable ReadIPForwardTable(IntPtr tablePtr)
        {
            var result = (IPForwardTable)Marshal.PtrToStructure(tablePtr, typeof(IPForwardTable));
            PMIB_IPFORWARDROW[] table = new PMIB_IPFORWARDROW[result.Size];
            IntPtr p = new IntPtr(tablePtr.ToInt64() + Marshal.SizeOf(result.Size));
            for (int i = 0; i < result.Size; ++i)
            {
                table[i] = (PMIB_IPFORWARDROW)Marshal.PtrToStructure(p, typeof(PMIB_IPFORWARDROW));
                p = new IntPtr(p.ToInt64() + Marshal.SizeOf(typeof(PMIB_IPFORWARDROW)));
            }
            result.Table = table;
            return result;
        }
        public static void RoutePrint(bool testing)
        {
            var fwdTable = IntPtr.Zero;
            int size = 0;
            var result = NativeMethods.GetIpForwardTable(fwdTable, ref size, true);
            fwdTable = Marshal.AllocHGlobal(size);
            result = NativeMethods.GetIpForwardTable(fwdTable, ref size, true);
            var forwardTable = ReadIPForwardTable(fwdTable);
            Marshal.FreeHGlobal(fwdTable);
            Console.Write("\tNumber of entries: {0}\n", forwardTable.Size);
            for (int i = 0; i < forwardTable.Table.Length; ++i)
            {
                Console.Write("\n\tRoute[{0}] Dest IP: {1}\n", i, new IPAddress((long)forwardTable.Table[i].dwForwardDest).ToString());
                Console.Write("\tRoute[{0}] Subnet Mask: {1}\n", i, new IPAddress((long)forwardTable.Table[i].dwForwardMask).ToString());
                Console.Write("\tRoute[{0}] Next Hop: {1}\n", i, new IPAddress((long)forwardTable.Table[i].dwForwardNextHop).ToString());
                Console.Write("\tRoute[{0}] If Index: {1}\n", i, forwardTable.Table[i].dwForwardIfIndex);
                Console.Write("\tRoute[{0}] Type: {1}\n", i, forwardTable.Table[i].dwForwardType);
                Console.Write("\tRoute[{0}] Proto: {1}\n", i, forwardTable.Table[i].dwForwardProto);
                Console.Write("\tRoute[{0}] Age: {1}\n", i, forwardTable.Table[i].dwForwardAge);
                Console.Write("\tRoute[{0}] Metric1: {1}\n", i, forwardTable.Table[i].dwForwardMetric1);
            }
        }
        public static void RoutePrint()
        {
            List<Ip4RouteEntry> routeTable = GetRouteTable();
            RoutePrint(routeTable);
        }
        public static void RoutePrint(List<Ip4RouteEntry> routeTable)
        {
            Console.WriteLine("Route Count: {0}", routeTable.Count);
            Console.WriteLine("{0,18} {1,18} {2,18} {3,5} {4,8} ", "DestinationIP", "NetMask", "Gateway", "IF", "Metric");
            foreach (Ip4RouteEntry entry in routeTable)
            {
                Console.WriteLine("{0,18} {1,18} {2,18} {3,5} {4,8} ", entry.DestinationIP, entry.SubnetMask, entry.GatewayIP, entry.InterfaceIndex, entry.Metric);
            }
        }
        public static List<Ip4RouteEntry> GetRouteTable()
        {
            var fwdTable = IntPtr.Zero;
            int size = 0;
            var result = NativeMethods.GetIpForwardTable(fwdTable, ref size, true);
            fwdTable = Marshal.AllocHGlobal(size);
            result = NativeMethods.GetIpForwardTable(fwdTable, ref size, true);
            var forwardTable = ReadIPForwardTable(fwdTable);
            Marshal.FreeHGlobal(fwdTable);
            List<Ip4RouteEntry> routeTable = new List<Ip4RouteEntry>();
            for (int i = 0; i < forwardTable.Table.Length; ++i)
            {
                Ip4RouteEntry entry = new Ip4RouteEntry();
                entry.DestinationIP = new IPAddress((long)forwardTable.Table[i].dwForwardDest);
                entry.SubnetMask = new IPAddress((long)forwardTable.Table[i].dwForwardMask);
                entry.GatewayIP = new IPAddress((long)forwardTable.Table[i].dwForwardNextHop);
                entry.InterfaceIndex = Convert.ToInt32(forwardTable.Table[i].dwForwardIfIndex);
                entry.ForwardType = Convert.ToInt32(forwardTable.Table[i].dwForwardType);
                entry.ForwardProtocol = Convert.ToInt32(forwardTable.Table[i].dwForwardProto);
                entry.ForwardAge = Convert.ToInt32(forwardTable.Table[i].dwForwardAge);
                entry.Metric = Convert.ToInt32(forwardTable.Table[i].dwForwardMetric1);
                routeTable.Add(entry);
            }
            return routeTable;
        }
