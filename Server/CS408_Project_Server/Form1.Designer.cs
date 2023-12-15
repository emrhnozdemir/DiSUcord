namespace CS408_Project_Server
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
            this.log_activities = new System.Windows.Forms.RichTextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_listen = new System.Windows.Forms.Button();
            this.connected_list = new System.Windows.Forms.ListBox();
            this.if100_list = new System.Windows.Forms.ListBox();
            this.sps101_list = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Connected Clients";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(593, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Subscribed Clients to Channel IF 100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(841, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Subscribed Clients to Channel SPS 101";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Activities";
            // 
            // log_activities
            // 
            this.log_activities.Location = new System.Drawing.Point(19, 96);
            this.log_activities.Name = "log_activities";
            this.log_activities.Size = new System.Drawing.Size(282, 325);
            this.log_activities.TabIndex = 7;
            this.log_activities.Text = "";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(71, 30);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(128, 20);
            this.textBox_port.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Port:";
            // 
            // button_listen
            // 
            this.button_listen.Location = new System.Drawing.Point(217, 28);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(75, 23);
            this.button_listen.TabIndex = 10;
            this.button_listen.Text = "Listen";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // connected_list
            // 
            this.connected_list.FormattingEnabled = true;
            this.connected_list.Location = new System.Drawing.Point(355, 96);
            this.connected_list.Name = "connected_list";
            this.connected_list.Size = new System.Drawing.Size(153, 329);
            this.connected_list.TabIndex = 11;
            // 
            // if100_list
            // 
            this.if100_list.FormattingEnabled = true;
            this.if100_list.Location = new System.Drawing.Point(596, 96);
            this.if100_list.Name = "if100_list";
            this.if100_list.Size = new System.Drawing.Size(153, 329);
            this.if100_list.TabIndex = 12;
            // 
            // sps101_list
            // 
            this.sps101_list.FormattingEnabled = true;
            this.sps101_list.Location = new System.Drawing.Point(844, 96);
            this.sps101_list.Name = "sps101_list";
            this.sps101_list.Size = new System.Drawing.Size(153, 329);
            this.sps101_list.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 495);
            this.Controls.Add(this.sps101_list);
            this.Controls.Add(this.if100_list);
            this.Controls.Add(this.connected_list);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.log_activities);
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
        private System.Windows.Forms.RichTextBox log_activities;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_listen;
        private System.Windows.Forms.ListBox connected_list;
        private System.Windows.Forms.ListBox if100_list;
        private System.Windows.Forms.ListBox sps101_list;
    }
}

