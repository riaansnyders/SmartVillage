using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Diagnostics;
using Indus.Services.Core.Logging;
namespace Indus.Services.Client
{
    public delegate void Connected();
    public delegate void DataReceived();
    public class ConnectionClient
    {
        private Socket _client = null;
        private byte[] buffer = new byte[256];
        private IPEndPoint _epServer;
        private Logger _logger;
        public Connected ClientConnected;
        public DataReceived ClientDataReceived;
        public ConnectionClient()
        {
            _logger = new Logger();
        }
        public ConnectionClient(Socket sock)
        {
            _client = sock;
            _logger = new Logger();
        }

        public string CurrentLog
        {
            get
            {
                return _logger.CurrentLogInfo;
            }
        }

        public Socket Sock
        {
            get
            {
                return _client;
            }
        }
        public void Connect(string ipAddress,int Port)
        {
            if (_client != null && _client.Connected)
            {
                _client.Shutdown(SocketShutdown.Both);
                Thread.Sleep(10);
                _client.Close();
            }
            string strHostName = Dns.GetHostName();
            IPHostEntry entry = Dns.GetHostByName("192.168.0.1");
            IPAddress[]  aryLocalAddr = entry.AddressList;
            if (aryLocalAddr == null || aryLocalAddr.Length < 1)
            {
                throw new Exception("Cannot obtain the local address");
            }
                
            _client = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            _epServer = new IPEndPoint(aryLocalAddr[0], 5000);
            _client.Blocking = false;
            AsyncCallback onconnect = new AsyncCallback(OnConnect);
            _client.BeginConnect(_epServer, onconnect, _client);
        }
        public void OnConnect(IAsyncResult ar)
        {
            Socket sock = (Socket)ar.AsyncState;
            try
            {
                if (sock.Connected)
                {
                    ClientConnected();
                    SetupReceiveCallBack(sock);
                }
                else
                {
                    Debug.Print("Cannot connect to server");
                    _logger.WriteLog("Cannot connect to server");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetupReceiveCallBack(Socket sock)
        {
            try
            {
                AsyncCallback receiveData = new AsyncCallback(OnReecieveData);
                sock.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, receiveData, sock);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SendData(string text)
        {
            
           
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(text.ToCharArray());
            _client.Send(bytes, bytes.Length, SocketFlags.None);
            //_client.SendTo(bytes, SocketFlags.None, _client.RemoteEndPoint);
            _logger.WriteLog("Sending:" + text );

        }
        public void SendData(byte[] bytes)
        {
            _client.Send(bytes, bytes.Length, SocketFlags.None);
            _logger.WriteLog("Sending: as bytes" + bytes.Length.ToString());
        }
        public void OnReecieveData(IAsyncResult ar)
        {
            Socket sock = (Socket)ar.AsyncState;
            try
            {
                int bytesRec = sock.EndReceive(ar);
                if (bytesRec > 0)
                {
                    string strRec = Encoding.ASCII.GetString(buffer, 0, bytesRec);
                    Debug.Print("Received:" + strRec);
                    _logger.WriteLog("Received:" + strRec);
                    ClientDataReceived ();
                    SetupReceiveCallBack(sock);
                }
                else
                {
                    sock.Shutdown(SocketShutdown.Both);
                    sock.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
