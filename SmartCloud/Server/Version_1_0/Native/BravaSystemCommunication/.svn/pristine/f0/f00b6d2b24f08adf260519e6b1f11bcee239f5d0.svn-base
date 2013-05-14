using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace BravaSystem.Communication
{
    /// <summary>
    /// This class encapsulates the information needed to connect to a BRAVA system
    /// </summary>
    public class BravaConnection
    {
        public bool Connected;

        public bool SystemValid;

        public string BravaType;

        public System.Net.IPAddress BravaIP;

        public int BravaPort;

        // a Stream Object that represents the TCP Socket and Port bound to a TCP Client upon which the traffic will travel.
        // It is Not to be confused with the other streams from the Transaction class which represent the data itself.
        public NetworkStream rqStream = null;

    }
}
