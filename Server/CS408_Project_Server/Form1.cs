using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS408_Project_Server
{
    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Dictionary<string, Socket> clientDict = new Dictionary<string, Socket>(); // Dictionary to hold all connected username-Socket pairs
        List<string> connectedClients = new List<string>(); // List to hold all connected client usernames
        Dictionary<string, Socket> if100Dict = new Dictionary<string, Socket>(); // Dictionary to hold username-Socket pairs for connected IF100 channel subscribers
        Dictionary<string, Socket> sps101Dict = new Dictionary<string, Socket>(); // Dictionary to hold username-Socket pairs for connected SPS101 channel subscribers     
        bool terminating = false;
        bool listening = false;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        // Start listening to the entered port
        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if (Int32.TryParse(textBox_port.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                button_listen.Enabled = false;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                log_activities.AppendText("Started listening on port: " + serverPort + "\n");
            }
            else
            {
                log_activities.AppendText("Please check port number \n");
            }
        }

        // Continuously accept client sockets if their username is not yet connected 
        private void Accept()
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    Byte[] buffer = new Byte[64];
                    newClient.Receive(buffer); // Get the username from the client

                    string username = Encoding.Default.GetString(buffer);
                    username = username.Substring(0, username.IndexOf("\0"));

                    if (!clientDict.ContainsKey(username)) // Check if username exists
                    {
                        // Add user to the connected clients
                        clientDict.Add(username, newClient);
                        connectedClients.Add(username);
                        log_activities.AppendText(username + " is connected.\n");
                        connected_list.Items.Add(username);

                        // Send acknowledgement to the user
                        Byte[] bufferSend = Encoding.Default.GetBytes("You are connected with username: "+ username +"\n");
                        newClient.Send(bufferSend);

                        Thread receiveThread = new Thread(() => Receive(newClient));
                        receiveThread.Start();
                    }
                    else
                    {
                        // Send failure message to the user
                        Byte[] bufferSend = Encoding.Default.GetBytes("This username already exists!\n");
                        newClient.Send(bufferSend);
                    }
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        log_activities.AppendText("The socket stopped working.\n");
                    }
                }
            }

        }

        // Thread function to continuously receive messages from the client
        private void Receive(Socket thisClient) // updated
        {
            bool connected = true;
            string username = "";

            // Get the username by Socket
            foreach (KeyValuePair<string, Socket> kvp in clientDict)
            {
                if (thisClient == kvp.Value)
                {
                    username = kvp.Key;
                }
            }

            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    thisClient.Receive(buffer); // Get the message from the client

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    string type = incomingMessage.Substring(0, 5); // Exctract the type of the message

                    if (type == "i100s") // If type == IF100 subscribe request
                    {
                        if100Dict.Add(username, thisClient);
                        log_activities.AppendText(username + " has subscribed to IF100.\n");
                        if100_list.Items.Add(username);
                        // Send acknowledgement to the client
                        Byte[] bufferSend = Encoding.Default.GetBytes("You have subscribed to IF100.\n");
                        thisClient.Send(bufferSend);
                    }
                    else if(type == "i100u") // If type == IF100 unsubscribe request
                    {
                        if100Dict.Remove(username);
                        log_activities.AppendText(username + " has unsubscribed from IF100.\n");
                        if100_list.Items.Remove(username);
                        // Send acknowledgement to the client
                        Byte[] bufferSend = Encoding.Default.GetBytes("You have unsubscribed from IF100.\n");
                        thisClient.Send(bufferSend);
                    }
                    else if(type == "i100-") // If type == IF100 message
                    {
                        string msg = type + username + ": " + incomingMessage.Substring(5) + "\n";
                        // Broadcast message to IF100 subscribers
                        Send(msg, "if100");
                        log_activities.AppendText(username + " (to IF100): " + incomingMessage.Substring(5) + "\n");
                    }
                    else if (type == "s101s") // If type == SPS101 subscribe request
                    {
                        sps101Dict.Add(username, thisClient);
                        log_activities.AppendText(username + " has subscribed to SPS101.\n");
                        sps101_list.Items.Add(username);
                        // Send acknoowledgement to the client
                        Byte[] bufferSend = Encoding.Default.GetBytes("You have subscribed to SPS101.\n");
                        thisClient.Send(bufferSend);
                    }
                    else if (type == "s101u") // If type == SPS101 unsubscribe request
                    {
                        sps101Dict.Remove(username);
                        log_activities.AppendText(username + " has unsubscribed from SPS101.\n");
                        sps101_list.Items.Remove(username);
                        // Send acknowledgement to the client
                        Byte[] bufferSend = Encoding.Default.GetBytes("You have unsubscribed from SPS101.\n");
                        thisClient.Send(bufferSend);
                    }
                    else if (type == "s101-") // If type == SPS101 message
                    {
                        string msg = type + username + ": " + incomingMessage.Substring(5) + "\n";
                        // Broadcast message to SPS101 subscribers
                        Send(msg, "sps101");
                        log_activities.AppendText(username + " (to SPS101): " + incomingMessage.Substring(5) + "\n");
                    }
                    else
                    {
                        Send("Server made a mistake!\n", "");
                    }

                }
                catch
                {
                    if (!terminating)
                    {
                        log_activities.AppendText(username + " has disconnected.\n");
                    }
                    // Client is disconnected, remove him/her from all the channels and connection lists
                    thisClient.Close();
                    connectedClients.Remove(username);
                    clientDict.Remove(username);
                    if100Dict.Remove(username);
                    sps101Dict.Remove(username);
                    if100_list.Items.Remove(username);
                    sps101_list.Items.Remove(username);
                    connected_list.Items.Remove(username);
                    connected = false;
                }
            }
        }

        // Broadcast message to the given channel only based on type
        void Send(string msg, string type)
        {
            if(type == "if100") // If channel is IF100
            {
                foreach(KeyValuePair<string, Socket> kvp in if100Dict)
                {
                    Byte[] buffer = Encoding.Default.GetBytes(msg);
                    kvp.Value.Send(buffer);
                }
            }
            else if (type == "sps101") // If channel is SPS101
            {
                foreach (KeyValuePair<string, Socket> kvp in sps101Dict)
                {
                    Byte[] buffer = Encoding.Default.GetBytes(msg);
                    kvp.Value.Send(buffer);
                }
            }
            else 
            {
                foreach (KeyValuePair<string, Socket> kvp in clientDict)
                {
                    Byte[] buffer = Encoding.Default.GetBytes(msg);
                    kvp.Value.Send(buffer);
                }
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }
    }
}
