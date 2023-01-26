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

namespace client
{
    public partial class Form1 : Form
    {

        bool terminating = false;
        bool connected = false;
        bool disconnected = false;
        Socket clientSocket;
        string username;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = textBox_IP.Text;
            username = textBox_username.Text;

            int portNum;
            if (!Int32.TryParse(textBox_port.Text, out portNum))
            {
                logs.AppendText("Please check port number!\n");

                textBox_port.Clear();
            }
            else if (IP == "")
            {
                logs.AppendText("Ip address slot can not be empty!\n");

              
            }
            else if (username == "" || username.Length > 64)
            {
                logs.AppendText("Username is not in a valid length!\n");

                textBox_username.Clear();
            }
            else
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
                    checkConnection();
                }
                catch
                {
                    logs.AppendText("Could not connect to the server!\n");

                  
                }
            }

        }
        private void checkConnection()
        {
            try
            {
                Byte[] buffer = Encoding.Default.GetBytes(username);
                clientSocket.Send(buffer);

                Byte[] buffer2 = new Byte[1];
                clientSocket.Receive(buffer2);

                if (buffer2[0] > 0)
                {
                    button_connect.Enabled = false;
                    textBox_IP.Enabled = false;
                    textBox_port.Enabled = false;
                    textBox_username.Enabled = false;
                    textBox_post.Enabled = true;
                    button_send.Enabled = true;
                    button_allposts.Enabled = true;
                    button_disconnect.Enabled = true;
                    connected = true;
                    disconnected = false;
                    logs.AppendText("Connected to the server!\n");

                    Thread receiveThread = new Thread(Receive);
                    receiveThread.Start();
                }
                else
                {
                    if (!terminating)
                    {
                        logs.AppendText("The server did not accept the username!\n");
                        button_connect.Enabled = true;
                        textBox_post.Enabled = false;
                        button_send.Enabled = false;
                        button_allposts.Enabled = false;

                        textBox_username.Clear();
                    }
                    clientSocket.Close();
                    connected = false;
                }
            }
            catch
            {
                logs.AppendText("The server did not reply back about connection!\n");
            }
        }
        private void Receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[1024];
                    clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    logs.AppendText(incomingMessage + "\n");
                }
                catch
                {
                    if (!terminating && !disconnected)
                    {
                        logs.AppendText("The server has disconnected\n");
                        button_connect.Enabled = true;
                        button_disconnect.Enabled = false;
                        button_send.Enabled = false;
                        button_allposts.Enabled = false;

                        textBox_post.Enabled = false;
                        textBox_IP.Enabled = true;
                        textBox_port.Enabled = true;
                        textBox_username.Enabled = true;

                        clientSocket.Close();           //close connection to the socket
                        connected = false;
                    }
                }
            }
        }
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }



        private void button_disconnect_Click(object sender, EventArgs e)
        {
            connected = false;
            disconnected = true;
            clientSocket.Close();

            logs.AppendText("Disconnected from the server\n");
            button_connect.Enabled = true;
            button_disconnect.Enabled = false;
            button_send.Enabled = false;
            button_allposts.Enabled = false;

            textBox_post.Enabled = false;
            textBox_IP.Enabled = true;
            textBox_port.Enabled = true;
            textBox_username.Enabled = true;
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            string operation = "send";
            Byte[] buffer = Encoding.Default.GetBytes(operation);
            clientSocket.Send(buffer);

            string message = textBox_post.Text;

            if (message.Length <= 64)
            {
                Byte[] buffer3 = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer3);

                logs.AppendText(username + ": " + message + "\n\n");

                textBox_post.Clear();


            }
        }

        private void button_allposts_Click(object sender, EventArgs e)
        {
            string operation = "allposts";
            Byte[] buffer = Encoding.Default.GetBytes(operation);
            clientSocket.Send(buffer);
        }

      
        private void button_friend_post_Click(object sender, EventArgs e)
        {
            string operation = "friendposts";
            Byte[] buffer = Encoding.Default.GetBytes(operation);
            clientSocket.Send(buffer);
        }

        private void button_add_friend_Click(object sender, EventArgs e)
        {
            string operation = "add_friend";
            string username_added= textBox_username2.Text
            string msg = operation+ " " + username_added;
            Byte[] buffer = Encoding.Default.GetBytes(msg);
            clientSocket.Send(buffer);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            string operation = "delete";
            Byte[] buffer = Encoding.Default.GetBytes(msg);
            clientSocket.Send(buffer);

            string message = textBox_post_id.Text;
            if (message.Length <= 64)
            {
                Byte[] buffer2 = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer2);                              //send delete post id
            }
        }

        private void button_my_posts_Click(object sender, EventArgs e)
        {
            string operation = "myposts";
            Byte[] buffer = Encoding.Default.GetBytes(operation);
            clientSocket.Send(buffer);

        }

        private void button_remove_friend_Click(object sender, EventArgs e)
        {

        }
    }
}
