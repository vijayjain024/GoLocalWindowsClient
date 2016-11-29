namespace WindowsFormsApplication1
{
    partial class GoLocalWindowsClient
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
            this.login = new System.Windows.Forms.Button();
            this.userinput = new System.Windows.Forms.TextBox();
            this.userlabel = new System.Windows.Forms.Label();
            this.post = new System.Windows.Forms.Button();
            this.desclbl = new System.Windows.Forms.Button();
            this.homepagelogo = new System.Windows.Forms.PictureBox();
            this.applogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.homepagelogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applogo)).BeginInit();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(286, 313);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 27);
            this.login.TabIndex = 0;
            this.login.Text = "Proceed";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // userinput
            // 
            this.userinput.Location = new System.Drawing.Point(312, 269);
            this.userinput.Name = "userinput";
            this.userinput.Size = new System.Drawing.Size(100, 22);
            this.userinput.TabIndex = 2;
            // 
            // userlabel
            // 
            this.userlabel.AutoSize = true;
            this.userlabel.Location = new System.Drawing.Point(249, 272);
            this.userlabel.Name = "userlabel";
            this.userlabel.Size = new System.Drawing.Size(63, 17);
            this.userlabel.TabIndex = 5;
            this.userlabel.Text = "Email ID:";
            this.userlabel.Click += new System.EventHandler(this.userlabel_Click);
            // 
            // post
            // 
            this.post.AutoSize = true;
            this.post.BackColor = System.Drawing.SystemColors.HotTrack;
            this.post.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.post.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.post.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.post.Location = new System.Drawing.Point(619, 12);
            this.post.Name = "post";
            this.post.Size = new System.Drawing.Size(126, 36);
            this.post.TabIndex = 7;
            this.post.Text = "POST NEWS";
            this.post.UseVisualStyleBackColor = false;
            this.post.Visible = false;
            this.post.Click += new System.EventHandler(this.post_Click);
            // 
            // desclbl
            // 
            this.desclbl.Location = new System.Drawing.Point(222, 222);
            this.desclbl.Name = "desclbl";
            this.desclbl.Size = new System.Drawing.Size(255, 30);
            this.desclbl.TabIndex = 9;
            this.desclbl.Text = "Please enter an api key to continue";
            this.desclbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.desclbl.UseVisualStyleBackColor = true;
            // 
            // homepagelogo
            // 
            this.homepagelogo.Image = global::WindowsFormsApplication1.Properties.Resources.logo;
            this.homepagelogo.Location = new System.Drawing.Point(175, 4);
            this.homepagelogo.Name = "homepagelogo";
            this.homepagelogo.Size = new System.Drawing.Size(351, 212);
            this.homepagelogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.homepagelogo.TabIndex = 10;
            this.homepagelogo.TabStop = false;
            // 
            // applogo
            // 
            this.applogo.Image = global::WindowsFormsApplication1.Properties.Resources.logo;
            this.applogo.Location = new System.Drawing.Point(1, 4);
            this.applogo.Name = "applogo";
            this.applogo.Size = new System.Drawing.Size(146, 78);
            this.applogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.applogo.TabIndex = 11;
            this.applogo.TabStop = false;
            this.applogo.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = " © 2016 Debayan Basu, Sushant Karnik, Vijay Jain";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(327, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = " © 2016 Debayan Basu, Sushant Karnik, Vijay Jain";
            // 
            // GoLocalWindowsClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(780, 430);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.applogo);
            this.Controls.Add(this.homepagelogo);
            this.Controls.Add(this.desclbl);
            this.Controls.Add(this.post);
            this.Controls.Add(this.userlabel);
            this.Controls.Add(this.userinput);
            this.Controls.Add(this.login);
            this.Name = "GoLocalWindowsClient";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.homepagelogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login;
        private System.Windows.Forms.TextBox userinput;
        private System.Windows.Forms.Label userlabel;
        private System.Windows.Forms.Button post;
        private System.Windows.Forms.Button desclbl;
        private System.Windows.Forms.PictureBox homepagelogo;
        private System.Windows.Forms.PictureBox applogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

