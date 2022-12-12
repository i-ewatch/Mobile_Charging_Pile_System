using Mobile_Charging_Pile_System.Configuration;
using Mobile_Charging_Pile_System.Enums;
using Mobile_Charging_Pile_System.Methods;
using Mobile_Charging_Pile_System.Modules;
using Mobile_Charging_Pile_System.Protocols;
using NModbus;
using NModbus.Serial;
using Serilog;
using System;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;

namespace Mobile_Charging_Pile_System.Components
{
    public partial class SerialportComponent : Field4Component
    {
        public SerialportComponent(SystemSetting systemSetting, APIMethod aPIMethod)
        {
            InitializeComponent();
            SystemSetting = systemSetting;
            APIMethod = aPIMethod;
        }

        public SerialportComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void AfterMyWorkStateChanged(object sender, EventArgs e)
        {
            if (myWorkState)
            {
                Factory = new ModbusFactory();
                foreach (var item in SystemSetting.DeviceSettings)
                {
                    DeviceType device = (DeviceType)item.DeviceType;
                    switch (device)
                    {
                        case DeviceType.Battery_Four:
                            {
                                Battery_Four_Protocol protocol = new Battery_Four_Protocol() { APIMethod = APIMethod, ID = (byte)item.ID, Location = SystemSetting.Location, Port = SystemSetting.Port, GatewayNum = SystemSetting.GatewayNum, DeviceSetting = item };
                                AbsProtocols.Add(protocol);
                            }
                            break;
                    }
                }
                ReadThread = new Thread(Analysis);
                ReadThread.Start();
            }
            else
            {
                if (ReadThread != null)
                {
                    ReadThread.Abort();
                }
            }
        }
        protected void Analysis()
        {
            while (myWorkState)
            {
                TimeSpan timeSpan = DateTime.Now.Subtract(ReadTime);
                if (timeSpan.TotalMilliseconds >= 1000)
                {
                    foreach (var item in AbsProtocols)
                    {
                        if (myWorkState)
                        {
                            try
                            {
                                #region Rs485通訊功能初始化
                                try
                                {
                                    if (SerialPort == null)
                                    {
                                        SerialPort = new SerialPort();
                                    }
                                    if (!SerialPort.IsOpen)
                                    {
                                        SerialPort.PortName = item.Location;
                                        SerialPort.BaudRate = item.Port;
                                        SerialPort.DataBits = 8;
                                        SerialPort.StopBits = StopBits.One;
                                        SerialPort.Parity = Parity.None;
                                        SerialPort.Open();
                                    }
                                }
                                catch (ArgumentException)
                                {
                                    Log.Error("通訊埠設定有誤");
                                }
                                catch (InvalidOperationException)
                                {
                                    Log.Error("通訊埠被占用");
                                }
                                catch (IOException)
                                {
                                    Log.Error("通訊埠無效");
                                }
                                catch (Exception ex)
                                {
                                    Log.Error(ex, "通訊埠發生不可預期的錯誤。");
                                }
                                #endregion
                                if (SerialPort.IsOpen)
                                {
                                    master = ModbusFactoryExtensions.CreateRtuMaster(Factory, SerialPort);//建立RTU通訊
                                    master.Transport.Retries = 1;
                                    master.Transport.ReadTimeout = 2000;
                                    master.Transport.WriteTimeout = 2000;
                                    item.Data_Read(master);
                                    Thread.Sleep(10);
                                }
                                Battery_Four_Data data = item as Battery_Four_Data;
                                if (data.ConnectFlag)
                                {
                                    if (Battery_Datas.Count > 0)
                                    {
                                        Battery_Data battery_Data = Battery_Datas.SingleOrDefault(g => g.ChargePileGuid == item.DeviceSetting.DeviceGuid);
                                        if (battery_Data != null)
                                        {
                                            battery_Data.DateTime = DateTime.Now;
                                            battery_Data.Vpack = data.Vpack.ToList();
                                            battery_Data.Charging_Current = data.Charging_Current.ToList();
                                            battery_Data.Discharging_Current = data.Discharging_Current.ToList();
                                            battery_Data.SOC = data.SOC.ToList();
                                            battery_Data.Temp = data.Temp.ToList();
                                            battery_Data.Charge_Discharge_Times = data.Charge_Discharge_Times.ToList();
                                            battery_Data.Total_SOC = data.Total_SOC.ToList();

                                        }
                                        else
                                        {
                                            Battery_Datas.Add(new Battery_Data
                                            {
                                                DateTime = DateTime.Now,
                                                ChargePileGuid = data.DeviceSetting.DeviceGuid,
                                                Vpack = data.Vpack.ToList(),
                                                Charging_Current = data.Charging_Current.ToList(),
                                                Discharging_Current = data.Discharging_Current.ToList(),
                                                SOC = data.SOC.ToList(),
                                                Temp = data.Temp.ToList(),
                                                Charge_Discharge_Times = data.Charge_Discharge_Times.ToList(),
                                                Total_SOC = data.Total_SOC.ToList()
                                            });
                                        }
                                    }
                                    else
                                    {
                                        Battery_Datas.Add(new Battery_Data
                                        {
                                            DateTime = DateTime.Now,
                                            ChargePileGuid = data.DeviceSetting.DeviceGuid,
                                            Vpack = data.Vpack.ToList(),
                                            Charging_Current = data.Charging_Current.ToList(),
                                            Discharging_Current = data.Discharging_Current.ToList(),
                                            SOC = data.SOC.ToList(),
                                            Temp = data.Temp.ToList(),
                                            Charge_Discharge_Times = data.Charge_Discharge_Times.ToList(),
                                            Total_SOC = data.Total_SOC.ToList()
                                        });
                                    }
                                }
                                ReadTime = DateTime.Now;
                            }
                            catch (ThreadAbortException) { }
                            catch (Exception ex)
                            {
                                item.ConnectFlag = false;
                                ReadTime = DateTime.Now;
                                Log.Error(ex, $"通訊失敗 COM:{item.Location} Rate:{item.Port} ");
                            }
                        }
                    }
                }
                else
                {
                    Thread.Sleep(80);
                }
            }
        }
    }
}
