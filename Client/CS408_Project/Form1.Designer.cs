namespace CS408_Project
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
            this.user_status = new System.Windows.Forms.RichTextBox();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.if100_subscribe = new System.Windows.Forms.Button();
            this.sps101_subscribe = new System.Windows.Forms.Button();
            this.if100_logs = new System.Windows.Forms.RichTextBox();
            this.sps101_logs = new System.Windows.Forms.RichTextBox();
            this.if100_send = new System.Windows.Forms.Button();
            this.sps101_send = new System.Windows.Forms.Button();
            this.if100_message = new System.Windows.Forms.TextBox();
            this.sps101_message = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Username:";
            // 
            // user_status
            // 
            this.user_status.Location = new System.Drawing.Point(15, 182);
            this.user_status.Name = "user_status";
            this.user_status.Size = new System.Drawing.Size(210, 190);
            this.user_status.TabIndex = 3;
            this.user_status.Text = "";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(76, 46);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(149, 20);
            this.textBox_ip.TabIndex = 4;
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(76, 74);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(149, 20);
            this.textBox_port.TabIndex = 5;
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(76, 100);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(149, 20);
            this.textBox_username.TabIndex = 6;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(76, 134);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 23);
            this.button_connect.TabIndex = 7;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "IF 100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(634, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "SPS 101";
            // 
            // if100_subscribe
            // 
            this.if100_subscribe.Enabled = false;
            this.if100_subscribe.Location = new System.Drawing.Point(483, 20);
            this.if100_subscribe.Name = "if100_subscribe";
            this.if100_subscribe.Size = new System.Drawing.Size(75, 23);
            this.if100_subscribe.TabIndex = 10;
            this.if100_subscribe.Text = "Subscribe";
            this.if100_subscribe.UseVisualStyleBackColor = true;
            this.if100_subscribe.Click += new System.EventHandler(this.if100_subscribe_Click);
            // 
            // sps101_subscribe
            // 
            this.sps101_subscribe.Enabled = false;
            this.sps101_subscribe.Location = new System.Drawing.Point(842, 20);
            this.sps101_subscribe.Name = "sps101_subscribe";
            this.sps101_subscribe.Size = new System.Drawing.Size(75, 23);
            this.sps101_subscribe.TabIndex = 11;
            this.sps101_subscribe.Text = "Subscribe";
            this.sps101_subscribe.UseVisualStyleBackColor = true;
            this.sps101_subscribe.Click += new System.EventHandler(this.sps101_subscribe_Click);
            // 
            // if100_logs
            // 
            this.if100_logs.Location = new System.Drawing.Point(281, 49);
            this.if100_logs.Name = "if100_logs";
            this.if100_logs.Size = new System.Drawing.Size(280, 323);
            this.if100_logs.TabIndex = 12;
            this.if100_logs.Text = "";
            // 
            // sps101_logs
            // 
            this.sps101_logs.BackColor = System.Drawing.SystemColors.Window;
            this.sps101_logs.Location = new System.Drawing.Point(637, 49);
            this.sps101_logs.Name = "sps101_logs";
            this.sps101_logs.Size = new System.Drawing.Size(280, 323);
            this.sps101_logs.TabIndex = 13;
            this.sps101_logs.Text = "";
            // 
            // if100_send
            // 
            this.if100_send.Enabled = false;
            this.if100_send.Location = new System.Drawing.Point(486, 384);
            this.if100_send.Name = "if100_send";
            this.if100_send.Size = new System.Drawing.Size(75, 23);
            this.if100_send.TabIndex = 14;
            this.if100_send.Text = "Send";
            this.if100_send.UseVisualStyleBackColor = true;
            this.if100_send.Click += new System.EventHandler(this.if100_send_Click);
            // 
            // sps101_send
            // 
            this.sps101_send.Enabled = false;
            this.sps101_send.Location = new System.Drawing.Point(842, 385);
            this.sps101_send.Name = "sps101_send";
            this.sps101_send.Size = new System.Drawing.Size(75, 23);
            this.sps101_send.TabIndex = 15;
            this.sps101_send.Text = "Send";
            this.sps101_send.UseVisualStyleBackColor = true;
            this.sps101_send.Click += new System.EventHandler(this.sps101_send_Click);
            // 
            // if100_message
            // 
            this.if100_message.Location = new System.Drawing.Point(281, 387);
            this.if100_message.Name = "if100_message";
            this.if100_message.Size = new System.Drawing.Size(199, 20);
            this.if100_message.TabIndex = 16;
            // 
            // sps101_message
            // 
            this.sps101_message.Location = new System.Drawing.Point(637, 387);
            this.sps101_message.Name = "sps101_message";
            this.sps101_message.Size = new System.Drawing.Size(199, 20);
            this.sps101_message.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Activities";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(944, 519);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sps101_message);
            this.Controls.Add(this.if100_message);
            this.Controls.Add(this.sps101_send);
            this.Controls.Add(this.if100_send);
            this.Controls.Add(this.sps101_logs);
            this.Controls.Add(this.if100_logs);
            this.Controls.Add(this.sps101_subscribe);
            this.Controls.Add(this.if100_subscribe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.user_status);
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
        private System.Windows.Forms.RichTextBox user_status;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button if100_subscribe;
        private System.Windows.Forms.Button sps101_subscribe;
        private System.Windows.Forms.RichTextBox if100_logs;
        private System.Windows.Forms.RichTextBox sps101_logs;
        private System.Windows.Forms.Button if100_send;
        private System.Windows.Forms.Button sps101_send;
        private System.Windows.Forms.TextBox if100_message;
        private System.Windows.Forms.TextBox sps101_message;
        private System.Windows.Forms.Label label6;
    }
}

