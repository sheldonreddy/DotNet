namespace DIGNOSTransactionManagerMonitor_GetTeleParams
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
            this.cellTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.APIIDTB = new System.Windows.Forms.TextBox();
            this.APIHashTB = new System.Windows.Forms.TextBox();
            this.AuthClientBTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AuthCodeTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ChannelNameTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ProcessBTN = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AuthClntBTN = new System.Windows.Forms.Button();
            this.ConnectTB = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cellTB
            // 
            this.cellTB.Location = new System.Drawing.Point(150, 26);
            this.cellTB.Name = "cellTB";
            this.cellTB.Size = new System.Drawing.Size(184, 20);
            this.cellTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cell Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "API_ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "API_Hash";
            // 
            // APIIDTB
            // 
            this.APIIDTB.Location = new System.Drawing.Point(150, 52);
            this.APIIDTB.Name = "APIIDTB";
            this.APIIDTB.Size = new System.Drawing.Size(184, 20);
            this.APIIDTB.TabIndex = 6;
            // 
            // APIHashTB
            // 
            this.APIHashTB.Location = new System.Drawing.Point(150, 78);
            this.APIHashTB.Name = "APIHashTB";
            this.APIHashTB.Size = new System.Drawing.Size(184, 20);
            this.APIHashTB.TabIndex = 7;
            // 
            // AuthClientBTN
            // 
            this.AuthClientBTN.Location = new System.Drawing.Point(26, 113);
            this.AuthClientBTN.Name = "AuthClientBTN";
            this.AuthClientBTN.Size = new System.Drawing.Size(164, 23);
            this.AuthClientBTN.TabIndex = 9;
            this.AuthClientBTN.Text = "Request Authentication Code";
            this.AuthClientBTN.UseVisualStyleBackColor = true;
            this.AuthClientBTN.Click += new System.EventHandler(this.AuthClientBTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ConnectTB);
            this.groupBox1.Controls.Add(this.AuthClientBTN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cellTB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.APIHashTB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.APIIDTB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 153);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Configuration";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChannelNameTB);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ProcessBTN);
            this.groupBox2.Location = new System.Drawing.Point(12, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 104);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Channel Parameters";
            // 
            // AuthCodeTB
            // 
            this.AuthCodeTB.Location = new System.Drawing.Point(149, 29);
            this.AuthCodeTB.Name = "AuthCodeTB";
            this.AuthCodeTB.Size = new System.Drawing.Size(184, 20);
            this.AuthCodeTB.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Authentication Code";
            // 
            // ChannelNameTB
            // 
            this.ChannelNameTB.Location = new System.Drawing.Point(149, 27);
            this.ChannelNameTB.Name = "ChannelNameTB";
            this.ChannelNameTB.Size = new System.Drawing.Size(184, 20);
            this.ChannelNameTB.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Channel Name";
            // 
            // ProcessBTN
            // 
            this.ProcessBTN.Location = new System.Drawing.Point(119, 63);
            this.ProcessBTN.Name = "ProcessBTN";
            this.ProcessBTN.Size = new System.Drawing.Size(126, 23);
            this.ProcessBTN.TabIndex = 16;
            this.ProcessBTN.Text = "Send Test Message";
            this.ProcessBTN.UseVisualStyleBackColor = true;
            this.ProcessBTN.Click += new System.EventHandler(this.ProcessBTN_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AuthClntBTN);
            this.groupBox3.Controls.Add(this.AuthCodeTB);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(13, 171);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(358, 113);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Client Authentication";
            // 
            // AuthClntBTN
            // 
            this.AuthClntBTN.Location = new System.Drawing.Point(118, 73);
            this.AuthClntBTN.Name = "AuthClntBTN";
            this.AuthClntBTN.Size = new System.Drawing.Size(126, 23);
            this.AuthClntBTN.TabIndex = 10;
            this.AuthClntBTN.Text = "Authenticate Client";
            this.AuthClntBTN.UseVisualStyleBackColor = true;
            this.AuthClntBTN.Click += new System.EventHandler(this.AuthClntBTN_Click);
            // 
            // ConnectTB
            // 
            this.ConnectTB.Location = new System.Drawing.Point(233, 113);
            this.ConnectTB.Name = "ConnectTB";
            this.ConnectTB.Size = new System.Drawing.Size(101, 23);
            this.ConnectTB.TabIndex = 10;
            this.ConnectTB.Text = "Connect";
            this.ConnectTB.UseVisualStyleBackColor = true;
            this.ConnectTB.Click += new System.EventHandler(this.ConnectTB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 403);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form1";
            this.Text = "Telegram Session Parameters";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox cellTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox APIIDTB;
        private System.Windows.Forms.TextBox APIHashTB;
        private System.Windows.Forms.Button AuthClientBTN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ChannelNameTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ProcessBTN;
        private System.Windows.Forms.TextBox AuthCodeTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button AuthClntBTN;
        private System.Windows.Forms.Button ConnectTB;
    }
}

