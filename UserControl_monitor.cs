using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace Server
{
    public partial class UserControl_monitor : UserControl
    {
        private SystemData sd = new SystemData();
        public UserControl_monitor()
        {
            InitializeComponent();
            try
            {
                label_name.Text =Serverfrm.cfg.org_name;
                label_processor.Text = sd.QueryComputerSystem("manufacturer") + ", " + sd.QueryComputerSystem("model")+" "+sd.QueryEnvironment("%PROCESSOR_IDENTIFIER%");
                label_user.Text = sd.QueryComputerSystem("username");
            }
            catch { ;}
            dbsize();
        }
        enum Unit { B, KB, MB, GB, ER }
        public string FormatBytes(double bytes)
        {
            int unit = 0;
            while (bytes > 1024)
            {
                bytes /= 1024;
                ++unit;
            }

            string s = bytes.ToString("F") + " ";
            return s + ((Unit)unit).ToString();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                labelCpu.Text = sd.GetProcessorData();
                double d = double.Parse(labelCpu.Text.Substring(0, labelCpu.Text.IndexOf("%")), CultureInfo.InvariantCulture.NumberFormat);
                dataBarCPU.Value = (int)d;
                dataChartCPU.UpdateChart(d);

                labelMemP.Text = sd.GetMemoryPData();
                d = double.Parse(labelMemP.Text.Substring(0, labelMemP.Text.IndexOf("%")), CultureInfo.InvariantCulture.NumberFormat);
                dataBarMemP.Value = (int)d;
                dataChartMem.UpdateChart(d);
                labelMemV.Text = sd.GetMemoryVData();
                d = double.Parse(labelMemV.Text.Substring(0, labelMemV.Text.IndexOf("%")), CultureInfo.InvariantCulture.NumberFormat);
                dataBarMemV.Value = (int)d;
                labelNetI.Text = "Network input (" + FormatBytes(sd.GetNetData(SystemData.NetData.Received)) + "/c)";
                dataChartNetI.UpdateChart(sd.GetNetData(SystemData.NetData.Received));
                labelNetO.Text = "Network output (" + FormatBytes(sd.GetNetData(SystemData.NetData.Sent)) + "/c)";
                dataChartNetO.UpdateChart(sd.GetNetData(SystemData.NetData.Sent));
                labelDiskR.Text = "Disk read (" + FormatBytes(sd.GetDiskData(SystemData.DiskData.Read)) + "/с)";
                dataChartDiskR.UpdateChart(sd.GetDiskData(SystemData.DiskData.Read));
                labelDiskW.Text = "Disk write (" + FormatBytes(sd.GetDiskData(SystemData.DiskData.Write)) + "/с)";
                dataChartDiskW.UpdateChart(sd.GetDiskData(SystemData.DiskData.Write));

                labelSNETI_.Text = "Server network input (" + FormatBytes(Serverfrm.recivedbytes / 2) + "/c)";
                dataChartSNETI.UpdateChart(Serverfrm.recivedbytes);
                labelSNETO_.Text = "Server network output (" + FormatBytes(Serverfrm.sentbytes / 2) + "/c)";
                dataChartSNETO.UpdateChart(Serverfrm.sentbytes);
            }
            catch { ;}
            Serverfrm.recivedbytes = Serverfrm.sentbytes = 0;
            
        }
        private void dbsize()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_spaceused;", con);
                cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    label_dbsize.Text = "Name: (" + rdr[0].ToString() + ") Size: (" + rdr[1].ToString() + ") Log: (" + rdr[2].ToString() + ")";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Program.log.Error(ex);
            }
        }
        private void timer_db_Tick(object sender, EventArgs e)
        {
            dbsize();
        }
        
    }
}
