using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {
        struct clientInfo
        {
            public string userName;
            public Socket clientSocket;
            public clientInfo(string name, Socket socket) { userName = name; clientSocket = socket; }

        }

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<clientInfo> clientSockets = new List<clientInfo>();

        bool terminating = false;
        bool listening = false;
        int post_id;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if (Int32.TryParse(textBox_server.Text, out serverPort))
            {
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endpoint);
                serverSocket.Listen(3);

                textBox_server.Enabled = false;
                listening = true;
                button_listen.Enabled = false;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                logs.AppendText("Started listening on port: " + serverPort + "\n");
            }
            else
            {
                logs.AppendText("Please check port number.\n");
                textBox_server.Clear();
            }


        }

        private void Accept()
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    UsernameCheck(newClient);
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs.AppendText("The socket stopped working.\n");
                    }
                }

            }
        }

        private void UsernameCheck(Socket newClient)
        {
            Byte[] buffer = new Byte[64];
            newClient.Receive(buffer);
            string username = Encoding.Default.GetString(buffer);
            username = username.Substring(0, username.IndexOf("\0"));

            if (clientSockets.Any(client => client.userName == username))
            {
                sendBoolean(false, newClient);

                logs.AppendText("Another client with the same username is already connected, client is not accepted.\n");
                newClient.Close();
            }
            else
            {
                string filename = "../../user-db.txt";
                string[] lines = File.ReadAllLines(filename);

                if (!lines.Contains(username))
                {
                    sendBoolean(false, newClient);

                    logs.AppendText("The client's username does not exists in the database, client is not accepted.\n");
                    newClient.Close();
                }
                else
                {
                    sendBoolean(true, newClient);

                    clientInfo accepted_client = new clientInfo(username, newClient);
                    clientSockets.Add(accepted_client);
                    logs.AppendText("Client " + username + " is connected.\n");

                    Thread receiveThread = new Thread(() => Receive(accepted_client));
                    receiveThread.Start();
                }
            }
        }

        private void Receive(clientInfo thisClient)
        {
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    thisClient.clientSocket.Receive(buffer);

                    string time_now = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                    string operation = Encoding.Default.GetString(buffer);
                    operation = operation.Substring(0, operation.IndexOf("\0"));

                    if (operation == "send")
                    {
                        Byte[] buffer_2 = new Byte[64];
                        thisClient.clientSocket.Receive(buffer_2);

                        string incomingMessage = Encoding.Default.GetString(buffer_2);
                        incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                        logs.AppendText(thisClient.userName + " send a post\n" + incomingMessage + "\n");

                        if (new FileInfo("posts.txt").Length == 0)
                        {
                            post_id = 0;
                        }
                        else
                        {
                            var lineCount = File.ReadLines(@"posts.txt").Count();
                            post_id = lineCount / 5;
                        }
                            File.AppendAllText(@"posts.txt", "Username: "+ thisClient.userName + "\n" + "Post id: " + post_id + "\n" + "Post: " +incomingMessage + "\n" + "Time:" + time_now + "\n\n");

                            post_id++;
                    }
                    else if (operation == "allposts")
                    {
                        logs.AppendText("Showing all posts for " + thisClient.userName + "\n");

                        allPosts(thisClient);
                    }
                    else if (operation == "myposts")
                    {
                        logs.AppendText("Showing " + thisClient.userName +"'s posts" ++ "\n");

                        myPosts(thisClient);
                    }
                    else if (operation == "delete")
                    {
                       // logs.AppendText("Showing " + thisClient.userName +"'s posts" ++ "\n");

                        deletePost(thisClient);
                    }

                }
                catch
                {
                    if (!terminating)
                    {
                        logs.AppendText("Client " + thisClient.userName + " has disconnected\n");

                    }
                    thisClient.clientSocket.Close();
                    clientSockets.Remove(thisClient);
                    connected = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }
        private void sendBoolean(bool value, Socket clientSocket) //send boolean value to the client
        {
            Byte[] buffer = BitConverter.GetBytes(value);
            clientSocket.Send(buffer);
        }

        private void allPosts(clientInfo thisClient)
        {
            string fileName = "posts.txt";
            string[] lines = File.ReadAllLines(fileName);

            if (lines.Length != 0)
            {
                string post = "";
                int i = 1;
                bool willBeSent = false;

                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        if (i % 4 == 1)
                        {
                            string search = "Username: " + thisClient.userName;   
                            if (line != search)
                            {
                                willBeSent = true;
                            }
                        }
                        post += line;
                        post += "\n";

                        if (i % 4 == 0)
                        {
                            if (willBeSent)
                            {
                                Byte[] buffer = Encoding.Default.GetBytes(post);
                                thisClient.clientSocket.Send(buffer);
                            }
                            willBeSent = false;
                            post = "";
                        }
                        i++;
                    }
                }

            }

        }
         private void myPosts(clientInfo thisClient)
        {
            string fileName = "posts.txt";
            string[] lines = File.ReadAllLines(fileName);

            if (lines.Length != 0)
            {
                string post = "";
                int i = 1;
                bool willBeSent = false;

                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        if (i % 4 == 1)
                        {
                            string search = "Username: " + thisClient.userName;
                            if (line == search)
                            {
                                willBeSent = true;
                            }
                        }
                        post += line;
                        post += "\n";

                        if (i % 4 == 0)
                        {
                            if (willBeSent)
                            {
                                Byte[] buffer = Encoding.Default.GetBytes(post);
                                thisClient.clientSocket.Send(buffer);
                            }
                            willBeSent = false;
                            post = "";
                        }
                        i++;
                    }
                }

            }

        }
        private void deletePost(clientInfo thisClient){
            Byte[] buffer_4 = new Byte[64];               
            thisClient.clientSocket.Receive(buffer_4);
            string post_id = Encoding.Default.GetString(buffer_4);
            post_id = post_id.Substring(0, post_id.IndexOf("\0"));

            logs.AppendText(thisClient.userName + " wants to delete a post: " + post_id ".\n"); 

            string fileName = "posts.txt";
            string[] lines = File.ReadAllLines(fileName);
           
            if (lines.Length != 0){
                bool willBeDelete = false;
                bool foundPost = false;
                for(int index = 0; index < lines.Count; index++){
                    string search_post_id = "Post id: "+post_id;
                    if(lines[index] == search_post_id){
                        index = index - 1;
                        string search_username = "Username: "+thisClient.userName;
                        if(lines[index] == search_username){
                            
                            logs.AppendText( thisClient.userName+ " post id " + post_id + " was deleted."+ "\n");  //print out the user name and post id that was deleted
                            string msg_exist = "The post you asked to delete was removed.";  
                            Byte[] buf_exist = Encoding.Default.GetBytes(msg_exist);
                            thisClient.Send(buf_exist);
                        }
                        else{
                            logs.AppendText(thisClient.userName+ " tried to delete post of another user\n");
                            string msg_exist = "You are not allowed to delete post of another user.";
                            Byte[] buf_exist = Encoding.Default.GetBytes(msg_exist);
                            thisClient.Send(buf_exist);
                        }

                    }
                    else{
                        logs.AppendText(name + " tried to delete a post which does not exist.\n");
                        string msg_exist = "The post you asked to delete does not exist.";
                        Byte[] buf_exist = Encoding.Default.GetBytes(msg_exist);
                        thisClient.Send(buf_exist);
                        
                    }
                }
                
            }
           

        }
    }
}





