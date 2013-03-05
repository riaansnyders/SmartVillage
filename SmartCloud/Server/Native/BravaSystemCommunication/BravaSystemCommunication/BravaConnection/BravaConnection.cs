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

        public NetworkStream rqStream = null;

    }
}
