namespace processlogger
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.l1 = new System.Windows.Forms.ListView();
            this.b1 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l1
            // 
            this.l1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l1.Location = new System.Drawing.Point(3, 32);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(671, 546);
            this.l1.TabIndex = 1;
            this.l1.UseCompatibleStateImageBehavior = false;
            this.l1.SelectedIndexChanged += new System.EventHandler(this.l1_SelectedIndexChanged);
            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(3, 3);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(27, 23);
            this.b1.TabIndex = 3;
            this.b1.Text = "button1";
            this.b1.UseVisualStyleBackColor = true;
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(36, 3);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(27, 23);
            this.b2.TabIndex = 4;
            this.b2.Text = "button2";
            this.b2.UseVisualStyleBackColor = true;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.b2);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.l1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(677, 581);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView l1;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b2;
    }
}
