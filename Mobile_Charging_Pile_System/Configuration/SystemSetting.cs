using System;
using System.Collections.Generic;

namespace Mobile_Charging_Pile_System.Configuration
{
    public class SystemSetting
    {
        /// <summary>
        /// 通訊編號
        /// </summary>
        public int GatewayNum { get; set; }
        /// <summary>
        /// 通訊類型
        /// </summary>
        public int GatewayType { get; set; }
        /// <summary>
        /// 通訊名稱
        /// </summary>
        public string GatewayName { get; set; }
        /// <summary>
        /// 通訊位址
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 通訊Port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 設備資訊
        /// </summary>
        public List<DeviceSetting> DeviceSettings { get; set; } = new List<DeviceSetting>();
    }
    public class DeviceSetting
    {
        public Guid DeviceGuid { get; set; }
        /// <summary>
        /// 設備編號
        /// </summary>
        public int DeviceNum { get; set; }
        /// <summary>
        /// 設備類型
        /// </summary>
        public int DeviceType { get; set; }
        /// <summary>
        /// 設備ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 設備名稱
        /// </summary>
        public string DeviceName { get; set; }
    }
}
