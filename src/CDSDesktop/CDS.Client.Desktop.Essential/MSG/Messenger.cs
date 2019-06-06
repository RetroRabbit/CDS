using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CDS.Client.Desktop.Essential.MSG
{
    public class Messenger
    {
        static string output = "";

        public static void CreateListener(int taskNum, string port, CancellationToken ct)
        {
            // Create an instance of the TcpListener class.
            TcpListener tcpListener = null;
            //IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
            try
            {
                // Set the listener on the local IP address 
                // and specify the port.

                //tcpListener = new TcpListener(ipAddress, Convert.ToInt32(port));
                tcpListener = new TcpListener(IPAddress.Any, Convert.ToInt32(port));
                tcpListener.Start();
                output = "Waiting for a connection...";
            }
            catch (Exception e)
            {
                output = "Error: " + e.ToString();
                //MessageBox.Show(output);
            }

            while (!ct.IsCancellationRequested)
            {
                // Always use a Sleep call in a while(true) loop 
                // to avoid locking up your CPU.
                Thread.Sleep(10);
                // Create a TCP socket. 
                // If you ran this server on the desktop, you could use 
                //Socket socket = tcpListener.AcceptSocket();
                // for greater flexibility.
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                // Read the data stream from the client. 
                byte[] bytes = new byte[4096];
                NetworkStream stream = tcpClient.GetStream();
                stream.Read(bytes, 0, bytes.Length);
                SocketHelper helper = new SocketHelper();
                helper.processMsg(tcpClient, stream, bytes);
            }
        }

        public static string Connect(Essential.MSG.MessengerUsers selectedUser, string message)
        { 
            string serverIP = selectedUser.IP;
            Int32 port = Convert.ToInt32(selectedUser.Port);
            string output = "";
            bool success = true;
            try
            {
                output = "Sent: " + message;
                // Create a TcpClient. 
                // The client requires a TcpServer that is connected 
                // to the same address specified by the server and port 
                // combination. 
                TcpClient client = new TcpClient(serverIP, port);

                // Translate the passed message into ASCII and store it as a byte array.
                Byte[] data = new Byte[4096];
                data = System.Text.Encoding.ASCII.GetBytes(selectedUser.Id + "," + message);

                // Get a client stream for reading and writing. 
                // Stream stream = client.GetStream();
                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                //Essential.BaseAlert.ShowAlert("Socket Message", output, BaseAlert.Buttons.Ok, BaseAlert.Icons.Information);

                // Buffer to store the response bytes.
                data = new Byte[4096];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                if (responseData.Equals("Received Message"))
                    output = "Received: " + responseData;
                //Essential.BaseAlert.ShowAlert("Socket Message", output, BaseAlert.Buttons.Ok, BaseAlert.Icons.Information);

                // Close everything.
                stream.Close();
                client.Close();
                success = true;
            }
            catch (ArgumentNullException e)
            {
                //output = "ArgumentNullException: " + e;
                Essential.BaseAlert.ShowAlert("Socket Message", "ArgumentNullException: " + e, BaseAlert.Buttons.Ok, BaseAlert.Icons.Information);
                success = false;
            }
            catch (SocketException e)
            {
                //output = "SocketException: " + e.ToString();
                Essential.BaseAlert.ShowAlert("Socket Message", "SocketException: " + e.ToString(), BaseAlert.Buttons.Ok, BaseAlert.Icons.Information);
                success = false;
            }
            return output;
        }

        public static string TestConnection(string serverIP, int port)
        {
            try
            {

                using (TcpClient tcp = new TcpClient())
                {
                    IAsyncResult ar = tcp.BeginConnect(serverIP, port, null, null);
                    System.Threading.WaitHandle wh = ar.AsyncWaitHandle;
                    try
                    {
                        if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(0.5), false))
                        {
                            tcp.Close(); 
                        }
                        tcp.EndConnect(ar);
                        output = "Received Connection";
                    }
                    catch
                    {
                        output = "No Connection";
                    }
                    finally
                    {
                        wh.Close();
                    }
                }
                //    string message = "TestConnection";
                //    // Create a TcpClient. 
                //    // The client requires a TcpServer that is connected 
                //    // to the same address specified by the server and port 
                //    // combination. 
                //    TcpClient client = new TcpClient();
                //    client
                //    client.SendTimeout = 100;
                //    client.ReceiveTimeout = 100;
                //    client.Connect(serverIP, Convert.ToInt32(port));
                //    // Translate the passed message into ASCII and store it as a byte array.
                //    Byte[] data = new Byte[4096];
                //    data = System.Text.Encoding.ASCII.GetBytes(message);

                //    // Get a client stream for reading and writing. 
                //    // Stream stream = client.GetStream();
                //    NetworkStream stream = client.GetStream();

                //    // Send the message to the connected TcpServer. 
                //    stream.Write(data, 0, data.Length);

                //    output = "Sent: " + message;
                //    // Essential.BaseAlert.ShowAlert("Socket Message", output, BaseAlert.Buttons.Ok, BaseAlert.Icons.Information);

                //    // Buffer to store the response bytes.
                //    data = new Byte[4096];

                //    // String to store the response ASCII representation.
                //    String responseData = String.Empty;

                //    // Read the first batch of the TcpServer response bytes.
                //    Int32 bytes = stream.Read(data, 0, data.Length);
                //    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                //    output = "Received: " + responseData;
                //    //   Essential.BaseAlert.ShowAlert("Socket Message", output, BaseAlert.Buttons.Ok, BaseAlert.Icons.Information);

                //    // Close everything.
                //    stream.Close();
                //    client.Close();
            }
            catch (ArgumentNullException e)
            {
                output = "ArgumentNullException: " + e;
                //Essential.BaseAlert.ShowAlert("Socket Message", output, BaseAlert.Buttons.Ok, BaseAlert.Icons.Information);
            }
            catch (SocketException e)
            {
                output = "SocketException: " + e.ToString();
                //Essential.BaseAlert.ShowAlert("Socket Message", output, BaseAlert.Buttons.Ok, BaseAlert.Icons.Information);
            }

            return output;
        }
    }

    public class MessengerUsers
    {
        public Int64 Id { get; set; }
        public Image Image { get; set; }
        public string DisplayName { get; set; }
        public string IP { get; set; }
        public Int32 Port { get; set; }
    }
}
