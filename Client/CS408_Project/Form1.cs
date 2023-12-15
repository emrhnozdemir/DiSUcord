using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS408_Project
{
    public partial class Form1 : Form
    {
        Socket clientSocket;
        bool terminating = false;
        bool connected = false;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }
        // Function to call when the connection is closed to reset the state
        private void disconnect()
        {
            connected = false;
            terminating = true;
            clientSocket.Close();
            button_connect.Text = "Connect";
            if100_subscribe.Enabled = false;
            if100_send.Enabled = false;
            if100_subscribe.Text = "Subscribe";
            sps101_subscribe.Enabled = false;
            sps101_send.Enabled = false;
            sps101_subscribe.Text = "Subscribe";
        }
        // Button click controls both connect and diconnect functions
        private void button_connect_Click(object sender, EventArgs e)
        {
            user_status.Clear();
            if100_logs.Clear();
            sps101_logs.Clear();
            if100_message.Clear();
            sps101_message.Clear();
            if (button_connect.Text == "Connect") {
                terminating = false;
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                string IP = textBox_ip.Text;
                string username = textBox_username.Text;
                int portNum;
                if (Int32.TryParse(textBox_port.Text, out portNum))
                {
                    if (username != "" && username.Length <= 64)
                    {
                        try
                        {
                            clientSocket.Connect(IP, portNum);
                            Byte[] bufferSend = Encoding.Default.GetBytes(username);
                            clientSocket.Send(bufferSend);

                            // Check the connection status ack based on existing usernames
                            try 
                            {
                                Byte[] buffer = new Byte[64];
                                clientSocket.Receive(buffer);
                                string incomingMessage = Encoding.Default.GetString(buffer);

                                incomingMessage = incomingMessage.Trim('\0');

                                user_status.AppendText(incomingMessage);
                                if (incomingMessage != "This username already exists!\n") // Successful connection
                                {
 
                                    button_connect.Text = "Disconnect";
                                    if100_subscribe.Enabled = true;
                                    sps101_subscribe.Enabled = true;
                                    connected = true;

                                    Thread receiveThread = new Thread(Receive);
                                    receiveThread.Start();
                                }
                            }
                            catch
                            {
                                if (!terminating)
                                {
                                    user_status.AppendText("Server has disconnected!\n");
                                    button_connect.Enabled = true;
                                }
                                clientSocket.Close();
                                connected = false;
                            }
                        }
                        catch
                        {
                            user_status.AppendText("Could not connect to the server!\n");
                        }
                    }
                    else
                    {
                        user_status.AppendText("The username cannot be empty!\n");
                    }
                }
                else
                {
                    user_status.AppendText("The Port or IP is incorrect!\n");
                }

            } else if (button_connect.Text == "Disconnect") {
                disconnect();
                user_status.AppendText("You have disconnected from the server.\n");
            }

        }

        // Send subscribe or unsubscribe request for IF100 channel to the server 
        private void if100_subscribe_Click(object sender, EventArgs e)
        {
            if (if100_subscribe.Text == "Subscribe") {
                try
                {
                    Byte[] sendBuffer = Encoding.Default.GetBytes("i100s"); // Send type for server to identify channel and request type (subscribe)
                    clientSocket.Send(sendBuffer);

                    if100_subscribe.Text = "Unsubscribe";
                    if100_send.Enabled = true;
                }
                catch
                {
                    if (!terminating)
                    {
                        user_status.AppendText("An error occured while subscribing, server disconnected.!\n\n");
                    }
                    disconnect();
                }
            } else if (if100_subscribe.Text == "Unsubscribe") {
                try
                {
                    Byte[] sendBuffer = Encoding.Default.GetBytes("i100u"); // Send type for server to identify channel and request type (unsubscribe)
                    clientSocket.Send(sendBuffer);

                    if100_subscribe.Text = "Subscribe";
                    if100_send.Enabled = false;
                }
                catch
                {
                    if (!terminating)
                    {
                        user_status.AppendText("An error occured while unsubscribing, server disconnected.!\n\n");
                    }
                    disconnect();
                }
            }
        }

        // Send subscribe or unsubscribe request for SPS101 channel to the server 
        private void sps101_subscribe_Click(object sender, EventArgs e)
        {
            if (sps101_subscribe.Text == "Subscribe")
            {
                try
                {
                    Byte[] sendBuffer = Encoding.Default.GetBytes("s101s"); // Send type for server to identify channel and request type (subscribe)
                    clientSocket.Send(sendBuffer);

                    sps101_subscribe.Text = "Unsubscribe";
                    sps101_send.Enabled = true;
                }
                catch
                {
                    if (!terminating)
                    {
                        user_status.AppendText("An error occured while subscribing, server disconnected.!\n\n");
                    }
                    disconnect();
                }
            }
            else if (sps101_subscribe.Text == "Unsubscribe")
            {
                try
                {
                    Byte[] sendBuffer = Encoding.Default.GetBytes("s101u"); // Send type for server to identify channel and request type (unsubscribe)
                    clientSocket.Send(sendBuffer);

                    sps101_subscribe.Text = "Subscribe";
                    sps101_send.Enabled = false;
                }
                catch
                {
                    if (!terminating)
                    {
                        user_status.AppendText("An error occured while unsubscribing, server has disconnected.!\n\n");
                    }
                    disconnect();
                }
            }
        }

        // Thread function for continuously receive messages from the server
        private void Receive() 
        {
            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    if(incomingMessage.Substring(0, 5) == "i100-") // Message from IF100 channel has been received
                    {
                        if100_logs.AppendText(incomingMessage.Substring(5));
                    }
                    else if(incomingMessage.Substring(0, 5) == "s101-") // Message from SPS101 channel has been received
                    {
                        sps101_logs.AppendText(incomingMessage.Substring(5));
                    }
                    else
                    {
                        user_status.AppendText(incomingMessage);
                    }   
                }
                catch
                {
                    if (!terminating)
                    {
                        user_status.AppendText("Server has disconnected!\n");
                    }
                    disconnect();
                }
            }
        }

        // Send message to IF100 channel
        private void if100_send_Click(object sender, EventArgs e)
        {
            try
            {
                string if100_msg = "i100-" + if100_message.Text; // Concat type and message for server to identify channel type 
                Byte[] buffer = Encoding.Default.GetBytes(if100_msg);
                clientSocket.Send(buffer);
                if100_message.Clear();
            }
            catch
            {
                disconnect();
                user_status.AppendText("Server has disconnected!\n");
            }
        }

        // Send message to SPS101 channel
        private void sps101_send_Click(object sender, EventArgs e)
        {
            try
            {
                string sps101_msg = "s101-" + sps101_message.Text; // Concat type and message for server to identify channel type
                Byte[] buffer = Encoding.Default.GetBytes(sps101_msg);
                clientSocket.Send(buffer);
                sps101_message.Clear();
            }
            catch
            {
                disconnect();
                user_status.AppendText("Server has disconnected!\n");
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            terminating = true;
            connected = false;
            Environment.Exit(0);
        }
    }
}
