using System;
using System.Collections.Generic;

namespace Mobile_Charging_Pile_System.Modules
{
    public class Battery_Data
    {
        /// <summary>
        /// 充電樁編號
        /// </summary>
        public Guid ChargePileGuid { get; set; }
        /// <summary>
        /// 時間
        /// </summary>
        public DateTime DateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// Pack電壓
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<decimal> Vpack { get; set; } = new List<decimal>();
        /// <summary>
        /// 充電電流
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<decimal> Charging_Current { get; set; } = new List<decimal>();
        /// <summary>
        /// 放電電流
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<decimal> Discharging_Current { get; set; } = new List<decimal>();
        /// <summary>
        /// 電池容量SOC
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<decimal> SOC { get; set; } = new List<decimal>();
        /// <summary>
        /// 電池溫度
        /// <para>0~4 = 電池1</para>
        /// <para>5~9 = 電池2</para>
        /// <para>10~14 = 電池3</para>
        /// <para>15~19 = 電池4</para>
        /// </summary>
        public List<decimal> Temp { get; set; } = new List<decimal>();
        /// <summary>
        /// 充放電次數
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<int> Charge_Discharge_Times { get; set; } = new List<int>();
        /// <summary>
        /// 總電池容量SOC
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<decimal> Total_SOC { get; set; } = new List<decimal>();
    }
}
