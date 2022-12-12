using Mobile_Charging_Pile_System.Components;
using Mobile_Charging_Pile_System.Configuration;
using Mobile_Charging_Pile_System.Enums;
using Mobile_Charging_Pile_System.Methods;
using Mobile_Charging_Pile_System.Protocols;
using Mobile_Charging_Pile_System.Views;
using Serilog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mobile_Charging_Pile_System
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 通訊資訊
        /// </summary>
        private List<SystemSetting> SystemSettings { get; set; } = new List<SystemSetting>();
        /// <summary>
        /// API資訊
        /// </summary>
        public APISetting APISetting { get; set; }
        #region 方法
        /// <summary>
        /// API上傳方法
        /// </summary>
        private APIMethod APIMethod { get; set; }
        #endregion
        #region 通訊
        /// <summary>
        /// 總通訊物件
        /// </summary>
        private List<Field4Component> Field4Components { get; set; } = new List<Field4Component>();
        /// <summary>
        /// 總設備數值物件
        /// </summary>
        private List<AbsProtocol> AbsProtocols { get; set; } = new List<AbsProtocol>();
        /// <summary>
        /// API上傳物件
        /// </summary>
        private APIComponent APIComponent { get; set; }
        #endregion
        #region 畫面
        private List<Field4UserControl> Field4UserControls { get; set; } = new List<Field4UserControl>();
        #endregion
        public Form1()
        {
            InitializeComponent();
            #region Serilog initial
            Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Error).WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}\\log\\Error-.txt",
                                      rollingInterval: RollingInterval.Day,
                                      outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"))
                        .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == Serilog.Events.LogEventLevel.Information).WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}\\log\\Information-.txt",
                                      rollingInterval: RollingInterval.Day,
                                      outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"))
                        .CreateLogger();        //宣告Serilog初始化
            #endregion
            ControlBox = false;
            SystemSettings = InitialMethod.System_Load();
            APISetting = InitialMethod.API_Load();
            APIMethod = new APIMethod(APISetting, "");
            #region 建立通訊
            foreach (var item in SystemSettings)
            {
                GatewayType gateway = (GatewayType)item.GatewayType;
                switch (gateway)
                {
                    case GatewayType.SerialPort:
                        {
                            SerialportComponent component = new SerialportComponent(item, APIMethod);
                            component.MyWorkState = true;
                            Field4Components.Add(component);
                            AbsProtocols.AddRange(component.AbsProtocols);
                        }
                        break;
                    case GatewayType.TCP:
                        {
                            TCPComponent component = new TCPComponent(item, APIMethod);
                            component.MyWorkState = true;
                            Field4Components.Add(component);
                            AbsProtocols.AddRange(component.AbsProtocols);
                        }
                        break;
                }
            }
            APIComponent = new APIComponent(Field4Components, APIMethod);
            APIComponent.MyWorkState = APISetting.Flag;
            #endregion
            #region 畫面
            foreach (var item in AbsProtocols)
            {
                BatteryView batteryView = new BatteryView(item) { Dock = DockStyle.Fill };
                Field4UserControls.Add(batteryView);
                panel.Controls.Add(batteryView);
            }
            #endregion
            #region 最小化
            btn_Disable.Click += (s, e) =>
            {
                this.Visible = false;
                this.notifyIcon.Visible = true;
            };
            notifyIcon.MouseDoubleClick += (s, e) =>
            {
                this.Show();
                this.notifyIcon.Visible = false;
                this.WindowState = FormWindowState.Normal;
            };
            #endregion
            timer.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close_Form close_Form = new Close_Form();
            if (close_Form.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in Field4Components)
                {
                    item.MyWorkState = false;
                }
                APIComponent.MyWorkState = false;
                timer.Enabled = false;
                Application.ExitThread();
                this.Dispose();
                e.Cancel = false;
            }
            else if (close_Form.DialogResult== DialogResult.No)
            {
                MessageBoxEx.Show(this,"密碼錯誤","關閉視窗",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            foreach (var item in Field4UserControls)
            {
                item.Text_Change();
            }
        }
    }
}
