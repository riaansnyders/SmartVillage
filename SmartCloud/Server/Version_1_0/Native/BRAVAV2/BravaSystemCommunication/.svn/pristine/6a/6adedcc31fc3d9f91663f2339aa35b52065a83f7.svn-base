using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Sockets;

namespace BravaSystem.Communication
{
    /// <summary>
    /// Sockets Transceiver for Communications in BRAVA systems. 
    /// </summary>
    public class BravaSocket
    {
        #region private members
        private TcpClient reqClient;
        #endregion

        #region ctors
        public BravaSocket(BravaTransaction inTransaction, BravaConnection inConnection)
        {
            this.Connection = inConnection;
            this.Transaction = inTransaction;
        }
        #endregion

        #region public members
        public BravaTransaction Transaction;
        public BravaConnection Connection;
        #endregion

        #region Properties
        public TcpClient SocketClient
        {
            get { return reqClient; }
            set { reqClient = value; }
        }
        #endregion

        #region Private Methods
        #region TCP Frames to/fro
        /// <summary>
        ///  Send a "frame of data" (in a stream) to the specified Network stream.
        /// </summary>
        /// <param name="outData"></param>
        /// <param name="nStream"></param>
        private void SendFrame(Stream outData, NetworkStream nStream)
        {
            int numberOfBytes = 0;
            int total = 0;
            Byte[] bytes = new Byte[256];

            try
            {
                outData.Seek(0, SeekOrigin.Begin);

                numberOfBytes = outData.Read(bytes, 0, bytes.Length);

                do
                {
                    nStream.Write(bytes, 0, numberOfBytes);
                    total += numberOfBytes;
                    numberOfBytes = outData.Read(bytes, 0, bytes.Length);
                } while (numberOfBytes > 0);

                System.Diagnostics.Debug.WriteLine("Sent data! " + total.ToString() + "bytes\r\n");
            }
            catch (SocketException e)
            {
                System.Diagnostics.Debug.WriteLine("Exception BravaSockets:SendFrame: " + e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Gets a frame from the specified metwork stream 
        /// </summary>
        /// <param name="nStream"></param>
        /// <returns></returns>
        private Stream GetFrame(NetworkStream nStream)
        {
            Byte[] bytes = new Byte[256];

            int numberOfBytesRead = 0;
            int total = 0;
            MemoryStream data = new MemoryStream();
            try
            {
                // Loop to receive all the data sent by the client.
                do
                {
                    numberOfBytesRead = nStream.Read(bytes, 0, bytes.Length);
                    data.Write(bytes, 0, numberOfBytesRead);
                    total += numberOfBytesRead;
                }
                while (nStream.DataAvailable);

                System.Diagnostics.Debug.WriteLine("Received data!" + total.ToString() + "bytes\r\n");
            }
            catch (SocketException e)
            {
                System.Diagnostics.Debug.WriteLine("Exception TCPSockets:GetFrame: " + e.Message);
                throw e;
            }
            return data;
        }
        #endregion

        // private methods
        /// <summary>
        /// (Client Side) Issue a request to the defined Connection Endpoint.
        /// </summary>
        private void SendRequest()
        {
            SendFrame(Transaction.RequestStream, Connection.rqStream);
        }

        /// <summary>
        /// (Client Side) Get a response to a request 
        /// </summary>
        /// <returns></returns>
        private Stream GetResponse()
        {
            Stream outputStr = GetFrame(Connection.rqStream);

            return outputStr;
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Establish the network connection and link the network streams to Transaction object.
        /// </summary>
        public void OpenConnection()
        {
            this.Connection.Connected = false;
            try
            {

                reqClient = new TcpClient();
                //reqClient.ExclusiveAddressUse = false;
                reqClient.NoDelay = true;
                reqClient.ReceiveTimeout = 500;   // 10000
                reqClient.SendTimeout = 500;      // 10000
                LingerOption lingerOption = new LingerOption(false, 0);
                // LingerOption lingerOption = new LingerOption(true, 1);
                reqClient.LingerState = lingerOption;
                reqClient.Connect(Connection.BravaIP, Connection.BravaPort);
                // bind the socket and get the stream object representing it.
                Connection.rqStream = reqClient.GetStream();
            }
            catch (SocketException se)
            {
                throw (se);
            }
        }

        // Perform the Transaction on the Connection specified.
        public void DoTransaction()
        {
                if (this.reqClient == null || this.reqClient.Connected == false)
                {
                    OpenConnection();
                }

                // The OpenConnection method may not have opened the socket connection properly.
                if (this.reqClient.Connected == true)
                {
                    SendRequest();

                    this.Transaction.State = BravaTransaction.TransactionState.Pending;

                    // TODO: A better timeout / wait for response methodology here.
                    System.Threading.Thread.Sleep(250);
                    //System.Threading.Thread.Sleep(500);

                    // Did the request get a response?
                    if (Connection.rqStream.DataAvailable)
                    {
                        MemoryStream msCheck = (MemoryStream)GetResponse();

                        msCheck.Seek(0, SeekOrigin.Begin);

                        byte[] bytesBuffer = new byte[msCheck.Length];

                        msCheck.Read(bytesBuffer, 0, (int)msCheck.Length);

                        // check the first byte of the stream for result code of transaction
                        if (bytesBuffer[0] == (int)BravaCodes.ProtocolStatus.ACK)
                        {
                            this.Transaction.State = BravaTransaction.TransactionState.Completed;
                            
                            //  if the Protocol Status Code is ACK, there may be more data or not.
                            if (bytesBuffer.Length > 1)
                            {
                                MemoryStream msResponseData = new MemoryStream(bytesBuffer, 1, bytesBuffer.Length - 1);
                                Transaction.ResponseStream = msResponseData;
                            }

                        }
                        if ((bytesBuffer[0] == (int)BravaCodes.ProtocolStatus.NACK) ||
                            (bytesBuffer[0] == (int)BravaCodes.ProtocolStatus.ERROR)
                            )
                        {
                            this.Transaction.State = BravaTransaction.TransactionState.Failed;
                        }

                    }
                    else
                    {
                        // If there was NO response at all after a given interval then this transaction is flagged as Failed.
                        this.Transaction.State = BravaTransaction.TransactionState.Failed;
                    }
                }
                else
                {
                    // No Connection could be established.
                    this.Transaction.State = BravaTransaction.TransactionState.Failed;
                }

                // The network socket is left open, this must be closed as it's good etiquette and network stack management.
                if (this.reqClient!=null && this.reqClient.Connected)
                {
                    this.reqClient.Close();
                }
        }

        #endregion

    }
}
