namespace client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_post = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.button_send = new System.Windows.Forms.Button();
            this.button_allposts = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_username2 = new System.Windows.Forms.TextBox();
            this.textBox_post_id = new System.Windows.Forms.TextBox();
            this.button_remove_friend = new System.Windows.Forms.Button();
            this.button_add_friend = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_my_posts = new System.Windows.Forms.Button();
            this.button_friend_post = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "PORT:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "USERNAME:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "POST:";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(124, 33);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(100, 22);
            this.textBox_IP.TabIndex = 4;
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(124, 92);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(100, 22);
            this.textBox_port.TabIndex = 5;
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(124, 164);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(100, 22);
            this.textBox_username.TabIndex = 6;
            // 
            // textBox_post
            // 
            this.textBox_post.Enabled = false;
            this.textBox_post.Location = new System.Drawing.Point(107, 411);
            this.textBox_post.Name = "textBox_post";
            this.textBox_post.Size = new System.Drawing.Size(151, 22);
            this.textBox_post.TabIndex = 7;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(285, 35);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(89, 23);
            this.button_connect.TabIndex = 8;
            this.button_connect.Text = "CONNECT";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_disconnect
            // 
            this.button_disconnect.Enabled = false;
            this.button_disconnect.Location = new System.Drawing.Point(270, 86);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(118, 23);
            this.button_disconnect.TabIndex = 9;
            this.button_disconnect.Text = "DISCONNECT";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // button_send
            // 
            this.button_send.Enabled = false;
            this.button_send.Location = new System.Drawing.Point(299, 414);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 10;
            this.button_send.Text = "SEND";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_allposts
            // 
            this.button_allposts.Enabled = false;
            this.button_allposts.Location = new System.Drawing.Point(427, 408);
            this.button_allposts.Name = "button_allposts";
            this.button_allposts.Size = new System.Drawing.Size(113, 23);
            this.button_allposts.TabIndex = 11;
            this.button_allposts.Text = "ALL POSTS";
            this.button_allposts.UseVisualStyleBackColor = true;
            this.button_allposts.Click += new System.EventHandler(this.button_allposts_Click);
            // 
            // logs
            // 
            this.logs.Enabled = false;
            this.logs.Location = new System.Drawing.Point(447, 40);
            this.logs.Name = "logs";
            this.logs.ReadOnly = true;
            this.logs.Size = new System.Drawing.Size(274, 337);
            this.logs.TabIndex = 12;
            this.logs.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(98, 205);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(160, 115);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "USERNAME:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 473);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "POST ID:";
            // 
            // textBox_username2
            // 
            this.textBox_username2.Enabled = false;
            this.textBox_username2.Location = new System.Drawing.Point(107, 355);
            this.textBox_username2.Name = "textBox_username2";
            this.textBox_username2.Size = new System.Drawing.Size(151, 22);
            this.textBox_username2.TabIndex = 16;
            // 
            // textBox_post_id
            // 
            this.textBox_post_id.Enabled = false;
            this.textBox_post_id.Location = new System.Drawing.Point(107, 470);
            this.textBox_post_id.Name = "textBox_post_id";
            this.textBox_post_id.Size = new System.Drawing.Size(151, 22);
            this.textBox_post_id.TabIndex = 17;
            // 
            // button_remove_friend
            // 
            this.button_remove_friend.Enabled = false;
            this.button_remove_friend.Location = new System.Drawing.Point(270, 297);
            this.button_remove_friend.Name = "button_remove_friend";
            this.button_remove_friend.Size = new System.Drawing.Size(139, 23);
            this.button_remove_friend.TabIndex = 18;
            this.button_remove_friend.Text = "REMOVE FRIEND";
            this.button_remove_friend.UseVisualStyleBackColor = true;
            this.button_remove_friend.Click += new System.EventHandler(this.button_remove_friend_Click);
            // 
            // button_add_friend
            // 
            this.button_add_friend.Enabled = false;
            this.button_add_friend.Location = new System.Drawing.Point(299, 354);
            this.button_add_friend.Name = "button_add_friend";
            this.button_add_friend.Size = new System.Drawing.Size(110, 23);
            this.button_add_friend.TabIndex = 19;
            this.button_add_friend.Text = "ADD FRIEND";
            this.button_add_friend.UseVisualStyleBackColor = true;
            this.button_add_friend.Click += new System.EventHandler(this.button_add_friend_Click);
            // 
            // button_delete
            // 
            this.button_delete.Enabled = false;
            this.button_delete.Location = new System.Drawing.Point(299, 473);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(89, 23);
            this.button_delete.TabIndex = 20;
            this.button_delete.Text = "DELETE";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_my_posts
            // 
            this.button_my_posts.Enabled = false;
            this.button_my_posts.Location = new System.Drawing.Point(504, 467);
            this.button_my_posts.Name = "button_my_posts";
            this.button_my_posts.Size = new System.Drawing.Size(114, 23);
            this.button_my_posts.TabIndex = 21;
            this.button_my_posts.Text = "MY POSTS";
            this.button_my_posts.UseVisualStyleBackColor = true;
            this.button_my_posts.Click += new System.EventHandler(this.button_my_posts_Click);
            // 
            // button_friend_post
            // 
            this.button_friend_post.Enabled = false;
            this.button_friend_post.Location = new System.Drawing.Point(588, 408);
            this.button_friend_post.Name = "button_friend_post";
            this.button_friend_post.Size = new System.Drawing.Size(155, 23);
            this.button_friend_post.TabIndex = 22;
            this.button_friend_post.Text = "FRIEND\'S POSTS";
            this.button_friend_post.UseVisualStyleBackColor = true;
            this.button_friend_post.Click += new System.EventHandler(this.button_friend_post_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 554);
            this.Controls.Add(this.button_friend_post);
            this.Controls.Add(this.button_my_posts);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_add_friend);
            this.Controls.Add(this.button_remove_friend);
            this.Controls.Add(this.textBox_post_id);
            this.Controls.Add(this.textBox_username2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button_allposts);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_post);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_post;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_allposts;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_username2;
        private System.Windows.Forms.TextBox textBox_post_id;
        private System.Windows.Forms.Button button_remove_friend;
        private System.Windows.Forms.Button button_add_friend;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_my_posts;
        private System.Windows.Forms.Button button_friend_post;
    }
}

