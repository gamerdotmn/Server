using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Login : Form
    {
        public bool ok = false;

        public Login()
        {
            InitializeComponent();
            textBox_user.Text = Serverfrm.cfg.client_user;
            textBox_password.Focus();
        }

        private void DoLogin()
        {
            if (textBox_password.Text == Serverfrm.cfg.client_password)
            {
                ok = true;
                this.Close();
            }
            else
            {
                textBox_password.Text = "";
                textBox_password.Focus();
                labelerr.Settext("Та хандах эрхгүй байна.");
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private void textBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoLogin();
            }
        }
    }
}
