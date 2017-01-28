using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class server
    {
        public string name;
        public string org;
    }

    public class gconfig
    {
        public bool load = false;
        public int version;
        public string speedtesturl;
        public int speedtestsize;
    }

    public class clientgroup
    {
        public Guid id;
        public string name;
        public int timecodeprice;
        public int memberprice;
        public int hourprice;
        public bool timecode;
        public bool member;
        public bool hour;
        public bool prepairhour;
        public int minprice;
    }

    public class PacketServerMonitorSyn
    {
        public string command = "syn";
        public DateTime now;
    }

    public class PacketMonitorServerLogin
    {
        public string command = "login";
        public string name;
    }

    public class PacketServerMonitorLoginok
    {
        public string command = "loginok";
        public string name;
        public bool isadmin;
    }

    public class PacketServerMonitorLoginfailed
    {
        public string command = "loginfailed";
    }

    public class PacketMonitorServerLogout
    {
        public string command = "logout";
        public string name;
    }

    public class PacketServerMonitorLogoutok
    {
        public string command = "logoutok";
    }


    public class Packet
    {
        public string id;
        public int cnt;
        public string[] packets;
        public string ip;
    }

    public class PacketClientServerSyn
    {
        public string command = "syn";
        public string name;
        public string mac;
        public int? status;
        public string member_name;
        public int? usedminute;
        public int? remainminute;
        public DateTime? start;
        public string app;
        public string title;
        public string tc;
        public Guid? ht;
        public int? wei;
    }

    public class PacketClientServerInitrequest
    {
        public string command = "initrequest";
        public string name;
    }

    public class PacketServerClientInit
    {
        public string command = "init";
        public string orgname;
        public string orgid;
        public string clientuser;
        public string clientpassword;
        public clientgroup group;
        public int portid;
    }

    public class PacketServerClientSyn
    {
        public string command = "syn";
    }

    public class PacketServerClientAdminLogoutok
    {
        public string command = "adminlogoutok";
    }

    public class PacketClientServerMemberLogin
    {
        public string command = "memberlogin";
        public string member;
        public string password;
    }

    public class PacketServerClientMemberLogoutok
    {
        public string command = "memberlogoutok";
    }

    public class PacketServerClientMemberLoginfailed
    {
        public string command = "memberloginfailed";
    }

    public class PacketServerClientMemberLoginok
    {
        public string command = "memberloginok";
        public string member;
        public int money;
        public DateTime start;
    }

    public class PacketServerClientMemberLoginalready
    {
        public string command = "memberloginalready";
        public string name;
    }

    public class PacketServerClientMemberDisabled
    {
        public string command = "memberdisabled";
    }

    public class PacketServerClientMemberLoginempty
    {
        public string command = "memberloginempty";
    }

    public class PacketClientServerTimecodeLogin
    {
        public string command = "timecodelogin";
        public string timecode;
    }

    public class PacketServerClientTimecodeLoginfailed
    {
        public string command = "timecodeloginfailed";
    }

    public class PacketServerClientTimecodeLoginempty
    {
        public string command = "timecodeloginempty";
    }

    public class PacketServerClientTimecodeExpired
    {
        public string command = "timecodeexpired";
    }

    public class PacketServerClientTimecodeLoginok
    {
        public string command = "timecodeloginok";
        public string code;
        public int money;
        public DateTime start;
    }

    public class PacketServerClientTiemcodeDisabled
    {
        public string command = "timecodedisabled";
    }

    public class PacketServerClientTimecodeLoginalready
    {
        public string command = "timecodeloginalready";
        public string name;
    }

    public class PacketServerClientTimecodeLogoutok
    {
        public string command = "memberlogoutok";
    }
}
