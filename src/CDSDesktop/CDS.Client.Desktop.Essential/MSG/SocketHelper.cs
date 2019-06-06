using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDS.Client.Desktop.Essential.MSG
{
    public class SocketHelper
    {
        TcpClient mscClient;
        string mstrMessage;
        string mstrResponse;
        byte[] bytesSent;
        public void processMsg(TcpClient client, NetworkStream stream, byte[] bytesReceived)
        {
            // Handle the message received and  
            // send a response back to the client.
            mstrMessage = Encoding.ASCII.GetString(bytesReceived, 0, bytesReceived.Length);
            mscClient = client;
            //mstrMessage = mstrMessage.Substring(0, 5);
            mstrMessage = mstrMessage.Replace("\0", string.Empty);
            //Essential.BaseAlert.ShowAlert("Socket Message", mstrMessage, BaseAlert.Buttons.Ok, BaseAlert.Icons.Information);

            Form mainform;
            Type typExternal;
            MethodInfo methodInf;
            switch (mstrMessage)
            {
                case "" :
                    
                    break;
                case "Command:ForceClose":

                    mstrResponse = "Received Message";
                    bytesSent = Encoding.ASCII.GetBytes(mstrResponse);
                    stream.Write(bytesSent, 0, bytesSent.Length);
                    // using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                    {
                        mainform = Application.OpenForms["MainForm"];
                        typExternal = mainform.GetType();
                        methodInf = typExternal.GetMethod("ForceClose");

                        methodInf.Invoke(mainform, new object[] { });
                    }
                    break;
                case "TestConnection":
                    mstrResponse = "Received Connection";
                    bytesSent = Encoding.ASCII.GetBytes(mstrResponse);
                    stream.Write(bytesSent, 0, bytesSent.Length);
                    break;
                default:
                    mstrResponse = "Received Message";
                    bytesSent = Encoding.ASCII.GetBytes(mstrResponse);
                    stream.Write(bytesSent, 0, bytesSent.Length);

                    mainform = Application.OpenForms["MainForm"];
                    typExternal = mainform.GetType();
                    methodInf = typExternal.GetMethod("UpdateMessages");
                    methodInf.Invoke(mainform, new object[] { });

                    typExternal = mainform.GetType();
                    methodInf = typExternal.GetMethod("ShowMessagesNotification");
                    methodInf.Invoke(mainform, new object[] { Convert.ToInt64(mstrMessage.Split(',')[0]), mstrMessage.Split(',')[1] });

                    break;
            }
        }
    }
}
