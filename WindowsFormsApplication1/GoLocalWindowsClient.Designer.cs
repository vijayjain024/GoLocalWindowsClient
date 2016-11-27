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
            this.passinput = new System.Windows.Forms.TextBox();
            this.userlabel = new System.Windows.Forms.Label();
            this.passlabel = new System.Windows.Forms.Label();
            this.post = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(133, 138);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 23);
            this.login.TabIndex = 0;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // userinput
            // 
            this.userinput.Location = new System.Drawing.Point(272, 35);
            this.userinput.Name = "userinput";
            this.userinput.Size = new System.Drawing.Size(100, 22);
            this.userinput.TabIndex = 2;
            // 
            // passinput
            // 
            this.passinput.Location = new System.Drawing.Point(272, 84);
            this.passinput.Name = "passinput";
            this.passinput.Size = new System.Drawing.Size(100, 22);
            this.passinput.TabIndex = 4;
            // 
            // userlabel
            // 
            this.userlabel.AutoSize = true;
            this.userlabel.Location = new System.Drawing.Point(130, 40);
            this.userlabel.Name = "userlabel";
            this.userlabel.Size = new System.Drawing.Size(75, 17);
            this.userlabel.TabIndex = 5;
            this.userlabel.Text = "UserName";
            // 
            // passlabel
            // 
            this.passlabel.AutoSize = true;
            this.passlabel.Location = new System.Drawing.Point(130, 89);
            this.passlabel.Name = "passlabel";
            this.passlabel.Size = new System.Drawing.Size(69, 17);
            this.passlabel.TabIndex = 6;
            this.passlabel.Text = "Password";
            this.passlabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // post
            // 
            this.post.Location = new System.Drawing.Point(28, 12);
            this.post.Name = "post";
            this.post.Size = new System.Drawing.Size(75, 23);
            this.post.TabIndex = 7;
            this.post.Text = "Post";
            this.post.UseVisualStyleBackColor = true;
            this.post.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 430);
            this.Controls.Add(this.post);
            this.Controls.Add(this.passlabel);
            this.Controls.Add(this.userlabel);
            this.Controls.Add(this.passinput);
            this.Controls.Add(this.userinput);
            this.Controls.Add(this.login);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login;
        private System.Windows.Forms.TextBox userinput;
        private System.Windows.Forms.TextBox passinput;
        private System.Windows.Forms.Label userlabel;
        private System.Windows.Forms.Label passlabel;
        private System.Windows.Forms.Button post;
    }
}

