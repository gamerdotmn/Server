namespace Server
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label_email = new System.Windows.Forms.Label();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.label_license = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.labelerr = new Monitor.Labelerr();
            this.SuspendLayout();
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(30, 30);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(106, 13);
            this.label_email.TabIndex = 1;
            this.label_email.Text = "Удирдах хэрэглэгч:";
            // 
            // textBox_user
            // 
            this.textBox_user.Location = new System.Drawing.Point(33, 46);
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.ReadOnly = true;
            this.textBox_user.Size = new System.Drawing.Size(200, 20);
            this.textBox_user.TabIndex = 1;
            this.textBox_user.TabStop = false;
            // 
            // label_license
            // 
            this.label_license.AutoSize = true;
            this.label_license.Location = new System.Drawing.Point(30, 69);
            this.label_license.Name = "label_license";
            this.label_license.Size = new System.Drawing.Size(144, 13);
            this.label_license.TabIndex = 3;
            this.label_license.Text = "Удирдах хэрэглэгч нууц үг:";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(33, 85);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(200, 20);
            this.textBox_password.TabIndex = 1;
            this.textBox_password.UseSystemPasswordChar = true;
            this.textBox_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_password_KeyDown);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(33, 111);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(200, 23);
            this.button_save.TabIndex = 2;
            this.button_save.Text = "Нэвтрэх";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // labelerr
            // 
            this.labelerr.AutoSize = true;
            this.labelerr.ForeColor = System.Drawing.Color.Red;
            this.labelerr.Location = new System.Drawing.Point(30, 137);
            this.labelerr.Name = "labelerr";
            this.labelerr.Size = new System.Drawing.Size(0, 13);
            this.labelerr.TabIndex = 4;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 182);
            this.Controls.Add(this.labelerr);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label_license);
            this.Controls.Add(this.textBox_user);
            this.Controls.Add(this.label_email);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Нэвтрэх";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.Label label_license;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Button button_save;
        private Monitor.Labelerr labelerr;
    }
}