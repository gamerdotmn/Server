namespace Server
{
    partial class Serverfrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Serverfrm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_backup = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_restore = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_close = new System.Windows.Forms.ToolStripMenuItem();
            this.userControl_monitor = new Server.UserControl_monitor();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "MasterCafe";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_backup,
            this.menu_restore,
            this.menu_close});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip.Size = new System.Drawing.Size(207, 70);
            // 
            // menu_backup
            // 
            this.menu_backup.Name = "menu_backup";
            this.menu_backup.Size = new System.Drawing.Size(206, 22);
            this.menu_backup.Text = "Өгөгдлийн сан нөөцлөх";
            this.menu_backup.Click += new System.EventHandler(this.menu_backupclick);
            // 
            // menu_restore
            // 
            this.menu_restore.Name = "menu_restore";
            this.menu_restore.Size = new System.Drawing.Size(206, 22);
            this.menu_restore.Text = "Өгөгдлийн сан сэргээх";
            this.menu_restore.Click += new System.EventHandler(this.menu_restoreclick);
            // 
            // menu_close
            // 
            this.menu_close.Name = "menu_close";
            this.menu_close.Size = new System.Drawing.Size(206, 22);
            this.menu_close.Text = "Хаах";
            this.menu_close.Click += new System.EventHandler(this.menu_closeclick);
            // 
            // userControl_monitor
            // 
            this.userControl_monitor.BackColor = System.Drawing.Color.Black;
            this.userControl_monitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_monitor.ForeColor = System.Drawing.Color.Black;
            this.userControl_monitor.Location = new System.Drawing.Point(0, 0);
            this.userControl_monitor.Name = "userControl_monitor";
            this.userControl_monitor.Size = new System.Drawing.Size(542, 516);
            this.userControl_monitor.TabIndex = 1;
            // 
            // Serverfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(542, 516);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.userControl_monitor);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Serverfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MasterCafe Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Serverfrm_FormClosing);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menu_close;
        private UserControl_monitor userControl_monitor;
        private System.Windows.Forms.ToolStripMenuItem menu_backup;
        private System.Windows.Forms.ToolStripMenuItem menu_restore;
    }
}