using MathLibrary;
using Mobile_Charging_Pile_System.Methods;
using Mobile_Charging_Pile_System.Modules;
using System;
using System.Collections.Generic;

namespace Mobile_Charging_Pile_System.Protocols
{
    /// <summary>
    /// 充電樁四顆電池 
    /// <para>* = 需上傳</para>
    /// </summary>
    public abstract class Battery_Four_Data : AbsProtocol
    {
        #region 總資訊狀態
        /// <summary>
        /// 電池側總輸出開關
        /// </summary>
        public Status Total_Output_Switch_On_Battery_Side { get; set; } = new Status();
        /// <summary>
        /// 電池喚醒
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<Status> Battery_Wake_Up { get; set; } = new List<Status>();
        /// <summary>
        /// 異常點
        /// <para>0 = Inverter</para>
        /// <para>1 = 電池1</para>
        /// <para>2 = 電池2</para>
        /// <para>3 = 電池3</para>
        /// <para>4 = 電池4</para>
        /// </summary>
        public List<Status> ErrorStatus { get; set; } = new List<Status>();
        /// <summary>
        /// 通訊異常點
        /// <para>0 = Inverter</para>
        /// <para>1 = 電池1</para>
        /// <para>2 = 電池2</para>
        /// <para>3 = 電池3</para>
        /// <para>4 = 電池4</para>
        /// </summary>
        public List<Status> ProtocolErrorStatus { get; set; } = new List<Status>();
        #endregion
        #region 電池數值
        /// <summary>
        /// Cell電池電壓 (0.001)
        /// <para>0~15 = 電池1</para>
        /// <para>16~31 = 電池2</para>
        /// <para>31~46 = 電池3</para>
        /// <para>47~63 = 電池4</para>
        /// </summary>
        public decimal[] Vbatt_Cell { get; set; } = new decimal[64];
        /// <summary>
        /// Cell電池最大電壓 (0.001)
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public decimal[] Vbatt_max { get; set; } = new decimal[4];
        /// <summary>
        /// Cell電池最小電壓 (0.001)
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public decimal[] Vbatt_min { get; set; } = new decimal[4];
        /// <summary>
        /// *Pack電壓 (0.01)
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public decimal[] Vpack { get; set; } = new decimal[4];
        /// <summary>
        /// 總電壓 (0.01)
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public decimal[] Vbatt { get; set; } = new decimal[4];
        /// <summary>
        /// *充電電流 (0.01)
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public decimal[] Charging_Current { get; set; } = new decimal[4];
        /// <summary>
        /// *放電電流 (0.01)
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public decimal[] Discharging_Current { get; set; } = new decimal[4];
        /// <summary>
        /// *電池容量SOC (0.1)
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public decimal[] SOC { get; set; } = new decimal[4];
        /// <summary>
        /// 電池健康度SOH (0.1)
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public decimal[] SOH { get; set; } = new decimal[4];
        /// <summary>
        /// *電池溫度 (0.1)
        /// <para>0~4 = 電池1</para>
        /// <para>5~9 = 電池2</para>
        /// <para>10~14 = 電池3</para>
        /// <para>15~19 = 電池4</para>
        /// </summary>
        public decimal[] Temp { get; set; } = new decimal[20];
        /// <summary>
        /// *充放電次數
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public int[] Charge_Discharge_Times { get; set; } = new int[4];
        /// <summary>
        /// OV警告各電池狀態
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<StrStatus> OV_Alarm { get; set; } = new List<StrStatus>();
        /// <summary>
        /// OV保護各電池狀態
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<StrStatus> OV_Protection { get; set; } = new List<StrStatus>();
        /// <summary>
        /// UV警告各電池狀態
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<StrStatus> UV_Alarm { get; set; } = new List<StrStatus>();
        /// <summary>
        /// UV保護各電池狀態
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<StrStatus> UV_Protection { get; set; } = new List<StrStatus>();
        /// <summary>
        /// 各Cell平衡狀態
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<StrStatus> Cell_Balance { get; set; } = new List<StrStatus>();
        /// <summary>
        /// *電壓&電流偵測狀態
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<StrStatus> Voltage_Current_Status { get; set; } = new List<StrStatus>();
        /// <summary>
        /// 溫度狀態 T1&T2
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<StrStatus> Temp_T1_T2 { get; set; } = new List<StrStatus>();
        /// <summary>
        /// 溫度狀態 T3&T4
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<StrStatus> Temp_T3_T4 { get; set; } = new List<StrStatus>();
        /// <summary>
        /// 溫度狀態 T5&T1~5斷線
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<StrStatus> Temp_T5_T { get; set; } = new List<StrStatus>();
        /// <summary>
        /// 綜合狀態
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public List<StrStatus> Comprehensive_Status { get; set; } = new List<StrStatus>();
        /// <summary>
        /// *總電池容量 (SOC)
        /// <para>0 = 電池1</para>
        /// <para>1 = 電池2</para>
        /// <para>2 = 電池3</para>
        /// <para>3 = 電池4</para>
        /// </summary>
        public decimal[] Total_SOC { get; set; } = new decimal[4];
        #endregion
    }
    #region 狀態模組
    /// <summary>
    /// 狀態模組
    /// </summary>
    public class Status
    {
        /// <summary>
        /// API上傳方法
        /// </summary>
        public APIMethod APIMethod { get; set; }
        /// <summary>
        /// 充電樁編號
        /// </summary>
        public Guid ChargePileGuid { get; set; }
        /// <summary>
        /// 通訊位址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 二進制位址
        /// </summary>
        public int bitAddress { get; set; } = 0;
        /// <summary>
        /// 紀錄狀態
        /// </summary>
        public bool _state { get; set; }
        /// <summary>
        /// 改變狀態
        /// </summary>
        public bool State
        {
            get { return _state; }
            set
            {
                if (value != _state)
                {
                    _state = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = bitAddress,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
    }
    #endregion
    #region 字串狀態模組
    /// <summary>
    /// 字串狀態模組
    /// </summary>
    public class StrStatus
    {
        /// <summary>
        /// API上傳方法
        /// </summary>
        public APIMethod APIMethod { get; set; }
        /// <summary>
        /// 上傳旗標
        /// </summary>
        public bool SendFlag { get; set; } = false;
        /// <summary>
        /// 第一次完整讀取旗標
        /// </summary>
        public bool CompleteFlag { get; set; }
        /// <summary>
        /// 數學函式庫
        /// </summary>
        private MathClass Calculate { get; set; } = new MathClass();
        /// <summary>
        /// 通訊位址
        /// </summary>
        public string Address { get; set; }
        public ushort _valueScr { get; set; }
        /// <summary>
        /// 數值分析
        /// </summary>
        public ushort ValueScr
        {
            get { return _valueScr; }
            set
            {
                _valueScr = value;
                ValueStr = Calculate.StrReverse(Calculate.work10to2(value));
                if (CompleteFlag)
                {
                    bit0 = ValueStr.Substring(0, 1) == "1";
                    bit1 = ValueStr.Substring(1, 1) == "1";
                    bit2 = ValueStr.Substring(2, 1) == "1";
                    bit3 = ValueStr.Substring(3, 1) == "1";
                    bit4 = ValueStr.Substring(4, 1) == "1";
                    bit5 = ValueStr.Substring(5, 1) == "1";
                    bit6 = ValueStr.Substring(6, 1) == "1";
                    bit7 = ValueStr.Substring(7, 1) == "1";
                    bit8 = ValueStr.Substring(8, 1) == "1";
                    bit9 = ValueStr.Substring(9, 1) == "1";
                    bit10 = ValueStr.Substring(10, 1) == "1";
                    bit11 = ValueStr.Substring(11, 1) == "1";
                    bit12 = ValueStr.Substring(12, 1) == "1";
                    bit13 = ValueStr.Substring(13, 1) == "1";
                    bit14 = ValueStr.Substring(14, 1) == "1";
                    bit15 = ValueStr.Substring(15, 1) == "1";
                }
                else
                {
                    _bit0 = ValueStr.Substring(0, 1) == "1";
                    _bit1 = ValueStr.Substring(1, 1) == "1";
                    _bit2 = ValueStr.Substring(2, 1) == "1";
                    _bit3 = ValueStr.Substring(3, 1) == "1";
                    _bit4 = ValueStr.Substring(4, 1) == "1";
                    _bit5 = ValueStr.Substring(5, 1) == "1";
                    _bit6 = ValueStr.Substring(6, 1) == "1";
                    _bit7 = ValueStr.Substring(7, 1) == "1";
                    _bit8 = ValueStr.Substring(8, 1) == "1";
                    _bit9 = ValueStr.Substring(9, 1) == "1";
                    _bit10 = ValueStr.Substring(10, 1) == "1";
                    _bit11 = ValueStr.Substring(11, 1) == "1";
                    _bit12 = ValueStr.Substring(12, 1) == "1";
                    _bit13 = ValueStr.Substring(13, 1) == "1";
                    _bit14 = ValueStr.Substring(14, 1) == "1";
                    _bit15 = ValueStr.Substring(15, 1) == "1";
                    CompleteFlag = true;
                }
            }
        }
        /// <summary>
        /// 二進制字串(原始值)
        /// </summary>
        public string ValueStr;
        /// <summary>
        /// 充電樁編號
        /// </summary>
        public Guid ChargePileGuid { get; set; }
        #region 第一組
        public bool _bit0 { get; set; }
        public bool bit0
        {
            get { return _bit0; }
            set
            {
                if (value != _bit0 & SendFlag)
                {
                    _bit0 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 0,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第二組
        public bool _bit1 { get; set; }
        public bool bit1
        {
            get { return _bit1; }
            set
            {
                if (value != _bit1 & SendFlag)
                {
                    _bit1 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 1,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第三組
        public bool _bit2 { get; set; }
        public bool bit2
        {
            get { return _bit2; }
            set
            {
                if (value != _bit2 & SendFlag)
                {
                    _bit2 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 2,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第四組
        public bool _bit3 { get; set; }
        public bool bit3
        {
            get { return _bit3; }
            set
            {
                if (value != _bit3 & SendFlag)
                {
                    _bit3 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 3,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第五組
        public bool _bit4 { get; set; }
        public bool bit4
        {
            get { return _bit4; }
            set
            {
                if (value != _bit4 & SendFlag)
                {
                    _bit4 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 4,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第六組
        public bool _bit5 { get; set; }
        public bool bit5
        {
            get { return _bit5; }
            set
            {
                if (value != _bit5 & SendFlag)
                {
                    _bit5 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 5,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第七組
        public bool _bit6 { get; set; }
        public bool bit6
        {
            get { return _bit6; }
            set
            {
                if (value != _bit6 & SendFlag)
                {
                    _bit6 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 6,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第八組
        public bool _bit7 { get; set; }
        public bool bit7
        {
            get { return _bit7; }
            set
            {
                if (value != _bit7 & SendFlag)
                {
                    _bit7 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 7,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第九組
        public bool _bit8 { get; set; }
        public bool bit8
        {
            get { return _bit8; }
            set
            {
                if (value != _bit8 & SendFlag)
                {
                    _bit8 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 8,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第十組
        public bool _bit9 { get; set; }
        public bool bit9
        {
            get { return _bit9; }
            set
            {
                if (value != _bit9 & SendFlag)
                {
                    _bit9 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 9,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第十一組
        public bool _bit10 { get; set; }
        public bool bit10
        {
            get { return _bit10; }
            set
            {
                if (value != _bit10 & SendFlag)
                {
                    _bit10 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 10,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第十二組
        public bool _bit11 { get; set; }
        public bool bit11
        {
            get { return _bit11; }
            set
            {
                if (value != _bit11 & SendFlag)
                {
                    _bit11 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 11,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第十三組
        public bool _bit12 { get; set; }
        public bool bit12
        {
            get { return _bit12; }
            set
            {
                if (value != _bit12 & SendFlag)
                {
                    _bit12 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 12,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第十四組
        public bool _bit13 { get; set; }
        public bool bit13
        {
            get { return _bit13; }
            set
            {
                if (value != _bit13 & SendFlag)
                {
                    _bit13 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 13,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第十五組
        public bool _bit14 { get; set; }
        public bool bit14
        {
            get { return _bit14; }
            set
            {
                if (value != _bit14 & SendFlag)
                {
                    _bit14 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 14,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
        #region 第十六組
        public bool _bit15 { get; set; }
        public bool bit15
        {
            get { return _bit15; }
            set
            {
                if (value != _bit15 & SendFlag)
                {
                    _bit15 = value;
                    if (APIMethod != null)
                    {
                        Status_Data data = new Status_Data
                        {
                            ChargePileGuid = ChargePileGuid,
                            DateTime = DateTime.Now,
                            Address = Address,
                            bitAddress = 15,
                            State = value
                        };
                        APIMethod.Post_Status(data);
                    }
                }
            }
        }
        #endregion
    }
    #endregion
}
