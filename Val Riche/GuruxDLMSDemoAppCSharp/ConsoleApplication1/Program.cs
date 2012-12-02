using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Gurux.Net.GXNet conn = new Gurux.Net.GXNet();
            conn.HostName = "192.168.0.1";
            conn.Port = 5000;
            conn.Protocol = Gurux.Net.NetworkType.Tcp;

        
        }
    }
}
