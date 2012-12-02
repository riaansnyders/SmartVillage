using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Net;
using Indus.Services.Client;
using Indus.Services.Core.Logging;
using Indus.ASN_1.Services.BER;
using System.Collections;
using  Indus.IEC61850.LogicalModel.ACSI;
namespace Indus.Services.Server
{
    public delegate void Connected();
    public delegate void DataReceived();

    public class HostServer
    {

        private Socket _client = null;
        private Socket _server = null;
        const int _portToListen = 102;
        byte[] buffer = new byte[256];
        private ArrayList m_aryClients = new ArrayList();
        private Logger _logger;
        public Connected ServerConnected;
        public DataReceived ServerDataReceived;
        private IEC61850.LogicalModel.ACSI.IECServer _iecserver ;
        public HostServer(IECServer iecserver)
        {
            _logger = new Logger();
            _iecserver = iecserver;
        }

        /// <summary>
        /// Callback used when a client requests a connection. 
        /// Accpet the connection, adding it to our list and setup to 
        /// accept more connections.
        /// </summary>
        /// <param name="ar"></param>
        public void OnConnectRequest(IAsyncResult ar)
        {
            Socket listener = (Socket)ar.AsyncState;
            NewConnection(listener.EndAccept(ar));
            ServerConnected();
            listener.BeginAccept(new AsyncCallback(OnConnectRequest), listener);
        }

        /// <summary>
        /// Add the given connection to our list of clients
        /// Note we have a new friend
        /// Send a welcome to the new client
        /// Setup a callback to recieve data
        /// </summary>
        /// <param name="sockClient">Connection to keep</param>
        //public void NewConnection( TcpListener listener )
        public void NewConnection(Socket sockClient)
        {
            // Program blocks on Accept() until a client connects.
            //SocketChatClient client = new SocketChatClient( listener.AcceptSocket() );
            SocketChatClient client = new SocketChatClient(sockClient);
            m_aryClients.Add(client);
            Console.WriteLine("Client " + client.Sock.RemoteEndPoint.ToString() + " joined" );
            _logger.WriteLog("Client " + client.Sock.RemoteEndPoint.ToString() + " joined");
            // Get current date and time.
            DateTime now = DateTime.Now;
            String strDateLine = "Welcome " + now.ToString("G") + "\n\r";
            _logger.WriteLog("Sending Welcome Message... " );
            // Convert to byte array and send.
            Byte[] byteDateLine = System.Text.Encoding.ASCII.GetBytes(strDateLine.ToCharArray());
            client.Sock.Send(byteDateLine, byteDateLine.Length, 0);

            client.SetupRecieveCallback(this);
        }

        //public void OnConnectRequest(IAsyncResult ar)
        //{
            
        //    Socket listener = (Socket)ar.AsyncState;
        //    _client = listener.EndAccept(ar);
        //    ConnectionClient client = new ConnectionClient(_client);
        //    Debug.Print("Client {0} joined", _client.RemoteEndPoint);
        //    string strDateTime="Welcome " + DateTime.Now.ToString("G");
        //    byte[] bytes = System.Text.Encoding.ASCII.GetBytes(strDateTime.ToCharArray());
        //    _client.Send(bytes,bytes.Length,0);
        //    //client.SetupReceiveCallBack(_server  );
        //    listener.BeginAccept(new AsyncCallback(OnConnectRequest), listener);
            
        //    //if (_client.Connected)
        //    //{
        //    //    SetupReceiveCallBack(listener);
        //    //}
        //}

        public string CurrentLog
        {
            get
            {
                return _logger.CurrentLogInfo;
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

        public void Start()
        {
            IPAddress[] aryLocalAddr = null;
            string strHostName = string.Empty;
            try
            {
                strHostName = Dns.GetHostName();
                IPHostEntry entry = Dns.GetHostByName(strHostName);
                aryLocalAddr = entry.AddressList;
                if (aryLocalAddr == null || aryLocalAddr.Length < 1)
                {
                    throw new Exception("Cannot obtain the local address");
                }
                _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _server.Bind(new IPEndPoint(aryLocalAddr[0],_portToListen));
                _server.Listen(10);
                Debug.Print("Listening on: "+ _server.LocalEndPoint );
                _logger.WriteLog("----------------------------------------------------------------------------");
                _logger.WriteLog("Server Started...");
                _logger.WriteLog("Listening on: " + _server.LocalEndPoint);
                _logger.WriteLog("----------------------------------------------------------------------------");
                _server.BeginAccept(new AsyncCallback(OnConnectRequest), _server );
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void OnReecieveData(IAsyncResult ar)
        {
            //Socket sock = (Socket)ar.AsyncState;
            SocketChatClient client = (SocketChatClient)ar.AsyncState;
            Socket sock = client.Sock;
            byte[] aryRet = client.GetRecievedData(ar);
            Indus.ASN_1.Services.BER.Decoder decoder= new Indus.ASN_1.Services.BER.Decoder(aryRet );
            string decoded=decoder.Decode();
            _logger.WriteLog( decoded );
            
            // If no data was recieved then the connection is probably dead
            if (aryRet.Length < 1)
            {
                Console.WriteLine("Client " + client.Sock.RemoteEndPoint.ToString() + " disconnected");
                client.Sock.Close();
                m_aryClients.Remove(client);
                return;
            }
            //_logger.WriteLog("Data Received at Server --Sending to all clients--You can use a session ID to send to one specific client");
            
            //Send only to the one who send data
            foreach (SocketChatClient clientSend in m_aryClients)
            {
                if (client.Sock.RemoteEndPoint == clientSend.Sock.RemoteEndPoint)
                {

                try
                {
                    //Command Handling demponstrated here 
                    if (decoded.Contains("GetServerDirectory_Request"))
                    {
                        string[] lD = _iecserver.GetServerDirectory(Indus.ACSI.Core.ObjectClassEnum.LogicalDevice);
                        Indus.ASN_1.Services.BER.Encoder encode= new Indus.ASN_1.Services.BER.Encoder(lD[0] );
                        clientSend.Sock.Send(encode.Encode());
                    }
                    else
                    {
                    Indus.ASN_1.Services.BER.Encoder encode= new Indus.ASN_1.Services.BER.Encoder("Response");
                    clientSend.Sock.Send(encode.Encode());
                    }
                }
                catch
                {
                    // If the send fails the close the connection
                    Console.WriteLine("Send to client {0} failed", client.Sock.RemoteEndPoint);
                    clientSend.Sock.Close();
                    m_aryClients.Remove(client);
                    return;
                }
                }
            }


            // Broadcast:Send the recieved data to all clients (including sender for echo)


            //foreach (SocketChatClient clientSend in m_aryClients)
            //{
            //    try
            //    {
            //        if clientSend.Sock.Send(aryRet);
            //    }
            //    catch
            //    {
            //        // If the send fails the close the connection
            //        Console.WriteLine("Send to client {0} failed", client.Sock.RemoteEndPoint);
            //        clientSend.Sock.Close();
            //        m_aryClients.Remove(client);
            //        return;
            //    }
            //}
            ServerDataReceived();
            client.SetupRecieveCallback(this);
        }

    }

    /// <summary>
    /// Class holding information and buffers for the Client socket connection
    /// </summary>
    internal class SocketChatClient
    {
        private Socket m_sock;						// Connection to the client
        private byte[] m_byBuff = new byte[50];		// Receive data buffer
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sock">client socket conneciton this object represents</param>
        public SocketChatClient(Socket sock)
        {
            m_sock = sock;
        }

        // Readonly access
        public Socket Sock
        {
            get { return m_sock; }
        }

        /// <summary>
        /// Setup the callback for recieved data and loss of conneciton
        /// </summary>
        /// <param name="app"></param>
        public void SetupRecieveCallback(HostServer  app)
        {
            try
            {
                AsyncCallback recieveData = new AsyncCallback(app.OnReecieveData);
                m_sock.BeginReceive(m_byBuff, 0, m_byBuff.Length, SocketFlags.None, recieveData, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Recieve callback setup failed! {0}", ex.Message);
            }
        }

        /// <summary>
        /// Data has been recieved so we shall put it in an array and
        /// return it.
        /// </summary>
        /// <param name="ar"></param>
        /// <returns>Array of bytes containing the received data</returns>
        public byte[] GetRecievedData(IAsyncResult ar)
        {
            int nBytesRec = 0;
            try
            {
                nBytesRec = m_sock.EndReceive(ar);
            }
            catch { }
            byte[] byReturn = new byte[nBytesRec];
            Array.Copy(m_byBuff, byReturn, nBytesRec);

            /*
            // Check for any remaining data and display it
            // This will improve performance for large packets 
            // but adds nothing to readability and is not essential
            int nToBeRead = m_sock.Available;
            if( nToBeRead > 0 )
            {
                byte [] byData = new byte[nToBeRead];
                m_sock.Receive( byData );
                // Append byData to byReturn here
            }
            */
            return byReturn;
        }
    }

}
