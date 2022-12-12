using Mobile_Charging_Pile_System.Configuration;
using Mobile_Charging_Pile_System.Methods;
using Mobile_Charging_Pile_System.Modules;
using Mobile_Charging_Pile_System.Protocols;
using NModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Threading;

namespace Mobile_Charging_Pile_System.Components
{
    public class Field4Component : Component
    {
        #region 啟動初始設定
        public Field4Component()
        {
            OnMyWorkStateChanged += new MyWorkStateChanged(AfterMyWorkStateChanged);
        }
        protected void WhenMyWorkStateChange()
        {
            OnMyWorkStateChanged?.Invoke(this, null);
        }
        public delegate void MyWorkStateChanged(object sender, EventArgs e);
        public event MyWorkStateChanged OnMyWorkStateChanged;
        /// <summary>
        /// 系統工作路徑
        /// </summary>
        protected readonly string WorkPath = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 通訊功能啟動判斷旗標
        /// </summary>
        protected bool myWorkState;
        /// <summary>
        /// 通訊功能啟動旗標
        /// </summary>
        public bool MyWorkState
        {
            get { return myWorkState; }
            set
            {
                if (value != myWorkState)
                {
                    myWorkState = value;
                    WhenMyWorkStateChange();
                }
            }
        }
        /// <summary>
        /// 執行續工作狀態改變觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void AfterMyWorkStateChanged(object sender, EventArgs e) { }
        /// <summary>
        /// 最後讀取時間
        /// </summary>
        public DateTime ReadTime { get; set; }
        /// <summary>
        /// 通訊執行緒
        /// </summary>
        public Thread ReadThread { get; set; }
        #endregion
        #region Nmodbus物件
        /// <summary>
        /// 通訊建置類別(通用)
        /// </summary>
        public ModbusFactory Factory { get; set; }
        public SerialPort SerialPort { get; set; }

        /// <summary>
        /// 通訊物件
        /// </summary>
        public IModbusMaster master { get; set; }
        #endregion
        /// <summary>
        /// 總通訊物件
        /// </summary>
        public List<Field4Component> Field4Components { get; set; } = new List<Field4Component>();
        /// <summary>
        /// API上傳方法
        /// </summary>
        public APIMethod APIMethod { get; set; }
        /// <summary>
        /// 通訊資訊
        /// </summary>
        public SystemSetting SystemSetting { get; set; }
        /// <summary>
        /// 通訊數值
        /// </summary>
        public List<AbsProtocol> AbsProtocols { get; set; } = new List<AbsProtocol>();
        /// <summary>
        /// 充電樁上傳資料
        /// </summary>
        public List<Battery_Data> Battery_Datas { get; set; } = new List<Battery_Data>();
    }
}
