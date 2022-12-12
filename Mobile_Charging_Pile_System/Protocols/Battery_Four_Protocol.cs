using NModbus;
using Serilog;
using System;
using System.Threading;

namespace Mobile_Charging_Pile_System.Protocols
{
    public class Battery_Four_Protocol : Battery_Four_Data
    {
        public override void Data_Read(IModbusMaster master)
        {
            try
            {
                int Index = 0;
                bool[] state1 = master.ReadCoils(ID, 2000, 5);
                bool[] state2 = master.ReadCoils(ID, 2010, 5);
                bool[] state3 = master.ReadCoils(ID, 2020, 5);
                ushort[] value1 = master.ReadHoldingRegisters(ID, 0, 45);
                ushort[] value2 = master.ReadHoldingRegisters(ID, 50, 45);
                ushort[] value3 = master.ReadHoldingRegisters(ID, 100, 45);
                ushort[] value4 = master.ReadHoldingRegisters(ID, 150, 45);
                if (CompleteFlag)
                {
                    #region 總資訊狀態
                    Total_Output_Switch_On_Battery_Side.State = state1[Index]; Index++;
                    for (int i = 0; i < 4; i++)
                    {
                        Battery_Wake_Up[i].State = state1[Index]; Index++;
                    }
                    Index = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        ErrorStatus[i].State = state2[Index];
                        ProtocolErrorStatus[i].State = state3[Index]; Index++;
                    }
                    #endregion
                    #region 電池數值
                    Index = 0;
                    for (int i = 0; i < 16; i++)
                    {
                        Vbatt_Cell[i] = Convert.ToDecimal(value1[Index] * 0.001f);
                        Vbatt_Cell[i + 16] = Convert.ToDecimal(value2[Index] * 0.001f);
                        Vbatt_Cell[i + 31] = Convert.ToDecimal(value3[Index] * 0.001f);
                        Vbatt_Cell[i + 47] = Convert.ToDecimal(value4[Index] * 0.001f);
                        Index++;
                    }
                    Vbatt_max[0] = Convert.ToDecimal(value1[Index] * 0.001f);
                    Vbatt_max[1] = Convert.ToDecimal(value2[Index] * 0.001f);
                    Vbatt_max[2] = Convert.ToDecimal(value3[Index] * 0.001f);
                    Vbatt_max[3] = Convert.ToDecimal(value4[Index] * 0.001f);
                    Index++;
                    Vbatt_min[0] = Convert.ToDecimal(value1[Index] * 0.001f);
                    Vbatt_min[1] = Convert.ToDecimal(value2[Index] * 0.001f);
                    Vbatt_min[2] = Convert.ToDecimal(value3[Index] * 0.001f);
                    Vbatt_min[3] = Convert.ToDecimal(value4[Index] * 0.001f);
                    Index++;
                    Vpack[0] = Convert.ToDecimal(value1[Index] * 0.01f);
                    Vpack[1] = Convert.ToDecimal(value2[Index] * 0.01f);
                    Vpack[2] = Convert.ToDecimal(value3[Index] * 0.01f);
                    Vpack[3] = Convert.ToDecimal(value4[Index] * 0.01f);
                    Index++;
                    Vbatt[0] = Convert.ToDecimal(value1[Index] * 0.01f);
                    Vbatt[1] = Convert.ToDecimal(value2[Index] * 0.01f);
                    Vbatt[2] = Convert.ToDecimal(value3[Index] * 0.01f);
                    Vbatt[3] = Convert.ToDecimal(value4[Index] * 0.01f);
                    Index++;
                    Charging_Current[0] = Convert.ToDecimal(value1[Index] * 0.01f);
                    Charging_Current[1] = Convert.ToDecimal(value2[Index] * 0.01f);
                    Charging_Current[2] = Convert.ToDecimal(value3[Index] * 0.01f);
                    Charging_Current[3] = Convert.ToDecimal(value4[Index] * 0.01f);
                    Index++;
                    Discharging_Current[0] = Convert.ToDecimal(value1[Index] * 0.01f);
                    Discharging_Current[1] = Convert.ToDecimal(value2[Index] * 0.01f);
                    Discharging_Current[2] = Convert.ToDecimal(value3[Index] * 0.01f);
                    Discharging_Current[3] = Convert.ToDecimal(value4[Index] * 0.01f);
                    Index++;
                    SOC[0] = Convert.ToDecimal(value1[Index] * 0.1f);
                    SOC[1] = Convert.ToDecimal(value2[Index] * 0.1f);
                    SOC[2] = Convert.ToDecimal(value3[Index] * 0.1f);
                    SOC[3] = Convert.ToDecimal(value4[Index] * 0.1f);
                    Index++;
                    SOH[0] = Convert.ToDecimal(value1[Index] * 0.1f);
                    SOH[1] = Convert.ToDecimal(value2[Index] * 0.1f);
                    SOH[2] = Convert.ToDecimal(value3[Index] * 0.1f);
                    SOH[3] = Convert.ToDecimal(value4[Index] * 0.1f);
                    Index += 4;
                    for (int i = 0; i < 5; i++)
                    {
                        Temp[i] = Convert.ToDecimal(value1[Index] * 0.1f);
                        Temp[i + 5] = Convert.ToDecimal(value2[Index] * 0.1f);
                        Temp[i + 10] = Convert.ToDecimal(value3[Index] * 0.1f);
                        Temp[i + 15] = Convert.ToDecimal(value4[Index] * 0.1f);
                        Index++;
                    }
                    Charge_Discharge_Times[0] = Convert.ToInt32(value1[Index]);
                    Charge_Discharge_Times[1] = Convert.ToInt32(value2[Index]);
                    Charge_Discharge_Times[2] = Convert.ToInt32(value3[Index]);
                    Charge_Discharge_Times[3] = Convert.ToInt32(value4[Index]);
                    Index++;
                    OV_Alarm[0].ValueScr = value1[Index];
                    OV_Alarm[1].ValueScr = value2[Index];
                    OV_Alarm[2].ValueScr = value3[Index];
                    OV_Alarm[3].ValueScr = value4[Index];
                    Index++;
                    OV_Protection[0].ValueScr = value1[Index];
                    OV_Protection[1].ValueScr = value2[Index];
                    OV_Protection[2].ValueScr = value3[Index];
                    OV_Protection[3].ValueScr = value4[Index];
                    Index++;
                    UV_Alarm[0].ValueScr = value1[Index];
                    UV_Alarm[1].ValueScr = value2[Index];
                    UV_Alarm[2].ValueScr = value3[Index];
                    UV_Alarm[3].ValueScr = value4[Index];
                    Index++;
                    UV_Protection[0].ValueScr = value1[Index];
                    UV_Protection[1].ValueScr = value2[Index];
                    UV_Protection[2].ValueScr = value3[Index];
                    UV_Protection[3].ValueScr = value4[Index];
                    Index++;
                    Cell_Balance[0].ValueScr = value1[Index];
                    Cell_Balance[1].ValueScr = value2[Index];
                    Cell_Balance[2].ValueScr = value3[Index];
                    Cell_Balance[3].ValueScr = value4[Index];
                    Index++;
                    Voltage_Current_Status[0].ValueScr = value1[Index];
                    Voltage_Current_Status[1].ValueScr = value2[Index];
                    Voltage_Current_Status[2].ValueScr = value3[Index];
                    Voltage_Current_Status[3].ValueScr = value4[Index];
                    Index++;
                    Temp_T1_T2[0].ValueScr = value1[Index];
                    Temp_T1_T2[1].ValueScr = value2[Index];
                    Temp_T1_T2[2].ValueScr = value3[Index];
                    Temp_T1_T2[3].ValueScr = value4[Index];
                    Index++;
                    Temp_T3_T4[0].ValueScr = value1[Index];
                    Temp_T3_T4[1].ValueScr = value2[Index];
                    Temp_T3_T4[2].ValueScr = value3[Index];
                    Temp_T3_T4[3].ValueScr = value4[Index];
                    Index++;
                    Temp_T5_T[0].ValueScr = value1[Index];
                    Temp_T5_T[1].ValueScr = value2[Index];
                    Temp_T5_T[2].ValueScr = value3[Index];
                    Temp_T5_T[3].ValueScr = value4[Index];
                    Index++;
                    Comprehensive_Status[0].ValueScr = value1[Index];
                    Comprehensive_Status[1].ValueScr = value2[Index];
                    Comprehensive_Status[2].ValueScr = value3[Index];
                    Comprehensive_Status[3].ValueScr = value4[Index];
                    Index++;
                    Total_SOC[0] = Convert.ToDecimal(Calculate.work16to10(value1[Index], value1[Index + 1]));
                    Total_SOC[1] = Convert.ToDecimal(Calculate.work16to10(value2[Index], value2[Index + 1]));
                    Total_SOC[2] = Convert.ToDecimal(Calculate.work16to10(value3[Index], value3[Index + 1]));
                    Total_SOC[3] = Convert.ToDecimal(Calculate.work16to10(value4[Index], value4[Index + 1]));
                    #endregion
                }
                else
                {
                    #region 狀態模組
                    Total_Output_Switch_On_Battery_Side.APIMethod = APIMethod;
                    Total_Output_Switch_On_Battery_Side.ChargePileGuid = DeviceSetting.DeviceGuid;
                    Total_Output_Switch_On_Battery_Side.Address = "M0";
                    for (int i = 0; i < 4; i++)
                    {
                        Status status = new Status();
                        status.APIMethod = APIMethod;
                        status.ChargePileGuid = DeviceSetting.DeviceGuid;
                        status.Address = $"M{i + 1}";
                        Battery_Wake_Up.Add(status);
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        Status errorStatus = new Status();
                        errorStatus.APIMethod = APIMethod;
                        errorStatus.ChargePileGuid = DeviceSetting.DeviceGuid;
                        errorStatus.Address = $"M{i + 10}";
                        ErrorStatus.Add(errorStatus);
                        Status protocolErrorStatus = new Status();
                        protocolErrorStatus.APIMethod = APIMethod;
                        protocolErrorStatus.ChargePileGuid = DeviceSetting.DeviceGuid;
                        protocolErrorStatus.Address = $"M{i + 20}";
                        ProtocolErrorStatus.Add(protocolErrorStatus);
                    }
                    #endregion
                    #region 字串狀態模組
                    for (int i = 0; i < 4; i++)
                    {
                        StrStatus oV_Alarm = new StrStatus();
                        oV_Alarm.APIMethod = APIMethod;
                        oV_Alarm.ChargePileGuid = DeviceSetting.DeviceGuid;
                        oV_Alarm.Address = $"R{33 + (50 * i)}";
                        OV_Alarm.Add(oV_Alarm);

                        StrStatus oV_Protection = new StrStatus();
                        oV_Protection.APIMethod = APIMethod;
                        oV_Protection.ChargePileGuid = DeviceSetting.DeviceGuid;
                        oV_Protection.Address = $"R{34 + (50 * i)}";
                        OV_Protection.Add(oV_Protection);

                        StrStatus uV_Alarm = new StrStatus();
                        uV_Alarm.APIMethod = APIMethod;
                        uV_Alarm.ChargePileGuid = DeviceSetting.DeviceGuid;
                        uV_Alarm.Address = $"R{35 + (50 * i)}";
                        UV_Alarm.Add(uV_Alarm);

                        StrStatus uV_Protection = new StrStatus();
                        uV_Protection.APIMethod = APIMethod;
                        uV_Protection.ChargePileGuid = DeviceSetting.DeviceGuid;
                        uV_Protection.Address = $"R{36 + (50 * i)}";
                        UV_Protection.Add(uV_Protection);

                        StrStatus cell_Balance = new StrStatus();
                        cell_Balance.APIMethod = APIMethod;
                        cell_Balance.ChargePileGuid = DeviceSetting.DeviceGuid;
                        cell_Balance.Address = $"R{37 + (50 * i)}";
                        Cell_Balance.Add(cell_Balance);

                        StrStatus voltage_Current_Status = new StrStatus();
                        voltage_Current_Status.APIMethod = APIMethod;
                        voltage_Current_Status.ChargePileGuid = DeviceSetting.DeviceGuid;
                        voltage_Current_Status.Address = $"R{38 + (50 * i)}";
                        voltage_Current_Status.SendFlag = true;
                        Voltage_Current_Status.Add(voltage_Current_Status);

                        StrStatus temp_T1_T2 = new StrStatus();
                        temp_T1_T2.APIMethod = APIMethod;
                        temp_T1_T2.ChargePileGuid = DeviceSetting.DeviceGuid;
                        temp_T1_T2.Address = $"R{39 + (50 * i)}";
                        Temp_T1_T2.Add(temp_T1_T2);

                        StrStatus temp_T3_T4 = new StrStatus();
                        temp_T3_T4.APIMethod = APIMethod;
                        temp_T3_T4.ChargePileGuid = DeviceSetting.DeviceGuid;
                        temp_T3_T4.Address = $"R{40 + (50 * i)}";
                        Temp_T3_T4.Add(temp_T3_T4);

                        StrStatus temp_T5_T = new StrStatus();
                        temp_T5_T.APIMethod = APIMethod;
                        temp_T5_T.ChargePileGuid = DeviceSetting.DeviceGuid;
                        temp_T5_T.Address = $"R{41 + (50 * i)}";
                        Temp_T5_T.Add(temp_T5_T);

                        StrStatus comprehensive_Status = new StrStatus();
                        comprehensive_Status.APIMethod = APIMethod;
                        comprehensive_Status.ChargePileGuid = DeviceSetting.DeviceGuid;
                        comprehensive_Status.Address = $"R{42 + (50 * i)}";
                        Comprehensive_Status.Add(comprehensive_Status);
                    }
                    #endregion
                    #region 總資訊狀態
                    Total_Output_Switch_On_Battery_Side._state = state1[Index]; Index++;
                    for (int i = 0; i < 4; i++)
                    {
                        Battery_Wake_Up[i]._state = state1[Index]; Index++;
                    }
                    Index = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        ErrorStatus[i]._state = state2[Index];
                        ProtocolErrorStatus[i]._state = state3[Index]; Index++;
                    }
                    #endregion
                    #region 電池數值
                    Index = 0;
                    for (int i = 0; i < 16; i++)
                    {
                        Vbatt_Cell[i] = Convert.ToDecimal(value1[Index] * 0.001f);
                        Vbatt_Cell[i + 16] = Convert.ToDecimal(value2[Index] * 0.001f);
                        Vbatt_Cell[i + 31] = Convert.ToDecimal(value3[Index] * 0.001f);
                        Vbatt_Cell[i + 47] = Convert.ToDecimal(value4[Index] * 0.001f);
                        Index++;
                    }
                    Vbatt_max[0] = Convert.ToDecimal(value1[Index] * 0.001f);
                    Vbatt_max[1] = Convert.ToDecimal(value2[Index] * 0.001f);
                    Vbatt_max[2] = Convert.ToDecimal(value3[Index] * 0.001f);
                    Vbatt_max[3] = Convert.ToDecimal(value4[Index] * 0.001f);
                    Index++;
                    Vbatt_min[0] = Convert.ToDecimal(value1[Index] * 0.001f);
                    Vbatt_min[1] = Convert.ToDecimal(value2[Index] * 0.001f);
                    Vbatt_min[2] = Convert.ToDecimal(value3[Index] * 0.001f);
                    Vbatt_min[3] = Convert.ToDecimal(value4[Index] * 0.001f);
                    Index++;
                    Vpack[0] = Convert.ToDecimal(value1[Index] * 0.01f);
                    Vpack[1] = Convert.ToDecimal(value2[Index] * 0.01f);
                    Vpack[2] = Convert.ToDecimal(value3[Index] * 0.01f);
                    Vpack[3] = Convert.ToDecimal(value4[Index] * 0.01f);
                    Index++;
                    Vbatt[0] = Convert.ToDecimal(value1[Index] * 0.01f);
                    Vbatt[1] = Convert.ToDecimal(value2[Index] * 0.01f);
                    Vbatt[2] = Convert.ToDecimal(value3[Index] * 0.01f);
                    Vbatt[3] = Convert.ToDecimal(value4[Index] * 0.01f);
                    Index++;
                    Charging_Current[0] = Convert.ToDecimal(value1[Index] * 0.01f);
                    Charging_Current[1] = Convert.ToDecimal(value2[Index] * 0.01f);
                    Charging_Current[2] = Convert.ToDecimal(value3[Index] * 0.01f);
                    Charging_Current[3] = Convert.ToDecimal(value4[Index] * 0.01f);
                    Index++;
                    Discharging_Current[0] = Convert.ToDecimal(value1[Index] * 0.01f);
                    Discharging_Current[1] = Convert.ToDecimal(value2[Index] * 0.01f);
                    Discharging_Current[2] = Convert.ToDecimal(value3[Index] * 0.01f);
                    Discharging_Current[3] = Convert.ToDecimal(value4[Index] * 0.01f);
                    Index++;
                    SOC[0] = Convert.ToDecimal(value1[Index] * 0.1f);
                    SOC[1] = Convert.ToDecimal(value2[Index] * 0.1f);
                    SOC[2] = Convert.ToDecimal(value3[Index] * 0.1f);
                    SOC[3] = Convert.ToDecimal(value4[Index] * 0.1f);
                    Index++;
                    SOH[0] = Convert.ToDecimal(value1[Index] * 0.1f);
                    SOH[1] = Convert.ToDecimal(value2[Index] * 0.1f);
                    SOH[2] = Convert.ToDecimal(value3[Index] * 0.1f);
                    SOH[3] = Convert.ToDecimal(value4[Index] * 0.1f);
                    Index += 4;
                    for (int i = 0; i < 5; i++)
                    {
                        Temp[i] = Convert.ToDecimal(value1[Index] * 0.1f);
                        Temp[i + 5] = Convert.ToDecimal(value2[Index] * 0.1f);
                        Temp[i + 10] = Convert.ToDecimal(value3[Index] * 0.1f);
                        Temp[i + 15] = Convert.ToDecimal(value4[Index] * 0.1f);
                        Index++;
                    }
                    Charge_Discharge_Times[0] = Convert.ToInt32(value1[Index]);
                    Charge_Discharge_Times[1] = Convert.ToInt32(value2[Index]);
                    Charge_Discharge_Times[2] = Convert.ToInt32(value3[Index]);
                    Charge_Discharge_Times[3] = Convert.ToInt32(value4[Index]);
                    Index++;
                    OV_Alarm[0]._valueScr = value1[Index];
                    OV_Alarm[1]._valueScr = value2[Index];
                    OV_Alarm[2]._valueScr = value3[Index];
                    OV_Alarm[3]._valueScr = value4[Index];
                    OV_Alarm[0].ValueScr = value1[Index];
                    OV_Alarm[1].ValueScr = value2[Index];
                    OV_Alarm[2].ValueScr = value3[Index];
                    OV_Alarm[3].ValueScr = value4[Index];
                    Index++;
                    OV_Protection[0]._valueScr = value1[Index];
                    OV_Protection[1]._valueScr = value2[Index];
                    OV_Protection[2]._valueScr = value3[Index];
                    OV_Protection[3]._valueScr = value4[Index];
                    OV_Protection[0].ValueScr = value1[Index];
                    OV_Protection[1].ValueScr = value2[Index];
                    OV_Protection[2].ValueScr = value3[Index];
                    OV_Protection[3].ValueScr = value4[Index];
                    Index++;
                    UV_Alarm[0]._valueScr = value1[Index];
                    UV_Alarm[1]._valueScr = value2[Index];
                    UV_Alarm[2]._valueScr = value3[Index];
                    UV_Alarm[3]._valueScr = value4[Index];
                    UV_Alarm[0].ValueScr = value1[Index];
                    UV_Alarm[1].ValueScr = value2[Index];
                    UV_Alarm[2].ValueScr = value3[Index];
                    UV_Alarm[3].ValueScr = value4[Index];
                    Index++;
                    UV_Protection[0]._valueScr = value1[Index];
                    UV_Protection[1]._valueScr = value2[Index];
                    UV_Protection[2]._valueScr = value3[Index];
                    UV_Protection[3]._valueScr = value4[Index];
                    UV_Protection[0].ValueScr = value1[Index];
                    UV_Protection[1].ValueScr = value2[Index];
                    UV_Protection[2].ValueScr = value3[Index];
                    UV_Protection[3].ValueScr = value4[Index];
                    Index++;
                    Cell_Balance[0]._valueScr = value1[Index];
                    Cell_Balance[1]._valueScr = value2[Index];
                    Cell_Balance[2]._valueScr = value3[Index];
                    Cell_Balance[3]._valueScr = value4[Index];
                    Cell_Balance[0].ValueScr = value1[Index];
                    Cell_Balance[1].ValueScr = value2[Index];
                    Cell_Balance[2].ValueScr = value3[Index];
                    Cell_Balance[3].ValueScr = value4[Index];
                    Index++;
                    Voltage_Current_Status[0]._valueScr = value1[Index];
                    Voltage_Current_Status[1]._valueScr = value2[Index];
                    Voltage_Current_Status[2]._valueScr = value3[Index];
                    Voltage_Current_Status[3]._valueScr = value4[Index];
                    Voltage_Current_Status[0].ValueScr = value1[Index];
                    Voltage_Current_Status[1].ValueScr = value2[Index];
                    Voltage_Current_Status[2].ValueScr = value3[Index];
                    Voltage_Current_Status[3].ValueScr = value4[Index];
                    Index++;
                    Temp_T1_T2[0]._valueScr = value1[Index];
                    Temp_T1_T2[1]._valueScr = value2[Index];
                    Temp_T1_T2[2]._valueScr = value3[Index];
                    Temp_T1_T2[3]._valueScr = value4[Index];
                    Temp_T1_T2[0].ValueScr = value1[Index];
                    Temp_T1_T2[1].ValueScr = value2[Index];
                    Temp_T1_T2[2].ValueScr = value3[Index];
                    Temp_T1_T2[3].ValueScr = value4[Index];
                    Index++;
                    Temp_T3_T4[0]._valueScr = value1[Index];
                    Temp_T3_T4[1]._valueScr = value2[Index];
                    Temp_T3_T4[2]._valueScr = value3[Index];
                    Temp_T3_T4[3]._valueScr = value4[Index];
                    Temp_T3_T4[0].ValueScr = value1[Index];
                    Temp_T3_T4[1].ValueScr = value2[Index];
                    Temp_T3_T4[2].ValueScr = value3[Index];
                    Temp_T3_T4[3].ValueScr = value4[Index];
                    Index++;
                    Temp_T5_T[0]._valueScr = value1[Index];
                    Temp_T5_T[1]._valueScr = value2[Index];
                    Temp_T5_T[2]._valueScr = value3[Index];
                    Temp_T5_T[3]._valueScr = value4[Index];
                    Temp_T5_T[0].ValueScr = value1[Index];
                    Temp_T5_T[1].ValueScr = value2[Index];
                    Temp_T5_T[2].ValueScr = value3[Index];
                    Temp_T5_T[3].ValueScr = value4[Index];
                    Index++;
                    Comprehensive_Status[0]._valueScr = value1[Index];
                    Comprehensive_Status[1]._valueScr = value2[Index];
                    Comprehensive_Status[2]._valueScr = value3[Index];
                    Comprehensive_Status[3]._valueScr = value4[Index];
                    Comprehensive_Status[0].ValueScr = value1[Index];
                    Comprehensive_Status[1].ValueScr = value2[Index];
                    Comprehensive_Status[2].ValueScr = value3[Index];
                    Comprehensive_Status[3].ValueScr = value4[Index];
                    Index++;
                    Total_SOC[0] = Convert.ToDecimal(Calculate.work16to10(value1[Index], value1[Index + 1]));
                    Total_SOC[1] = Convert.ToDecimal(Calculate.work16to10(value2[Index], value2[Index + 1]));
                    Total_SOC[2] = Convert.ToDecimal(Calculate.work16to10(value3[Index], value3[Index + 1]));
                    Total_SOC[3] = Convert.ToDecimal(Calculate.work16to10(value4[Index], value4[Index + 1]));
                    #endregion
                    CompleteFlag = true;
                }
                LastTime = DateTime.Now;
                ConnectFlag = true;
            }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {
                ConnectFlag = false;
                Log.Error(ex, "通訊失敗");
            }
        }
    }
}
