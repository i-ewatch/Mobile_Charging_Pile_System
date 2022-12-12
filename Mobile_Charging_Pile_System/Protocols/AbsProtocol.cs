using MathLibrary;
using Mobile_Charging_Pile_System.Configuration;
using Mobile_Charging_Pile_System.Methods;
using NModbus;
using System;

namespace Mobile_Charging_Pile_System.Protocols
{
    public abstract class AbsProtocol
    {
        /// <summary>
        /// API上傳方法
        /// </summary>
        public APIMethod APIMethod { get; set; }
        /// <summary>
        /// 數學函式庫
        /// </summary>
        public MathClass Calculate { get; set; } = new MathClass();
        /// <summary>
        /// 通道編號
        /// </summary>
        public int GatewayNum { get; set; }
        /// <summary>
        /// 通訊位址
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 通訊Port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 設備站號
        /// </summary>
        public byte ID { get; set; }
        /// <summary>
        /// 設備資訊
        /// </summary>
        public DeviceSetting DeviceSetting { get; set; }
        /// <summary>
        /// 第一次完整讀取旗標
        /// </summary>
        public bool CompleteFlag { get; set; }
        /// <summary>
        /// 連線旗標
        /// </summary>
        public bool ConnectFlag { get; set; }
        /// <summary>
        /// 最後讀取時間
        /// </summary>
        public DateTime LastTime { get; set; }
        /// <summary>
        /// 資料讀取
        /// </summary>
        /// <param name="master"></param>
        public abstract void Data_Read(IModbusMaster master);
    }
}
