namespace Server
{
    partial class Account
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Account));
            this.label_email = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label_license = new System.Windows.Forms.Label();
            this.textBox_license = new System.Windows.Forms.TextBox();
            this.linkLabel_recover = new System.Windows.Forms.LinkLabel();
            this.button_save = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_login = new System.Windows.Forms.TabPage();
            this.tabPage_register = new System.Windows.Forms.TabPage();
            this.button_register = new System.Windows.Forms.Button();
            this.textBox_rphone = new System.Windows.Forms.TextBox();
            this.label_phone = new System.Windows.Forms.Label();
            this.textBox_rname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_remail = new System.Windows.Forms.TextBox();
            this.label_remail = new System.Windows.Forms.Label();
            this.tabPage_recover = new System.Windows.Forms.TabPage();
            this.button_femail = new System.Windows.Forms.Button();
            this.textBox_femail = new System.Windows.Forms.TextBox();
            this.label_femail = new System.Windows.Forms.Label();
            this.label_error = new Monitor.Labelerr();
            this.label_rerror = new Monitor.Labelerr();
            this.label_ferror = new Monitor.Labelerr();
            this.tabControl.SuspendLayout();
            this.tabPage_login.SuspendLayout();
            this.tabPage_register.SuspendLayout();
            this.tabPage_recover.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(30, 30);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(37, 13);
            this.label_email.TabIndex = 0;
            this.label_email.Text = "Мэйл:";
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(33, 46);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(200, 20);
            this.textBox_email.TabIndex = 1;
            // 
            // label_license
            // 
            this.label_license.AutoSize = true;
            this.label_license.Location = new System.Drawing.Point(30, 69);
            this.label_license.Name = "label_license";
            this.label_license.Size = new System.Drawing.Size(83, 13);
            this.label_license.TabIndex = 2;
            this.label_license.Text = "Эрхийн дугаар:";
            // 
            // textBox_license
            // 
            this.textBox_license.Location = new System.Drawing.Point(33, 85);
            this.textBox_license.Name = "textBox_license";
            this.textBox_license.Size = new System.Drawing.Size(200, 20);
            this.textBox_license.TabIndex = 2;
            this.textBox_license.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_license_KeyDown);
            // 
            // linkLabel_recover
            // 
            this.linkLabel_recover.Location = new System.Drawing.Point(33, 137);
            this.linkLabel_recover.Name = "linkLabel_recover";
            this.linkLabel_recover.Size = new System.Drawing.Size(200, 20);
            this.linkLabel_recover.TabIndex = 4;
            this.linkLabel_recover.TabStop = true;
            this.linkLabel_recover.Text = "Сэргээх";
            this.linkLabel_recover.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.linkLabel_recover.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_recover_LinkClicked);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(33, 111);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(200, 23);
            this.button_save.TabIndex = 3;
            this.button_save.Text = "Хадгалах";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_login);
            this.tabControl.Controls.Add(this.tabPage_register);
            this.tabControl.Controls.Add(this.tabPage_recover);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(274, 312);
            this.tabControl.TabIndex = 7;
            // 
            // tabPage_login
            // 
            this.tabPage_login.Controls.Add(this.label_email);
            this.tabPage_login.Controls.Add(this.label_error);
            this.tabPage_login.Controls.Add(this.textBox_email);
            this.tabPage_login.Controls.Add(this.button_save);
            this.tabPage_login.Controls.Add(this.label_license);
            this.tabPage_login.Controls.Add(this.linkLabel_recover);
            this.tabPage_login.Controls.Add(this.textBox_license);
            this.tabPage_login.Location = new System.Drawing.Point(4, 22);
            this.tabPage_login.Name = "tabPage_login";
            this.tabPage_login.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_login.Size = new System.Drawing.Size(266, 286);
            this.tabPage_login.TabIndex = 0;
            this.tabPage_login.Text = "Нэвтрэх";
            this.tabPage_login.UseVisualStyleBackColor = true;
            // 
            // tabPage_register
            // 
            this.tabPage_register.Controls.Add(this.label_rerror);
            this.tabPage_register.Controls.Add(this.button_register);
            this.tabPage_register.Controls.Add(this.textBox_rphone);
            this.tabPage_register.Controls.Add(this.label_phone);
            this.tabPage_register.Controls.Add(this.textBox_rname);
            this.tabPage_register.Controls.Add(this.label1);
            this.tabPage_register.Controls.Add(this.textBox_remail);
            this.tabPage_register.Controls.Add(this.label_remail);
            this.tabPage_register.Location = new System.Drawing.Point(4, 22);
            this.tabPage_register.Name = "tabPage_register";
            this.tabPage_register.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_register.Size = new System.Drawing.Size(266, 286);
            this.tabPage_register.TabIndex = 1;
            this.tabPage_register.Text = "Бүртгүүлэх";
            this.tabPage_register.UseVisualStyleBackColor = true;
            // 
            // button_register
            // 
            this.button_register.Location = new System.Drawing.Point(33, 150);
            this.button_register.Name = "button_register";
            this.button_register.Size = new System.Drawing.Size(200, 23);
            this.button_register.TabIndex = 9;
            this.button_register.Text = "Бүртгүүлэх";
            this.button_register.UseVisualStyleBackColor = true;
            this.button_register.Click += new System.EventHandler(this.button_register_Click);
            // 
            // textBox_rphone
            // 
            this.textBox_rphone.Location = new System.Drawing.Point(33, 124);
            this.textBox_rphone.Name = "textBox_rphone";
            this.textBox_rphone.Size = new System.Drawing.Size(200, 20);
            this.textBox_rphone.TabIndex = 8;
            // 
            // label_phone
            // 
            this.label_phone.AutoSize = true;
            this.label_phone.Location = new System.Drawing.Point(30, 108);
            this.label_phone.Name = "label_phone";
            this.label_phone.Size = new System.Drawing.Size(35, 13);
            this.label_phone.TabIndex = 11;
            this.label_phone.Text = "Утас:";
            // 
            // textBox_rname
            // 
            this.textBox_rname.Location = new System.Drawing.Point(33, 85);
            this.textBox_rname.Name = "textBox_rname";
            this.textBox_rname.Size = new System.Drawing.Size(200, 20);
            this.textBox_rname.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Кафе:";
            // 
            // textBox_remail
            // 
            this.textBox_remail.Location = new System.Drawing.Point(33, 46);
            this.textBox_remail.Name = "textBox_remail";
            this.textBox_remail.Size = new System.Drawing.Size(200, 20);
            this.textBox_remail.TabIndex = 6;
            // 
            // label_remail
            // 
            this.label_remail.AutoSize = true;
            this.label_remail.Location = new System.Drawing.Point(30, 30);
            this.label_remail.Name = "label_remail";
            this.label_remail.Size = new System.Drawing.Size(37, 13);
            this.label_remail.TabIndex = 1;
            this.label_remail.Text = "Мэйл:";
            // 
            // tabPage_recover
            // 
            this.tabPage_recover.Controls.Add(this.label_ferror);
            this.tabPage_recover.Controls.Add(this.button_femail);
            this.tabPage_recover.Controls.Add(this.textBox_femail);
            this.tabPage_recover.Controls.Add(this.label_femail);
            this.tabPage_recover.Location = new System.Drawing.Point(4, 22);
            this.tabPage_recover.Name = "tabPage_recover";
            this.tabPage_recover.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_recover.Size = new System.Drawing.Size(266, 286);
            this.tabPage_recover.TabIndex = 2;
            this.tabPage_recover.Text = "Эрх сэргээх";
            this.tabPage_recover.UseVisualStyleBackColor = true;
            // 
            // button_femail
            // 
            this.button_femail.Location = new System.Drawing.Point(33, 72);
            this.button_femail.Name = "button_femail";
            this.button_femail.Size = new System.Drawing.Size(200, 23);
            this.button_femail.TabIndex = 11;
            this.button_femail.Text = "Сэргээх";
            this.button_femail.UseVisualStyleBackColor = true;
            this.button_femail.Click += new System.EventHandler(this.button_femail_Click);
            // 
            // textBox_femail
            // 
            this.textBox_femail.Location = new System.Drawing.Point(33, 46);
            this.textBox_femail.Name = "textBox_femail";
            this.textBox_femail.Size = new System.Drawing.Size(200, 20);
            this.textBox_femail.TabIndex = 10;
            // 
            // label_femail
            // 
            this.label_femail.AutoSize = true;
            this.label_femail.Location = new System.Drawing.Point(30, 30);
            this.label_femail.Name = "label_femail";
            this.label_femail.Size = new System.Drawing.Size(37, 13);
            this.label_femail.TabIndex = 2;
            this.label_femail.Text = "Мэйл:";
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.ForeColor = System.Drawing.Color.Red;
            this.label_error.Location = new System.Drawing.Point(30, 160);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(0, 13);
            this.label_error.TabIndex = 5;
            // 
            // label_rerror
            // 
            this.label_rerror.AutoSize = true;
            this.label_rerror.ForeColor = System.Drawing.Color.Red;
            this.label_rerror.Location = new System.Drawing.Point(30, 176);
            this.label_rerror.Name = "label_rerror";
            this.label_rerror.Size = new System.Drawing.Size(0, 13);
            this.label_rerror.TabIndex = 16;
            // 
            // label_ferror
            // 
            this.label_ferror.AutoSize = true;
            this.label_ferror.ForeColor = System.Drawing.Color.Red;
            this.label_ferror.Location = new System.Drawing.Point(30, 98);
            this.label_ferror.Name = "label_ferror";
            this.label_ferror.Size = new System.Drawing.Size(0, 13);
            this.label_ferror.TabIndex = 20;
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 312);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Account";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MasterCafe бүртгэл";
            this.tabControl.ResumeLayout(false);
            this.tabPage_login.ResumeLayout(false);
            this.tabPage_login.PerformLayout();
            this.tabPage_register.ResumeLayout(false);
            this.tabPage_register.PerformLayout();
            this.tabPage_recover.ResumeLayout(false);
            this.tabPage_recover.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label_license;
        private System.Windows.Forms.TextBox textBox_license;
        private System.Windows.Forms.LinkLabel linkLabel_recover;
        private System.Windows.Forms.Button button_save;
        private Monitor.Labelerr label_error;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_login;
        private System.Windows.Forms.TabPage tabPage_register;
        private System.Windows.Forms.Label label_remail;
        private System.Windows.Forms.TextBox textBox_remail;
        private System.Windows.Forms.TextBox textBox_rname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_register;
        private System.Windows.Forms.TextBox textBox_rphone;
        private System.Windows.Forms.Label label_phone;
        private Monitor.Labelerr label_rerror;
        private System.Windows.Forms.TabPage tabPage_recover;
        private System.Windows.Forms.Label label_femail;
        private System.Windows.Forms.TextBox textBox_femail;
        private System.Windows.Forms.Button button_femail;
        private Monitor.Labelerr label_ferror;
    }
}