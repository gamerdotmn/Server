using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Xml;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Web;
using System.Globalization;
using System.Diagnostics;
using Microsoft.Win32;
using System.Data.Linq;
using System.Linq;
using System.Data.SqlClient;
using System.Reflection;
using System.Resources;

namespace Server
{
    public partial class Serverfrm : Form
    {
        public const int dissecond = 10;
        public static int sentbytes = 0;
        public static int recivedbytes = 0;
        private System.Timers.Timer client_timer;
        private System.Timers.Timer monitor_timer;
        private System.Timers.Timer broadcast_timer;
        private System.Timers.Timer speed_timer;
        private Hashtable clients = new Hashtable();
        private Hashtable clients_packets = new Hashtable();
        private Hashtable monitors = new Hashtable();
        private Hashtable monitors_packets = new Hashtable();
        public static config cfg = new config();
        public static gconfig gcfg = new gconfig();
        public const string host = "gamer.mn";

        public Serverfrm()
        {
            Thread.Sleep(1000);
            RegistryKey register = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MCSERVER", true);
            if (register == null)
            {
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\MCSERVER\\");
                register = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MCSERVER", true);
            }
            register.Close();
            try
            {
                UdpClient listener1 = new UdpClient(Program.port_clienttoserver);
                listener1.Close();
                UdpClient listener2 = new UdpClient(Program.port_monitortoserver);
                listener2.Close();
                Program.log.Info("Ports are not using.");
            }
            catch(Exception ex)
            {
                Program.log.Error(ex);
                System.Environment.Exit(0);
            }
                        
            bool co=false;
            int trycnt = 0;
            do
            {
                using (SqlConnection sqlcon = new SqlConnection(Program.constr))
                {
                    try
                    {
                        sqlcon.Open();
                        sqlcon.Close();
                        co = true;
                    }
                    catch(Exception ex)
                    {
                        Program.log.Error(ex);
                        trycnt++;
                    }
                }
                if (trycnt == 180)
                {
                    co = true;
                }
                Thread.Sleep(1000);
                Program.log.Info("Try connecting to SQL. Sec("+trycnt+")");
            }
            while (co == false);
            if (trycnt == 180)
            {
                Program.log.Error("SQL problem.");
                MessageBox.Show("Өгөгдлийн сангийн алдаа","Анхаар", MessageBoxButtons.OK);
                System.Environment.Exit(0);
            }
            try
            {
                Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\\",true).SetValue("MastercafeServer", Application.StartupPath + "\\Server.exe");
            }
            catch(Exception ex)
            {
                Program.log.Error(ex);
            }
            
            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
            {
                if (dcm.configs.Count() == 0)
                {
                    Account login = new Account();
                    login.ShowDialog(this);
                    if (login.ok == false)
                    {
                        System.Environment.Exit(0);
                    }
                }
                Program.log.Info("Config count, "+dcm.configs.Count());
                if (dcm.configs.Count() > 0)
                {
                    if (dcm.groups.Count() == 0)
                    {
                        group g = new group();
                        g.hour = true;
                        g.hourprice = 600;
                        g.id = Guid.NewGuid();
                        g.member = true;
                        g.memberprice = 600;
                        g.minprice = 100;
                        g.name = "Заал";
                        g.prepairhour = true;
                        g.timecode = true;
                        g.timecodeprice = 600;
                        g.vip = false;
                        dcm.groups.InsertOnSubmit(g);
                        dcm.SubmitChanges();
                    }
                    if (dcm.categories.Count() == 0)
                    {
                        category c1 = new category();
                        c1.id = Guid.NewGuid();
                        c1.name = "Ундаа";
                        dcm.categories.InsertOnSubmit(c1);

                        category c2 = new category();
                        c2.id = Guid.NewGuid();
                        c2.name = "Түргэн хоол";
                        dcm.categories.InsertOnSubmit(c2);

                        dcm.SubmitChanges();

                        item i1 = new item();
                        i1.id = Guid.NewGuid();
                        i1.name = "Кола";
                        i1.category_id = c1.id;
                        i1.price = 100;
                        dcm.items.InsertOnSubmit(i1);

                        item i2 = new item();
                        i2.id = Guid.NewGuid();
                        i2.name = "Бургер";
                        i2.category_id = c2.id;
                        i2.price = 100;
                        dcm.items.InsertOnSubmit(i2);

                        dcm.SubmitChanges();
                    }
                    if (dcm.employees.Count() == 0)
                    {
                        employee emp = new employee();
                        emp.name = "admin";
                        emp.password = "mastercafe";
                        emp.isadmin = true;
                        dcm.employees.InsertOnSubmit(emp);

                        dcm.SubmitChanges();
                    }
                    
                    cfg.org_id = dcm.configs.FirstOrDefault().org_id;
                    cfg.org_email = dcm.configs.FirstOrDefault().org_email;
                    cfg.org_name = dcm.configs.FirstOrDefault().org_name;
                    cfg.org_phone = dcm.configs.FirstOrDefault().org_phone;
                    cfg.newmember_price = dcm.configs.FirstOrDefault().newmember_price;
                    cfg.newmember_stock = dcm.configs.FirstOrDefault().newmember_stock;
                    cfg.close_hour = dcm.configs.FirstOrDefault().close_hour;
                    cfg.alert_minute = dcm.configs.FirstOrDefault().alert_minute;
                    cfg.alert_message = dcm.configs.FirstOrDefault().alert_message;
                    cfg.idle_minute = dcm.configs.FirstOrDefault().idle_minute;
                    bool saveit = false;
                    if (cfg.newmember_price == null)
                    {
                        dcm.configs.FirstOrDefault().newmember_price=cfg.newmember_price = 5000;
                        saveit = true;
                    }
                    if (cfg.newmember_stock == null)
                    {
                        dcm.configs.FirstOrDefault().newmember_stock=cfg.newmember_stock = 600;
                        saveit = true;
                    }
                    if (cfg.close_hour == null)
                    {
                        dcm.configs.FirstOrDefault().close_hour=cfg.close_hour = 9;
                        saveit = true;
                    }
                    if (cfg.alert_minute == null)
                    {
                        dcm.configs.FirstOrDefault().alert_minute=cfg.alert_minute = 5;
                        saveit = true;
                    }
                    if (cfg.alert_message == null)
                    {
                        dcm.configs.FirstOrDefault().alert_message=cfg.alert_message = "Таны цаг дуусах гэж байна.";
                        saveit = true;
                    }
                    if (cfg.idle_minute == null)
                    {
                        dcm.configs.FirstOrDefault().idle_minute=cfg.idle_minute = 5;
                        saveit = true;
                    }
                    if (saveit == true)
                    {
                        dcm.SubmitChanges();
                    }
                }

                foreach (client cli in dcm.clients)
                {
                    if (cli.status==1)
                    {
                        cli.status = 0;
                    }
                    if (cli.status == 2)
                    {
                        cli.status = 0;
                    }
                    if (cli.status == 3)
                    {
                        cli.status = 0;
                        int usedmoney=(cli.group.memberprice / 60) * (int)cli.usedminute;
                        cli.member.money = cli.member.money - usedmoney;
                        if (cli.member.money < 1)
                        {
                            cli.member.money = 0;
                        }
                        cli.member = null;
                        cli.usedminute = null;
                        cli.remainminute = null;
                        cli.start = null;
                        cli.tc = null;
                        cli.ht = null;
                    }
                    if (cli.status == 4)
                    {
                        cli.status = 0;
                        int usedmoney = (cli.group.timecodeprice / 60) * (int)cli.usedminute;
                        cli.timecode.money = cli.timecode.money - usedmoney;
                        if (cli.timecode.money < 1)
                        {
                            cli.timecode.money = 0;
                        }
                        cli.member = null;
                        cli.usedminute = null;
                        cli.remainminute = null;
                        cli.start = null;
                        cli.timecode = null;
                        cli.ht = null;
                    }
                    if (cli.status == 5)
                    {
                        cli.status = 6;
                    }
                    if (cli.status == 7)
                    {
                        cli.status = 8;
                    }
                }
                dcm.SubmitChanges();
            }

            InitializeComponent();
            status();
            Task.Factory.StartNew(() => client_listen());
            Task.Factory.StartNew(() => monitor_listen());
            broadcast_timer = new System.Timers.Timer(1000);
            broadcast_timer.Elapsed +=new ElapsedEventHandler(broadcast_timerealpsed);
            broadcast_timer.Start();
            client_timer = new System.Timers.Timer(1000);
            client_timer.Elapsed += new ElapsedEventHandler(client_timerelapsed);
            client_timer.Start();
            monitor_timer = new System.Timers.Timer(1000);
            monitor_timer.Elapsed += new ElapsedEventHandler(monitor_timerelapsed);
            monitor_timer.Start();
            speed_timer = new System.Timers.Timer(180000);
            speed_timer.Elapsed += new ElapsedEventHandler(speed_timerelapsed);
            speed_timer.Start();
            Task.Factory.StartNew(() => speedtest());
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipText = "Сервер амжилттай эхэлсэн.";
            notifyIcon.BalloonTipTitle = "MasterCafe";
            notifyIcon.ShowBalloonTip(50);
        }

        
        private void client_connect(PacketClientServerSyn packet,string ip)
        {
            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
            {
                int cnt = (from c in dcm.clients where c.name == packet.name select true).Count();
                if (cnt == 0)
                {
                    client cl = new client();
                    cl.app = packet.app;
                    cl.group_id = dcm.groups.FirstOrDefault().id;
                    cl.ht = packet.ht;
                    cl.ip = ip;
                    cl.mac = packet.mac;
                    cl.member_name = packet.member_name;
                    cl.name = packet.name;
                    if (packet.remainminute == -1)
                    {
                        cl.remainminute = null;
                    }
                    else
                    {
                        cl.remainminute = packet.remainminute;
                    }
                    cl.start = packet.start;
                    cl.status = 1;
                    cl.tc = packet.tc;
                    cl.title = packet.title;
                    if (packet.usedminute == -1)
                    {
                        cl.usedminute = null;
                    }
                    else
                    {
                        cl.usedminute = packet.usedminute;
                    }
                    dcm.clients.InsertOnSubmit(cl);
                    dcm.SubmitChanges();
                }
                else
                {
                    client cl = dcm.clients.Where(_c => _c.name == packet.name).FirstOrDefault();
                    cl.ip = ip;
                    cl.mac = packet.mac;
                    if (packet.status == 2)
                    {
                        cl.status = 2;
                    }
                    else if (cl.status == 6)
                    {

                    }
                    else if (cl.status == 8)
                    {

                    }
                    else if (cl.status == 10)
                    {

                    }
                    else
                    {
                        cl.status = 1;
                    }
                    dcm.SubmitChanges();
                }
            }
            status();
        }

        private void client_status(string ip,XmlDocument xd)
        {
            string name = xd.ChildNodes[0].ChildNodes[1].InnerText;
            string mac = xd.ChildNodes[0].ChildNodes[2].InnerText;
            string member_name = xd.ChildNodes[0].ChildNodes[3].InnerText;
            string usedtime = xd.ChildNodes[0].ChildNodes[4].InnerText;
            string remainminute = xd.ChildNodes[0].ChildNodes[5].InnerText;
            string money = xd.ChildNodes[0].ChildNodes[6].InnerText;
            string startt = xd.ChildNodes[0].ChildNodes[7].InnerText;
            string app = xd.ChildNodes[0].ChildNodes[8].InnerText;
            string title = xd.ChildNodes[0].ChildNodes[9].InnerText;
            string tc = xd.ChildNodes[0].ChildNodes[10].InnerText;
            string ht = xd.ChildNodes[0].ChildNodes[11].InnerText;
            int status = Convert.ToInt32(xd.ChildNodes[0].ChildNodes[12].InnerText);
            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
            {
                client cl = dcm.clients.Where(_c => _c.name == name).FirstOrDefault();
                cl.app = app;
                cl.group_id = dcm.groups.FirstOrDefault().id;
                cl.ht = Guid.Parse(ht);
                cl.ip = ip;
                cl.mac = mac;
                cl.member_name = member_name;
                cl.remainminute = Convert.ToInt32(remainminute);
                cl.start = DateTime.ParseExact(startt, "yyyy.MM.dd HH:mm:ss", null);
                cl.status = status;
                cl.tc = tc;
                cl.title = title;
                cl.usedminute = Convert.ToInt32(usedtime);
                dcm.SubmitChanges();
            }
        }

        private void client_disconnect(string ip)
        {
            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
            {
                client cl = dcm.clients.Where(_c => _c.ip == ip).FirstOrDefault();
                if (cl.status == 1)
                {
                    cl.status = 0;
                    dcm.SubmitChanges();
                }
                if (cl.status == 2)
                {
                    cl.status = 0;
                    cl.member_name = null;
                    cl.usedminute = null;
                    cl.remainminute = null;
                    cl.start = null;
                    cl.tc = null;
                    cl.ht = null;
                    dcm.SubmitChanges();
                }
                if (cl.status == 3)
                {
                    cl.status = 0;
                    int usedmoney = (cl.group.memberprice / 60) * (int)cl.usedminute;
                    cl.member.money = cl.member.money - usedmoney;
                    if (cl.member.money < 1)
                    {
                        cl.member.money = 0;
                    }
                    cl.member = null;
                    cl.usedminute = null;
                    cl.remainminute = null;
                    cl.start = null;
                    cl.tc = null;
                    cl.ht = null;
                    dcm.SubmitChanges();
                }
                if (cl.status == 4)
                {
                    cl.status = 0;
                    int usedmoney = (cl.group.timecodeprice / 60) * (int)cl.usedminute;
                    cl.timecode.money = cl.timecode.money - usedmoney;
                    if (cl.timecode.money < 1)
                    {
                        cl.timecode.money = 0;
                    }
                    cl.member_name = null;
                    cl.usedminute = null;
                    cl.remainminute = null;
                    cl.start = null;
                    cl.timecode = null;
                    cl.ht = null;
                    dcm.SubmitChanges();
                }
                if (cl.status == 5)
                {
                    cl.status = 6;
                    dcm.SubmitChanges();
                }
                if (cl.status == 7)
                {
                    cl.status = 8;
                    dcm.SubmitChanges();
                }
                Program.log.Info(ip + " ,disconnect");
            }
            status();
        }


        private void monitor_syn(string ip)
        {
            if (monitors.ContainsKey(ip))
            {
                monitors[ip] = (int)0;
            }
            else
            {
                monitors.Add(ip, 0);
                monitor_connect(ip);
            }
        }

        private void monitor_management(string ip, string data)
        {
            if (data.Length == 0)
            {
                return;
            }
            ip = ip.Substring(0, ip.IndexOf(":"));
            string cmd = (string)Newtonsoft.Json.Linq.JObject.Parse(data)["command"];
            switch (cmd)
            {
                case "syn": monitor_syn(ip); break;
                default: break;
            }
            
        }

        private void client_syn(PacketClientServerSyn packet,string ip)
        {
            if (clients.ContainsKey(ip))
            {
                clients[ip] = (int)0;
                using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
                {
                    client cl = dcm.clients.Where(_c => _c.name == packet.name).FirstOrDefault();
                    if (cl != null)
                    {
                        cl.app = packet.app;
                        cl.title = packet.title;
                        cl.usedminute = packet.usedminute;
                        cl.remainminute = packet.remainminute;
                        if (packet.status == 2)
                        {
                            cl.status = 2;
                        }
                        if (packet.status == 3)
                        {
                            if (packet.remainminute <= 1)
                            {

                            }
                        }
                        cl.wei = packet.wei;
                        dcm.SubmitChanges();
                    }
                }
            }
            else
            {
                clients.Add(ip, 0);
                Program.log.Info(ip + ",  connect.");
                client_connect(packet, ip);
            }
        }
    
        private void client_init(PacketClientServerInitrequest packetinitrequest,string ip)
        {
            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
            {
                PacketServerClientInit packetinit = new PacketServerClientInit();
                packetinit.clientpassword = dcm.employees.Where(e => e.isadmin == true).FirstOrDefault().password;
                packetinit.clientuser = dcm.employees.Where(e => e.isadmin == true).FirstOrDefault().name;
                packetinit.group = new clientgroup();
                var g=dcm.clients.Where(_c => _c.name == packetinitrequest.name).FirstOrDefault().group;
                    packetinit.group.hour = g.hour;
                    packetinit.group.hourprice = g.hourprice;
                    packetinit.group.id = g.id;
                    packetinit.group.member = g.member;
                    packetinit.group.memberprice = g.memberprice;
                    packetinit.group.minprice = g.minprice;
                    packetinit.group.name = g.name;
                    packetinit.group.prepairhour = g.prepairhour;
                    packetinit.group.timecode = g.timecode;
                    packetinit.group.timecodeprice = g.timecodeprice;
                packetinit.orgid = cfg.org_id;
                packetinit.orgname = cfg.org_name;
                Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packetinit));
                Program.log.Info(ip + " , init.");
            }
        }

        private void client_adminlogout(string ip)
        {
            client_disconnect(ip);
            PacketServerClientAdminLogoutok packet = new PacketServerClientAdminLogoutok();
            Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packet));
        }

        private void client_memberlogin(PacketClientServerMemberLogin packet,string ip)
        {
            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
            {
                var members = from m in dcm.members where m.name.ToLower() == packet.member && m.password.ToLower() == packet.password select new { m.name, m.money };
                if (members.Count() == 1)
                {
                    var clients = from c in dcm.clients where c.member_name == members.FirstOrDefault().name select new { c.name };
                    if (clients.Count() == 0)
                    {
                        client cl = dcm.clients.Where(_c => _c.ip == ip).FirstOrDefault();
                        if (cl.group.member == true)
                        {
                            if (members.FirstOrDefault().money >= cl.group.minprice)
                            {
                                PacketServerClientMemberLoginok packetloginok = new PacketServerClientMemberLoginok();
                                packetloginok.member = members.FirstOrDefault().name;
                                packetloginok.money = members.FirstOrDefault().money;
                                cl.status = 3;
                                cl.member_name = packetloginok.member;
                                cl.usedminute = 0;
                                cl.remainminute = (members.FirstOrDefault().money * 60) / cl.group.memberprice;
                                cl.start = DateTime.Now;
                                cl.tc = null;
                                cl.ht = null;
                                packetloginok.start = DateTime.Now;
                                dcm.SubmitChanges();
                                Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packetloginok));
                            }
                            else
                            {
                                PacketServerClientMemberLoginempty packetempty = new PacketServerClientMemberLoginempty();
                                Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packetempty));
                            }
                        }
                        else
                        {
                            PacketServerClientMemberDisabled packetdisabled = new PacketServerClientMemberDisabled();
                            Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packetdisabled));
                        }
                    }
                    else
                    {
                        PacketServerClientMemberLoginalready packetloginalready = new PacketServerClientMemberLoginalready();
                        packetloginalready.name = clients.FirstOrDefault().name;
                        Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packetloginalready));
                    }
                }
                else
                {
                    PacketServerClientMemberLoginfailed packetloginfailed = new PacketServerClientMemberLoginfailed();
                    Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packetloginfailed));
                }
            }
        }

        private void client_memberlogout(string ip)
        {
            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
            {
                client cl = dcm.clients.Where(_c => _c.ip == ip).FirstOrDefault();
                cl.status = 1;
                int usedmoney = (cl.group.memberprice / 60) * (int)cl.usedminute;
                cl.member.money = cl.member.money - usedmoney;
                if (cl.member.money < 1)
                {
                    cl.member.money = 0;
                }
                cl.member = null;
                cl.usedminute = null;
                cl.remainminute = null;
                cl.start = null;
                cl.tc = null;
                cl.ht = null;
                dcm.SubmitChanges();
            }
            PacketServerClientMemberLogoutok packet = new PacketServerClientMemberLogoutok();
            Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packet));
        }

        private void client_timecodelogout(string ip)
        {
            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
            {
                client cl = dcm.clients.Where(_c => _c.ip == ip).FirstOrDefault();
                cl.status = 1;
                int usedmoney = (cl.group.timecodeprice / 60) * (int)cl.usedminute;
                cl.timecode.money = cl.timecode.money - usedmoney;
                if (cl.timecode.money < 1)
                {
                    cl.timecode.money = 0;
                }
                cl.member = null;
                cl.usedminute = null;
                cl.remainminute = null;
                cl.start = null;
                cl.timecode = null;
                cl.ht = null;
                dcm.SubmitChanges();
            }
            PacketServerClientTimecodeLogoutok packet = new PacketServerClientTimecodeLogoutok();
            Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packet));
        }

        private void client_timecodelogin(PacketClientServerTimecodeLogin packet,string ip)
        {
            using (DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr))
            {
                var timecodes = from t in dcm.timecodes where t.code.ToLower() == packet.timecode select new { t.code,t.money,t.ot };
                if (timecodes.Count() == 1)
                {
                    var clients = from c in dcm.clients where c.tc == timecodes.FirstOrDefault().code select new { c.name };
                    if (clients.Count() == 0)
                    {
                        if (DateTime.Now.Subtract(timecodes.FirstOrDefault().ot).Days > 14)
                        {
                            PacketServerClientTimecodeExpired packetexpired = new PacketServerClientTimecodeExpired();
                            Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packetexpired));
                        }
                        else
                        {
                            client cl = dcm.clients.Where(_c => _c.ip == ip).FirstOrDefault();
                            if (cl.group.timecode == true)
                            {
                                if (timecodes.FirstOrDefault().money >= cl.group.minprice)
                                {
                                    PacketServerClientTimecodeLoginok packetloginok = new PacketServerClientTimecodeLoginok();
                                    packetloginok.money = timecodes.FirstOrDefault().money;
                                    packetloginok.code = timecodes.FirstOrDefault().code;
                                    cl.status = 4;
                                    cl.member_name = null;
                                    cl.usedminute = 0;
                                    cl.remainminute = (timecodes.FirstOrDefault().money * 60) / cl.group.timecodeprice;
                                    cl.start = DateTime.Now;
                                    packetloginok.start = DateTime.Now;
                                    cl.tc = timecodes.FirstOrDefault().code;
                                    cl.ht = null;
                                    dcm.SubmitChanges();
                                    Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packetloginok));
                                }
                                else
                                {
                                    PacketServerClientTimecodeLoginempty packetempty = new PacketServerClientTimecodeLoginempty();
                                    Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packetempty));
                                }
                            }
                            else
                            {
                                PacketServerClientTiemcodeDisabled packetdisabled = new PacketServerClientTiemcodeDisabled();
                                Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packetdisabled));
                            }

                        }
                    }
                    else
                    {
                        PacketServerClientTimecodeLoginalready packetloginalready = new PacketServerClientTimecodeLoginalready();
                        packetloginalready.name = clients.FirstOrDefault().name;
                        Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packetloginalready));
                    }
                }
                else
                {
                    PacketServerClientTimecodeLoginfailed packetloginfailed = new PacketServerClientTimecodeLoginfailed();
                    Send(ip, Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packetloginfailed));
                }
            }
        }

        private void client_management(string ip, string data)
        {
            if (data.Length == 0)
            {
                return;
            }
            ip = ip.Substring(0, ip.IndexOf(":"));
            string cmd = (string)Newtonsoft.Json.Linq.JObject.Parse(data)["command"];
            switch (cmd)
            {
                case "syn": client_syn(Newtonsoft.Json.JsonConvert.DeserializeObject<PacketClientServerSyn>(data),ip);break;
                case "initrequest": client_init(Newtonsoft.Json.JsonConvert.DeserializeObject<PacketClientServerInitrequest>(data), ip); break;
                case "adminlogout": client_adminlogout(ip);break;
                case "memberlogin": client_memberlogin(Newtonsoft.Json.JsonConvert.DeserializeObject<PacketClientServerMemberLogin>(data),ip); break;
                case "memberlogout": client_memberlogout(ip); break;
                case "timecodelogin": client_timecodelogin(Newtonsoft.Json.JsonConvert.DeserializeObject<PacketClientServerTimecodeLogin>(data),ip); break;
                case "timecodelogout": client_timecodelogout(ip); break;

                default: break;
            }
        }

        private void monitor_connect(string ip)
        {
            status();
            Program.log.Info(ip + ", monitor connect.");
        }

        private void monitor_collect(object obj)
        {
            string[] param = (string[])obj;
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.LoadXml(param[1]);
                if (xd.ChildNodes.Count > 0 && xd.ChildNodes[0].Name == "rc")
                {
                    string id = xd.ChildNodes[0].ChildNodes[0].InnerText;
                    string spart = xd.ChildNodes[0].ChildNodes[1].InnerText;
                    int part = Convert.ToInt32(spart);
                    string scount = xd.ChildNodes[0].ChildNodes[2].InnerText;
                    int count = Convert.ToInt32(scount);
                    string data = xd.ChildNodes[0].ChildNodes[3].InnerText;

                    if (monitors_packets.ContainsKey(id))
                    {
                        Packet p = (Packet)monitors_packets[id];
                        p.packets[part] = data;
                        monitors_packets[id] = p;
                    }
                    else
                    {
                        Packet p = new Packet();
                        p.packets = new string[count];
                        p.id = id;
                        p.ip = param[0];
                        p.cnt = count;
                        p.packets[part] = data;
                        monitors_packets.Add(id, p);
                    }
                    Packet ptotal = (Packet)monitors_packets[id];

                    if (part + 1 == count)
                    {
                        string total = "";
                        for (var i = 0; i < count; i++)
                        {
                            total = total + ptotal.packets[i];
                        }
                        total = Program.Decompress(total);
                        monitor_management(ptotal.ip, total);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.log.Error(ex);
            }
        }

        private void client_collect(object obj)
        {
            string[] param = (string[])obj;
            //try
            //{
                XmlDocument xd = new XmlDocument();
                xd.LoadXml(param[1]);
                if (xd.ChildNodes.Count > 0 && xd.ChildNodes[0].Name == "rc")
                {
                    string id = xd.ChildNodes[0].ChildNodes[0].InnerText;
                    string spart = xd.ChildNodes[0].ChildNodes[1].InnerText;
                    int part = Convert.ToInt32(spart);
                    string scount = xd.ChildNodes[0].ChildNodes[2].InnerText;
                    int count = Convert.ToInt32(scount);
                    string data = xd.ChildNodes[0].ChildNodes[3].InnerText;

                    if (clients_packets.ContainsKey(id))
                    {
                        Packet p = (Packet)clients_packets[id];
                        p.packets[part] = data;
                        clients_packets[id] = p;
                    }
                    else
                    {
                        Packet p = new Packet();
                        p.packets = new string[count];
                        p.id = id;
                        p.ip = param[0];
                        p.cnt = count;
                        p.packets[part] = data;
                        clients_packets.Add(id, p);
                    }
                    Packet ptotal = (Packet)clients_packets[id];

                    if (part + 1 == count)
                    {
                        string total = "";
                        for (var i = 0; i < count; i++)
                        {
                            total = total + ptotal.packets[i];
                        }
                        total = Program.Decompress(total);
                        client_management(ptotal.ip, total);
                    }
                }
            //}
            //catch (Exception ex)
            //{
                //Program.log.Error(ex);
            //}
        }

        private void monitor_listen()
        {
            UdpClient monitor_udp = new UdpClient(Program.port_monitortoserver);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, Program.port_monitortoserver);
            while (true)
            {
                try
                {
                    byte[] allmessage = monitor_udp.Receive(ref ipep);
                    recivedbytes += allmessage.Length;
                    string[] param = new string[2];
                    param[0] = ipep.ToString();
                    param[1] = System.Text.Encoding.UTF8.GetString(allmessage);
                    Task.Factory.StartNew(() => monitor_collect(param));
                }
                catch (Exception ex)
                {
                    Program.log.Error(ex);
                }
            }
            //monitor_udp.Close();
        }

        private void client_listen()
        {
            UdpClient client_udp = new UdpClient(Program.port_clienttoserver);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, Program.port_clienttoserver);
            while (true)
            {
                try
                {
                    byte[] allmessage = client_udp.Receive(ref ipep);
                    recivedbytes += allmessage.Length;
                    string[] param = new string[2];
                    param[0] = ipep.ToString();
                    param[1] = System.Text.Encoding.UTF8.GetString(allmessage);
                    Task.Factory.StartNew(() => client_collect(param));
                }
                catch(Exception ex)
                {
                    Program.log.Error(ex);
                }
            }
            //client_udp.Close();
        }

        private void broadcast_timerealpsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress[] addr = ipEntry.AddressList;
                string sdata = "<mastercafe><cmd>broadcast</cmd><name>" + SystemInformation.ComputerName +"/"+cfg.org_name+ "</name></mastercafe>";
                byte[] data = Encoding.UTF8.GetBytes(sdata);
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                for (int i = 0; i < addr.Length;i++)
                {
                    if (addr[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        string ipbrd=addr[i].ToString();
                        ipbrd = ipbrd.Substring(0, ipbrd.LastIndexOf(".") + 1);
                        ipbrd += "255";
                        IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ipbrd), Program.port_broadcast);
                        sock.SendTo(data, iep);
                    }
                }
                sock.Close();
            }
            catch (Exception ex)
            {
                Program.log.Error(ex);
            }
        }

        private void monitor_timerelapsed(object sender, EventArgs e)
        {
            string[] mos = new string[monitors.Count];
            monitors.Keys.CopyTo(mos, 0);
            Parallel.For(0, mos.Length, i =>
            {
                int c = int.Parse(monitors[mos[i]].ToString());
                c++;
                if (c > dissecond)
                {
                    monitors.Remove(mos[i]);
                    monitor_disconnect(mos[i]);
                }
                else
                {
                    monitors[mos[i]] = c;
                    PacketServerMonitorSyn packet = new PacketServerMonitorSyn();
                    packet.now = DateTime.Now;
                    Send(mos[i], Program.port_servertomonitor, Newtonsoft.Json.JsonConvert.SerializeObject(packet));
                }
            });
        }

        private void client_timerelapsed(object sender, EventArgs e)
        {
            string[] cls = new string[clients.Count];
            clients.Keys.CopyTo(cls, 0);
            Parallel.For(0, cls.Length, i=>
            {
                if (clients.ContainsKey(cls[i]))
                {
                    int c = (int)clients[cls[i]];
                    c++;
                    if (c > dissecond)
                    {
                        clients.Remove(cls[i]);
                        client_disconnect(cls[i]);
                    }
                    else
                    {
                        clients[cls[i]] = c;
                        PacketServerClientSyn packet = new PacketServerClientSyn();
                        Send(cls[i], Program.port_servertoclient, Newtonsoft.Json.JsonConvert.SerializeObject(packet));
                    }
                }
            });
        }

        private void status()
        {
            if (userControl_monitor.label_status.InvokeRequired)
            {
                userControl_monitor.label_status.Invoke(new MethodInvoker(delegate
                {
                    userControl_monitor.label_status.Text = "Клиент (" + clients.Count + ") Монитор (" + monitors.Count + ")";
                }));
            }
            else
            {
                userControl_monitor.label_status.Text = "Клиент (" + clients.Count + ") Монитор (" + monitors.Count + ")";
            }
        }

        private void monitor_disconnect(string ip)
        {
            status();
            Program.log.Info(ip + ", monitor disconnect.");
        }

        
        private void Exit()
        {
            notifyIcon.Visible = false;
            Thread.Sleep(1000);
            System.Environment.Exit(0);
        }

        private void menu_closeclick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Серверийг хаах гэж байна?", "Анхаар", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Exit();
            }
        }

        private void Serverfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            menu_showhide.Text = "Нээх";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipText = "Сервер ажиллаж байна.";
            notifyIcon.BalloonTipTitle = "MasterCafe";
            notifyIcon.ShowBalloonTip(50);
        }
        
        private void Send(string clientip, int port, string message)
        {
            string[] param = new string[3];
            param[0] = clientip;
            param[1] = port.ToString();
            param[2] = message;
            Task.Factory.StartNew(() => _Send(param));
        }

        private void _Send(object obj)
        {
            int step = 60000;
            int sleep = 10;
            string[] param = (string[])obj;
            string ip = param[0];
            int port = Convert.ToInt32(param[1]);
            string data = param[2];
            string id = Guid.NewGuid().ToString();
            data = Program.Compress(data);
            int cnt = data.Length / step;
            while (step * cnt < data.Length)
            {
                cnt = cnt + 1;
            }
            string[] packets = new string[cnt];
            for (int i = 0; i < cnt; i++)
            {
                if (i + 1 == cnt)
                {
                    step = data.Length - i * step;
                }
                packets[i] = data.Substring(i * step, step);
                byte[] message = System.Text.Encoding.UTF8.GetBytes("<rc><id>" + id + "</id><part>" + i + "</part><count>" + cnt + "</count><data>" + packets[i] + "</data></rc>");
                try
                {
                    UdpClient sock = new UdpClient(ip, port);
                    sock.Send(message, message.Length);
                    sock.Close();
                    sentbytes = sentbytes + message.Length;
                    Thread.Sleep(sleep);
                }
                catch (Exception ex)
                {
                    Program.log.Error(ex);
                }
            }
        }

        private void speedtest()
        {
            try
            {
                WebClient wc = new WebClient();
                gcfg = Newtonsoft.Json.JsonConvert.DeserializeObject<gconfig>(wc.DownloadString("http://" + host + "/api/version.php"));
                if (gcfg.load)
                {
                    DataContext_mastercafe dcm = new DataContext_mastercafe(Program.constr);
                    double? weid = dcm.clients.Where(c => c.wei != null).Average(c => c.wei);
                    if (weid == null)
                    {
                        weid = 0;
                    }
                    int wei = (int)weid;
                    int free=dcm.clients.Where(c => c.status < 2 && c.group.vip == false).Count();
                    int vipfree = dcm.clients.Where(c => c.status < 2 && c.group.vip == true).Count();
                    double[] speeds = new double[3];
                    
                    for (int i = 0; i < speeds.Length; i++)
                    {
                        if (File.Exists(i.ToString()))
                        {
                            File.Delete(i.ToString());
                        }
                        WebClient client = new WebClient();
                        DateTime startTime = DateTime.Now;
                        client.DownloadFile(gcfg.speedtesturl, i.ToString());
                        DateTime endTime = DateTime.Now;
                        speeds[i] = Math.Round((gcfg.speedtestsize / (endTime - startTime).TotalSeconds));
                        File.Delete(i.ToString());
                    }
                    int speed = (int)speeds.Average();
                    WebClient wclient = new WebClient();
                    wclient.DownloadString("http://" + host + "/api/stats.php?license=" + cfg.org_id + "&speed=" + speed+"&wei="+wei+"&free="+free+"&vipfree="+vipfree);
                }
            }
            catch (Exception ex)
            {
                Program.log.Error(ex);
            }
        }

        private void speed_timerelapsed(object sender, ElapsedEventArgs e)
        {
            Task.Factory.StartNew(() => speedtest());
        }

        private void menu_backupclick(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog(this);
            if (login.ok)
            {
                System.Windows.Forms.SaveFileDialog savef = new SaveFileDialog();
                savef.FileName = "mastercafedb.db";
                savef.Filter = "Database|*.db";
                if (savef.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(Program.constr);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("BACKUP DATABASE [mastercafedb] TO DISK = N'"+savef.FileName+"' WITH NOFORMAT, INIT,  NAME = N'mastercafedb-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10;", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Өгөгдлийн сан амжилттай нөөцөлсөн.", "Анхаар", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Program.log.Info("Backup database complete. "+savef.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Алдаа гарсан.", "Анхаар", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        Program.log.Error(ex);
                    }
                }
            }
        }


        private void menu_restoreclick(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog(this);
            if (login.ok)
            {
                System.Windows.Forms.OpenFileDialog openf = new OpenFileDialog();
                openf.Filter = "Database|*.db";
                if (openf.ShowDialog(this) == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start(Application.ExecutablePath,"-restore=\"" + openf.FileName + "\"");
                    System.Environment.Exit(0);
                }
            }
        }

        private void menu_showhide_Click(object sender, EventArgs e)
        {
            if (WindowState==FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
        }

        private void notifyIcon_click(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Serverfrm));
                    this.ShowIcon = true;
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                }
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                menu_showhide.Text = "Нээх";
            }
            else
            {
                menu_showhide.Text = "Нуух";
            }
        }
    }
}
