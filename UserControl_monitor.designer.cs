namespace Server
{
    partial class UserControl_monitor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label_processor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_user = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_dbsize = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNetI = new System.Windows.Forms.Label();
            this.labelNetO = new System.Windows.Forms.Label();
            this.labelDiskW = new System.Windows.Forms.Label();
            this.labelDiskR = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelMemV = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelMemP = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelCpu = new System.Windows.Forms.Label();
            this.labelSNETI_ = new System.Windows.Forms.Label();
            this.labelSNETO_ = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label_status = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.timer_db = new System.Windows.Forms.Timer(this.components);
            this.dataChartSNETI = new Server.DataChart();
            this.dataChartSNETO = new Server.DataChart();
            this.dataChartMem = new Server.DataChart();
            this.dataChartCPU = new Server.DataChart();
            this.dataChartNetI = new Server.DataChart();
            this.dataChartNetO = new Server.DataChart();
            this.dataChartDiskW = new Server.DataChart();
            this.dataChartDiskR = new Server.DataChart();
            this.dataBarMemV = new Server.DataBar();
            this.dataBarMemP = new Server.DataBar();
            this.dataBarCPU = new Server.DataBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.ForeColor = System.Drawing.Color.White;
            this.label_name.Location = new System.Drawing.Point(70, 20);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(0, 13);
            this.label_name.TabIndex = 1;
            // 
            // label_processor
            // 
            this.label_processor.AutoSize = true;
            this.label_processor.ForeColor = System.Drawing.Color.White;
            this.label_processor.Location = new System.Drawing.Point(96, 52);
            this.label_processor.Name = "label_processor";
            this.label_processor.Size = new System.Drawing.Size(0, 13);
            this.label_processor.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(22, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Processor:";
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.ForeColor = System.Drawing.Color.White;
            this.label_user.Location = new System.Drawing.Point(64, 85);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(0, 13);
            this.label_user.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(22, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "User:";
            // 
            // label_dbsize
            // 
            this.label_dbsize.AutoSize = true;
            this.label_dbsize.ForeColor = System.Drawing.Color.White;
            this.label_dbsize.Location = new System.Drawing.Point(93, 118);
            this.label_dbsize.Name = "label_dbsize";
            this.label_dbsize.Size = new System.Drawing.Size(0, 13);
            this.label_dbsize.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Database:";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.Color.Silver;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(25, 179);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(286, 2);
            this.pictureBox.TabIndex = 56;
            this.pictureBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(25, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 16);
            this.label5.TabIndex = 54;
            this.label5.Text = "Memory usage";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 16);
            this.label2.TabIndex = 52;
            this.label2.Text = "CPU usage";
            // 
            // labelNetI
            // 
            this.labelNetI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNetI.ForeColor = System.Drawing.Color.White;
            this.labelNetI.Location = new System.Drawing.Point(25, 419);
            this.labelNetI.Name = "labelNetI";
            this.labelNetI.Size = new System.Drawing.Size(224, 16);
            this.labelNetI.TabIndex = 44;
            this.labelNetI.Text = "Network input";
            // 
            // labelNetO
            // 
            this.labelNetO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNetO.ForeColor = System.Drawing.Color.White;
            this.labelNetO.Location = new System.Drawing.Point(255, 419);
            this.labelNetO.Name = "labelNetO";
            this.labelNetO.Size = new System.Drawing.Size(242, 16);
            this.labelNetO.TabIndex = 43;
            this.labelNetO.Text = "Network output";
            // 
            // labelDiskW
            // 
            this.labelDiskW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiskW.ForeColor = System.Drawing.Color.White;
            this.labelDiskW.Location = new System.Drawing.Point(255, 371);
            this.labelDiskW.Name = "labelDiskW";
            this.labelDiskW.Size = new System.Drawing.Size(242, 16);
            this.labelDiskW.TabIndex = 42;
            this.labelDiskW.Text = "Disk write";
            // 
            // labelDiskR
            // 
            this.labelDiskR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiskR.ForeColor = System.Drawing.Color.White;
            this.labelDiskR.Location = new System.Drawing.Point(25, 371);
            this.labelDiskR.Name = "labelDiskR";
            this.labelDiskR.Size = new System.Drawing.Size(224, 16);
            this.labelDiskR.TabIndex = 41;
            this.labelDiskR.Text = "Disk read";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(25, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 40;
            this.label7.Text = "Memory V";
            // 
            // labelMemV
            // 
            this.labelMemV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemV.ForeColor = System.Drawing.Color.White;
            this.labelMemV.Location = new System.Drawing.Point(231, 275);
            this.labelMemV.Name = "labelMemV";
            this.labelMemV.Size = new System.Drawing.Size(184, 16);
            this.labelMemV.TabIndex = 39;
            this.labelMemV.Text = "Mem V";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(25, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 38;
            this.label8.Text = "Memory P";
            // 
            // labelMemP
            // 
            this.labelMemP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemP.ForeColor = System.Drawing.Color.White;
            this.labelMemP.Location = new System.Drawing.Point(231, 299);
            this.labelMemP.Name = "labelMemP";
            this.labelMemP.Size = new System.Drawing.Size(184, 16);
            this.labelMemP.TabIndex = 37;
            this.labelMemP.Text = "Mem P";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(25, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 35;
            this.label9.Text = "CPU";
            // 
            // labelCpu
            // 
            this.labelCpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCpu.ForeColor = System.Drawing.Color.White;
            this.labelCpu.Location = new System.Drawing.Point(177, 195);
            this.labelCpu.Name = "labelCpu";
            this.labelCpu.Size = new System.Drawing.Size(184, 16);
            this.labelCpu.TabIndex = 36;
            this.labelCpu.Text = "CPU";
            // 
            // labelSNETI_
            // 
            this.labelSNETI_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSNETI_.ForeColor = System.Drawing.Color.White;
            this.labelSNETI_.Location = new System.Drawing.Point(25, 469);
            this.labelSNETI_.Name = "labelSNETI_";
            this.labelSNETI_.Size = new System.Drawing.Size(224, 16);
            this.labelSNETI_.TabIndex = 58;
            this.labelSNETI_.Text = "Server input";
            // 
            // labelSNETO_
            // 
            this.labelSNETO_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSNETO_.ForeColor = System.Drawing.Color.White;
            this.labelSNETO_.Location = new System.Drawing.Point(255, 469);
            this.labelSNETO_.Name = "labelSNETO_";
            this.labelSNETO_.Size = new System.Drawing.Size(242, 16);
            this.labelSNETO_.TabIndex = 57;
            this.labelSNETO_.Text = "Server output";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 2000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.ForeColor = System.Drawing.Color.White;
            this.label_status.Location = new System.Drawing.Point(69, 150);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(0, 13);
            this.label_status.TabIndex = 62;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(22, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "Status:";
            // 
            // timer_db
            // 
            this.timer_db.Enabled = true;
            this.timer_db.Interval = 30000;
            this.timer_db.Tick += new System.EventHandler(this.timer_db_Tick);
            // 
            // dataChartSNETI
            // 
            this.dataChartSNETI.BackColor = System.Drawing.Color.Silver;
            this.dataChartSNETI.ChartType = Server.ChartType.Stick;
            this.dataChartSNETI.GridColor = System.Drawing.Color.Yellow;
            this.dataChartSNETI.GridPixels = 0;
            this.dataChartSNETI.InitialHeight = 1000;
            this.dataChartSNETI.LineColor = System.Drawing.Color.DarkBlue;
            this.dataChartSNETI.Location = new System.Drawing.Point(25, 485);
            this.dataChartSNETI.Name = "dataChartSNETI";
            this.dataChartSNETI.Size = new System.Drawing.Size(200, 24);
            this.dataChartSNETI.TabIndex = 60;
            // 
            // dataChartSNETO
            // 
            this.dataChartSNETO.BackColor = System.Drawing.Color.Silver;
            this.dataChartSNETO.ChartType = Server.ChartType.Stick;
            this.dataChartSNETO.GridColor = System.Drawing.Color.Yellow;
            this.dataChartSNETO.GridPixels = 0;
            this.dataChartSNETO.InitialHeight = 1000;
            this.dataChartSNETO.LineColor = System.Drawing.Color.DarkBlue;
            this.dataChartSNETO.Location = new System.Drawing.Point(255, 485);
            this.dataChartSNETO.Name = "dataChartSNETO";
            this.dataChartSNETO.Size = new System.Drawing.Size(200, 24);
            this.dataChartSNETO.TabIndex = 59;
            // 
            // dataChartMem
            // 
            this.dataChartMem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataChartMem.BackColor = System.Drawing.Color.Silver;
            this.dataChartMem.ChartType = Server.ChartType.Line;
            this.dataChartMem.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataChartMem.GridColor = System.Drawing.Color.Gold;
            this.dataChartMem.GridPixels = 12;
            this.dataChartMem.InitialHeight = 100;
            this.dataChartMem.LineColor = System.Drawing.Color.DarkBlue;
            this.dataChartMem.Location = new System.Drawing.Point(25, 339);
            this.dataChartMem.Name = "dataChartMem";
            this.dataChartMem.Size = new System.Drawing.Size(357, 24);
            this.dataChartMem.TabIndex = 55;
            // 
            // dataChartCPU
            // 
            this.dataChartCPU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataChartCPU.BackColor = System.Drawing.Color.Silver;
            this.dataChartCPU.ChartType = Server.ChartType.Line;
            this.dataChartCPU.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataChartCPU.GridColor = System.Drawing.Color.Yellow;
            this.dataChartCPU.GridPixels = 8;
            this.dataChartCPU.InitialHeight = 100;
            this.dataChartCPU.LineColor = System.Drawing.Color.Green;
            this.dataChartCPU.Location = new System.Drawing.Point(25, 235);
            this.dataChartCPU.Name = "dataChartCPU";
            this.dataChartCPU.Size = new System.Drawing.Size(357, 24);
            this.dataChartCPU.TabIndex = 53;
            // 
            // dataChartNetI
            // 
            this.dataChartNetI.BackColor = System.Drawing.Color.Silver;
            this.dataChartNetI.ChartType = Server.ChartType.Stick;
            this.dataChartNetI.GridColor = System.Drawing.Color.Yellow;
            this.dataChartNetI.GridPixels = 0;
            this.dataChartNetI.InitialHeight = 1000;
            this.dataChartNetI.LineColor = System.Drawing.Color.DarkBlue;
            this.dataChartNetI.Location = new System.Drawing.Point(25, 435);
            this.dataChartNetI.Name = "dataChartNetI";
            this.dataChartNetI.Size = new System.Drawing.Size(200, 24);
            this.dataChartNetI.TabIndex = 51;
            // 
            // dataChartNetO
            // 
            this.dataChartNetO.BackColor = System.Drawing.Color.Silver;
            this.dataChartNetO.ChartType = Server.ChartType.Stick;
            this.dataChartNetO.GridColor = System.Drawing.Color.Yellow;
            this.dataChartNetO.GridPixels = 0;
            this.dataChartNetO.InitialHeight = 1000;
            this.dataChartNetO.LineColor = System.Drawing.Color.DarkBlue;
            this.dataChartNetO.Location = new System.Drawing.Point(255, 435);
            this.dataChartNetO.Name = "dataChartNetO";
            this.dataChartNetO.Size = new System.Drawing.Size(200, 24);
            this.dataChartNetO.TabIndex = 50;
            // 
            // dataChartDiskW
            // 
            this.dataChartDiskW.BackColor = System.Drawing.Color.Silver;
            this.dataChartDiskW.ChartType = Server.ChartType.Stick;
            this.dataChartDiskW.GridColor = System.Drawing.Color.Gold;
            this.dataChartDiskW.GridPixels = 0;
            this.dataChartDiskW.InitialHeight = 100000;
            this.dataChartDiskW.LineColor = System.Drawing.Color.Blue;
            this.dataChartDiskW.Location = new System.Drawing.Point(255, 387);
            this.dataChartDiskW.Name = "dataChartDiskW";
            this.dataChartDiskW.Size = new System.Drawing.Size(200, 24);
            this.dataChartDiskW.TabIndex = 49;
            // 
            // dataChartDiskR
            // 
            this.dataChartDiskR.BackColor = System.Drawing.Color.Silver;
            this.dataChartDiskR.ChartType = Server.ChartType.Stick;
            this.dataChartDiskR.GridColor = System.Drawing.Color.Gold;
            this.dataChartDiskR.GridPixels = 0;
            this.dataChartDiskR.InitialHeight = 100000;
            this.dataChartDiskR.LineColor = System.Drawing.Color.Blue;
            this.dataChartDiskR.Location = new System.Drawing.Point(25, 387);
            this.dataChartDiskR.Name = "dataChartDiskR";
            this.dataChartDiskR.Size = new System.Drawing.Size(200, 24);
            this.dataChartDiskR.TabIndex = 48;
            // 
            // dataBarMemV
            // 
            this.dataBarMemV.BackColor = System.Drawing.Color.Silver;
            this.dataBarMemV.BarColor = System.Drawing.Color.DarkBlue;
            this.dataBarMemV.Location = new System.Drawing.Point(127, 275);
            this.dataBarMemV.Name = "dataBarMemV";
            this.dataBarMemV.Size = new System.Drawing.Size(96, 16);
            this.dataBarMemV.TabIndex = 47;
            this.dataBarMemV.Value = 0;
            // 
            // dataBarMemP
            // 
            this.dataBarMemP.BackColor = System.Drawing.Color.Silver;
            this.dataBarMemP.BarColor = System.Drawing.Color.SlateBlue;
            this.dataBarMemP.Location = new System.Drawing.Point(127, 299);
            this.dataBarMemP.Name = "dataBarMemP";
            this.dataBarMemP.Size = new System.Drawing.Size(96, 16);
            this.dataBarMemP.TabIndex = 46;
            this.dataBarMemP.Value = 0;
            // 
            // dataBarCPU
            // 
            this.dataBarCPU.BackColor = System.Drawing.Color.Silver;
            this.dataBarCPU.BarColor = System.Drawing.Color.Green;
            this.dataBarCPU.Location = new System.Drawing.Point(73, 195);
            this.dataBarCPU.Name = "dataBarCPU";
            this.dataBarCPU.Size = new System.Drawing.Size(96, 16);
            this.dataBarCPU.TabIndex = 45;
            this.dataBarCPU.Value = 0;
            // 
            // UserControl_monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataChartSNETI);
            this.Controls.Add(this.dataChartSNETO);
            this.Controls.Add(this.labelSNETI_);
            this.Controls.Add(this.labelSNETO_);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.dataChartMem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataChartCPU);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataChartNetI);
            this.Controls.Add(this.dataChartNetO);
            this.Controls.Add(this.dataChartDiskW);
            this.Controls.Add(this.dataChartDiskR);
            this.Controls.Add(this.dataBarMemV);
            this.Controls.Add(this.dataBarMemP);
            this.Controls.Add(this.dataBarCPU);
            this.Controls.Add(this.labelNetI);
            this.Controls.Add(this.labelNetO);
            this.Controls.Add(this.labelDiskW);
            this.Controls.Add(this.labelDiskR);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelMemV);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelMemP);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelCpu);
            this.Controls.Add(this.label_dbsize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_user);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_processor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "UserControl_monitor";
            this.Size = new System.Drawing.Size(500, 550);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label_name;
        public System.Windows.Forms.Label label_processor;
        public System.Windows.Forms.Label label_user;
        public System.Windows.Forms.Label label_dbsize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public DataChart dataChartMem;
        public DataChart dataChartCPU;
        public DataChart dataChartNetI;
        public DataChart dataChartNetO;
        public DataChart dataChartDiskW;
        public DataChart dataChartDiskR;
        public DataBar dataBarMemV;
        public DataBar dataBarMemP;
        public DataBar dataBarCPU;
        public System.Windows.Forms.Label labelMemV;
        public System.Windows.Forms.Label labelMemP;
        public System.Windows.Forms.Label labelCpu;
        public System.Windows.Forms.Label labelNetI;
        public System.Windows.Forms.Label labelNetO;
        public System.Windows.Forms.Label labelDiskW;
        public System.Windows.Forms.Label labelDiskR;
        public DataChart dataChartSNETI;
        public DataChart dataChartSNETO;
        private System.Windows.Forms.Label labelSNETI_;
        private System.Windows.Forms.Label labelSNETO_;
        private System.Windows.Forms.Timer timer;
        public System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer timer_db;

    }
}
