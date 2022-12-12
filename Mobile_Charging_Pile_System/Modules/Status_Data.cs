using System;

namespace Mobile_Charging_Pile_System.Modules
{
    public class Status_Data
    {
        /// <summary>
        /// 時間
        /// </summary>
        public DateTime DateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 充電樁編號
        /// </summary>
        public Guid ChargePileGuid { get; set; }
        /// <summary>
        /// 通訊位址
        /// </summary>
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// 二進制位址
        /// </summary>
        public int bitAddress { get; set; } = 0;
        /// <summary>
        /// 狀態
        /// </summary>
        public bool State { get; set; } = false;
    }
}
