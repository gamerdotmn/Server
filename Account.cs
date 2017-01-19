using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Server
{
    public partial class Account : Form
    {
        public bool ok = false;

        public Account()
        {
            InitializeComponent();
            textBox_email.Focus();
        }

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void DoLogin()
        {
            if (textBox_email.Text.Length > 0 && textBox_license.Text.Length > 0)
            {
                if (IsValidEmail(textBox_email.Text))
                {
                    button_save.Enabled = false;
                    try
                    {
                        Program.log.Info("Login, " + textBox_email.Text);
                        WebClient wc = new WebClient();
                        string result = wc.DownloadString("http://" + Program.host + "/api/login.php?email=" + System.Uri.EscapeDataString(textBox_email.Text) + "&license=" + System.Uri.EscapeDataString(textBox_license.Text));
                        JObject resulto = JObject.Parse(result);
                        int code = (int)resulto["code"];
                        if (code == 1)
                        {
                            string name = (string)resulto["name"];
                            string email = (string)resulto["email"];
                            string phone = (string)resulto["phone"];
                            string license = (string)resulto["license"];
                            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
                            {
                                config c = new config();
                                c.org_id = license;
                                c.org_email = email;
                                c.org_name = name;
                                c.org_phone = phone;
                                dcm.configs.InsertOnSubmit(c);
                                dcm.SubmitChanges();
                                this.ok = true;
                                this.Close();
                            }
                        }
                        else
                        {
                            label_error.Settext("Мэдээлэл буруу байна.");
                        }
                    }
                    catch(Exception ex)
                    {
                        Program.log.Error(ex);
                        label_error.Settext("Интернет холболтоо шалгана уу.");
                    }
                    button_save.Enabled = true;
                }
                else
                {
                    label_error.Settext("Мэйл хаяг буруу байна.");
                }
            }
            else
            {
                label_error.Settext("Бүх талбарыг бөгөлнө үү.");
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            DoLogin();
        }
        
        private void button_register_Click(object sender, EventArgs e)
        {
            if (textBox_remail.Text.Length > 0 && textBox_rname.Text.Length > 0 && textBox_rphone.Text.Length > 0)
            {
                if (IsValidEmail(textBox_remail.Text))
                {
                    button_register.Enabled = false;
                    try
                    {
                        Program.log.Info("Register, " + textBox_remail.Text);
                        WebClient wc = new WebClient();
                        string result = wc.DownloadString("http://" + Program.host + "/api/check.php?email=" + System.Uri.EscapeDataString(textBox_remail.Text));
                        if (result == "1")
                        {
                            result = wc.DownloadString("http://" + Program.host + "/api/register.php?email=" + System.Uri.EscapeDataString(textBox_remail.Text) + "&phone=" + System.Uri.EscapeDataString(textBox_rphone.Text) + "&name=" + System.Uri.EscapeDataString(textBox_rname.Text));
                            textBox_email.Text = textBox_remail.Text;
                            textBox_license.Text = result;
                            textBox_remail.Text = textBox_rname.Text = textBox_rphone.Text = "";
                            tabControl.SelectedIndex = 0;
                            button_save.Focus();
                            label_error.Settext("");
                        }
                        else
                        {
                            label_rerror.Settext("Мэйл хаяг бүртгэлтэй байна.");
                        }
                    }
                    catch(Exception ex)
                    {
                        Program.log.Error(ex);
                        label_rerror.Settext("Интернет холболтоо шалгана уу.");
                    }
                    button_register.Enabled = true;
                }
                else
                {
                    label_rerror.Settext("Мэйл хаяг буруу байна.");
                }
            }
            else
            {
                label_rerror.Settext("Бүх талбарыг бөгөлнө үү.");
            }
        }

        private void button_femail_Click(object sender, EventArgs e)
        {
            if (textBox_femail.Text.Length > 0)
            {
                if (IsValidEmail(textBox_femail.Text))
                {
                    button_femail.Enabled = false;
                    try
                    {
                        Program.log.Info("Forget, " + textBox_femail.Text);
                        WebClient wc = new WebClient();
                        string result = wc.DownloadString("http://" + Program.host + "/api/forget.php?email=" + System.Uri.EscapeDataString(textBox_femail.Text));
                        if (result == "1")
                        {
                            textBox_email.Text = textBox_femail.Text;
                            tabControl.SelectedIndex = 0;
                            textBox_license.Focus();
                            label_ferror.Settext("");
                        }
                        else
                        {
                            label_ferror.Settext("Мэдээлэл буруу байна.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Program.log.Error(ex);
                        label_ferror.Settext("Интернет холболтоо шалгана уу.");
                    }
                    button_femail.Enabled = true;
                }
                else
                {
                    label_ferror.Settext("Мэйл хаяг буруу байна.");
                }
            }
            else
            {
                label_ferror.Settext("Бүх талбарыг бөгөлнө үү.");
            }
        }

        private void linkLabel_recover_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void textBox_license_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoLogin();
            }
        }
    }
}
