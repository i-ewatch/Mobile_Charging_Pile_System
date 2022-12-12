using Mobile_Charging_Pile_System.Protocols;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mobile_Charging_Pile_System.Views
{
    public partial class BatteryView : Field4UserControl
    {
        public BatteryView(AbsProtocol absProtocol)
        {
            InitializeComponent();
            AbsProtocol = absProtocol;
        }
        public override void Text_Change()
        {
            if (AbsProtocol != null)
            {
                Battery_Four_Data data = AbsProtocol as Battery_Four_Data;
                if (data.ConnectFlag)
                {
                    lbl_Time.Invoke(new Action(() => { lbl_Time.Text = data.LastTime.ToString("yyyy/MM/dd HH:mm:ss"); lbl_Time.ForeColor = Color.Green; }));
                    boolchange(true, lbl_Total_Output_Switch_On_Battery_Side, "ON", "OFF", data.Total_Output_Switch_On_Battery_Side.State);
                    boolchange(true, lbl_ErrorStatus0, "異常", "正常", data.ErrorStatus[0].State, true);
                    boolchange(true, lbl_ProtocolErrorStatus0, "異常", "正常", data.ProtocolErrorStatus[0].State, true);
                    boolchange(true, lbl_Battery_Wake_Up1, "Wake-Up", "Sleep", data.Battery_Wake_Up[0].State, true);
                    boolchange(true, lbl_Battery_Wake_Up1, "Wake-Up", "Sleep", data.Battery_Wake_Up[0].State, true);
                    boolchange(true, lbl_Battery_Wake_Up2, "Wake-Up", "Sleep", data.Battery_Wake_Up[1].State, true);
                    boolchange(true, lbl_Battery_Wake_Up3, "Wake-Up", "Sleep", data.Battery_Wake_Up[2].State, true);
                    boolchange(true, lbl_Battery_Wake_Up4, "Wake-Up", "Sleep", data.Battery_Wake_Up[3].State, true);
                    boolchange(true, lbl_ErrorStatus1, "異常", "正常", data.ErrorStatus[1].State, true);
                    boolchange(true, lbl_ErrorStatus2, "異常", "正常", data.ErrorStatus[2].State, true);
                    boolchange(true, lbl_ErrorStatus3, "異常", "正常", data.ErrorStatus[3].State, true);
                    boolchange(true, lbl_ErrorStatus4, "異常", "正常", data.ErrorStatus[4].State, true);
                    boolchange(true, lbl_ProtocolErrorStatus1, "異常", "正常", data.ProtocolErrorStatus[1].State, true);
                    boolchange(true, lbl_ProtocolErrorStatus2, "異常", "正常", data.ProtocolErrorStatus[2].State, true);
                    boolchange(true, lbl_ProtocolErrorStatus3, "異常", "正常", data.ProtocolErrorStatus[3].State, true);
                    boolchange(true, lbl_ProtocolErrorStatus4, "異常", "正常", data.ProtocolErrorStatus[4].State, true);
                    lbl_Vpack1.Text = data.Vpack[0].ToString("0.##") + " V";
                    lbl_Vpack2.Text = data.Vpack[1].ToString("0.##") + " V";
                    lbl_Vpack3.Text = data.Vpack[2].ToString("0.##") + " V";
                    lbl_Vpack4.Text = data.Vpack[3].ToString("0.##") + " V";
                    lbl_Charging_Current1.Text = data.Charging_Current[0].ToString("0.##") + " A";
                    lbl_Charging_Current2.Text = data.Charging_Current[1].ToString("0.##") + " A";
                    lbl_Charging_Current3.Text = data.Charging_Current[2].ToString("0.##") + " A";
                    lbl_Charging_Current4.Text = data.Charging_Current[3].ToString("0.##") + " A";
                    lbl_Discharging_Current1.Text = data.Discharging_Current[0].ToString("0.##") + " A";
                    lbl_Discharging_Current2.Text = data.Discharging_Current[1].ToString("0.##") + " A";
                    lbl_Discharging_Current3.Text = data.Discharging_Current[2].ToString("0.##") + " A";
                    lbl_Discharging_Current4.Text = data.Discharging_Current[3].ToString("0.##") + " A";
                    lbl_SOC1.Text = data.SOC[0].ToString("0.#") + " %";
                    lbl_SOC2.Text = data.SOC[1].ToString("0.#") + " %";
                    lbl_SOC3.Text = data.SOC[2].ToString("0.#") + " %";
                    lbl_SOC4.Text = data.SOC[3].ToString("0.#") + " %";
                    lbl_Temp1.Text = data.Temp[0].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp2.Text = data.Temp[1].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp3.Text = data.Temp[2].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp4.Text = data.Temp[3].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp5.Text = data.Temp[4].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp6.Text = data.Temp[5].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp7.Text = data.Temp[6].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp8.Text = data.Temp[7].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp9.Text = data.Temp[8].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp10.Text = data.Temp[9].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp11.Text = data.Temp[10].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp12.Text = data.Temp[11].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp13.Text = data.Temp[12].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp14.Text = data.Temp[13].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp15.Text = data.Temp[14].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp16.Text = data.Temp[15].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp17.Text = data.Temp[16].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp18.Text = data.Temp[17].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp19.Text = data.Temp[18].ToString("0.#") + " \xb0" + "C";
                    lbl_Temp20.Text = data.Temp[19].ToString("0.#") + " \xb0" + "C";
                    lbl_Charge_Discharge_Times1.Text = data.Charge_Discharge_Times[0].ToString() + " 次";
                    lbl_Charge_Discharge_Times2.Text = data.Charge_Discharge_Times[1].ToString() + " 次";
                    lbl_Charge_Discharge_Times3.Text = data.Charge_Discharge_Times[2].ToString() + " 次";
                    lbl_Charge_Discharge_Times4.Text = data.Charge_Discharge_Times[3].ToString() + " 次";
                    boolchange(true, lbl_1_0, "Warning", "Normal", data.Voltage_Current_Status[0].bit0, true);
                    boolchange(true, lbl_1_1, "Warning", "Normal", data.Voltage_Current_Status[0].bit1, true);
                    boolchange(true, lbl_1_2, "Fault", "Normal", data.Voltage_Current_Status[0].bit2, true);
                    boolchange(true, lbl_1_3, "Fault", "Normal", data.Voltage_Current_Status[0].bit3, true);
                    boolchange(true, lbl_1_4, "Warning", "Normal", data.Voltage_Current_Status[0].bit4, true);
                    boolchange(true, lbl_1_5, "Warning", "Normal", data.Voltage_Current_Status[0].bit5, true);
                    boolchange(true, lbl_1_6, "Fault", "Normal", data.Voltage_Current_Status[0].bit6, true);
                    boolchange(true, lbl_1_7, "Fault", "Normal", data.Voltage_Current_Status[0].bit7, true);
                    boolchange(true, lbl_1_8, "Warning", "Normal", data.Voltage_Current_Status[0].bit8, true);
                    boolchange(true, lbl_1_9, "Warning", "Normal", data.Voltage_Current_Status[0].bit9, true);
                    boolchange(true, lbl_1_10, "Fault", "Normal", data.Voltage_Current_Status[0].bit10, true);
                    boolchange(true, lbl_1_11, "Fault", "Normal", data.Voltage_Current_Status[0].bit11, true);

                    boolchange(true, lbl_2_0, "Warning", "Normal", data.Voltage_Current_Status[1].bit0, true);
                    boolchange(true, lbl_2_1, "Warning", "Normal", data.Voltage_Current_Status[1].bit1, true);
                    boolchange(true, lbl_2_2, "Fault", "Normal", data.Voltage_Current_Status[1].bit2, true);
                    boolchange(true, lbl_2_3, "Fault", "Normal", data.Voltage_Current_Status[1].bit3, true);
                    boolchange(true, lbl_2_4, "Warning", "Normal", data.Voltage_Current_Status[1].bit4, true);
                    boolchange(true, lbl_2_5, "Warning", "Normal", data.Voltage_Current_Status[1].bit5, true);
                    boolchange(true, lbl_2_6, "Fault", "Normal", data.Voltage_Current_Status[1].bit6, true);
                    boolchange(true, lbl_2_7, "Fault", "Normal", data.Voltage_Current_Status[1].bit7, true);
                    boolchange(true, lbl_2_8, "Warning", "Normal", data.Voltage_Current_Status[1].bit8, true);
                    boolchange(true, lbl_2_9, "Warning", "Normal", data.Voltage_Current_Status[1].bit9, true);
                    boolchange(true, lbl_2_10, "Fault", "Normal", data.Voltage_Current_Status[1].bit10, true);
                    boolchange(true, lbl_2_11, "Fault", "Normal", data.Voltage_Current_Status[1].bit11, true);

                    boolchange(true, lbl_3_0, "Warning", "Normal", data.Voltage_Current_Status[2].bit0, true);
                    boolchange(true, lbl_3_1, "Warning", "Normal", data.Voltage_Current_Status[2].bit1, true);
                    boolchange(true, lbl_3_2, "Fault", "Normal", data.Voltage_Current_Status[2].bit2, true);
                    boolchange(true, lbl_3_3, "Fault", "Normal", data.Voltage_Current_Status[2].bit3, true);
                    boolchange(true, lbl_3_4, "Warning", "Normal", data.Voltage_Current_Status[2].bit4, true);
                    boolchange(true, lbl_3_5, "Warning", "Normal", data.Voltage_Current_Status[2].bit5, true);
                    boolchange(true, lbl_3_6, "Fault", "Normal", data.Voltage_Current_Status[2].bit6, true);
                    boolchange(true, lbl_3_7, "Fault", "Normal", data.Voltage_Current_Status[2].bit7, true);
                    boolchange(true, lbl_3_8, "Warning", "Normal", data.Voltage_Current_Status[2].bit8, true);
                    boolchange(true, lbl_3_9, "Warning", "Normal", data.Voltage_Current_Status[2].bit9, true);
                    boolchange(true, lbl_3_10, "Fault", "Normal", data.Voltage_Current_Status[2].bit10, true);
                    boolchange(true, lbl_3_11, "Fault", "Normal", data.Voltage_Current_Status[2].bit11, true);

                    boolchange(true, lbl_4_0, "Warning", "Normal", data.Voltage_Current_Status[3].bit0, true);
                    boolchange(true, lbl_4_1, "Warning", "Normal", data.Voltage_Current_Status[3].bit1, true);
                    boolchange(true, lbl_4_2, "Fault", "Normal", data.Voltage_Current_Status[3].bit2, true);
                    boolchange(true, lbl_4_3, "Fault", "Normal", data.Voltage_Current_Status[3].bit3, true);
                    boolchange(true, lbl_4_4, "Warning", "Normal", data.Voltage_Current_Status[3].bit4, true);
                    boolchange(true, lbl_4_5, "Warning", "Normal", data.Voltage_Current_Status[3].bit5, true);
                    boolchange(true, lbl_4_6, "Fault", "Normal", data.Voltage_Current_Status[3].bit6, true);
                    boolchange(true, lbl_4_7, "Fault", "Normal", data.Voltage_Current_Status[3].bit7, true);
                    boolchange(true, lbl_4_8, "Warning", "Normal", data.Voltage_Current_Status[3].bit8, true);
                    boolchange(true, lbl_4_9, "Warning", "Normal", data.Voltage_Current_Status[3].bit9, true);
                    boolchange(true, lbl_4_10, "Fault", "Normal", data.Voltage_Current_Status[3].bit10, true);
                    boolchange(true, lbl_4_11, "Fault", "Normal", data.Voltage_Current_Status[3].bit11, true);
                    lbl_Total_SOC1.Text = data.Total_SOC[0] + " mAh";
                    lbl_Total_SOC2.Text = data.Total_SOC[1] + " mAh";
                    lbl_Total_SOC3.Text = data.Total_SOC[2] + " mAh";
                    lbl_Total_SOC4.Text = data.Total_SOC[3] + " mAh";
                }
                else
                {
                    lbl_Time.Invoke(new Action(() => { lbl_Time.Text = data.LastTime.ToString("yyyy/MM/dd HH:mm:ss"); lbl_Time.ForeColor = Color.Red; }));
                    boolchange(false, lbl_Total_Output_Switch_On_Battery_Side);
                    boolchange(false, lbl_ErrorStatus0);
                    boolchange(false, lbl_ProtocolErrorStatus0);
                    boolchange(false, lbl_Battery_Wake_Up1);
                    boolchange(false, lbl_Battery_Wake_Up1);
                    boolchange(false, lbl_Battery_Wake_Up2);
                    boolchange(false, lbl_Battery_Wake_Up3);
                    boolchange(false, lbl_Battery_Wake_Up4);
                    boolchange(false, lbl_ErrorStatus1);
                    boolchange(false, lbl_ErrorStatus2);
                    boolchange(false, lbl_ErrorStatus3);
                    boolchange(false, lbl_ErrorStatus4);
                    boolchange(false, lbl_ProtocolErrorStatus1);
                    boolchange(false, lbl_ProtocolErrorStatus2);
                    boolchange(false, lbl_ProtocolErrorStatus3);
                    boolchange(false, lbl_ProtocolErrorStatus4);
                    lbl_Vpack1.Text = "-";
                    lbl_Vpack2.Text = "-";
                    lbl_Vpack3.Text = "-";
                    lbl_Vpack4.Text = "-";
                    lbl_Charging_Current1.Text = "-";
                    lbl_Charging_Current2.Text = "-";
                    lbl_Charging_Current3.Text = "-";
                    lbl_Charging_Current4.Text = "-";
                    lbl_Discharging_Current1.Text = "-";
                    lbl_Discharging_Current2.Text = "-";
                    lbl_Discharging_Current3.Text = "-";
                    lbl_Discharging_Current4.Text = "-";
                    lbl_SOC1.Text = "-";
                    lbl_SOC2.Text = "-";
                    lbl_SOC3.Text = "-";
                    lbl_SOC4.Text = "-";
                    lbl_Temp1.Text = "-";
                    lbl_Temp2.Text = "-";
                    lbl_Temp3.Text = "-";
                    lbl_Temp4.Text = "-";
                    lbl_Temp5.Text = "-";
                    lbl_Temp6.Text = "-";
                    lbl_Temp7.Text = "-";
                    lbl_Temp8.Text = "-";
                    lbl_Temp9.Text = "-";
                    lbl_Temp10.Text = "-";
                    lbl_Temp11.Text = "-";
                    lbl_Temp12.Text = "-";
                    lbl_Temp13.Text = "-";
                    lbl_Temp14.Text = "-";
                    lbl_Temp15.Text = "-";
                    lbl_Temp16.Text = "-";
                    lbl_Temp17.Text = "-";
                    lbl_Temp18.Text = "-";
                    lbl_Temp19.Text = "-";
                    lbl_Temp20.Text = "-";
                    lbl_Charge_Discharge_Times1.Text = "-";
                    lbl_Charge_Discharge_Times2.Text = "-";
                    lbl_Charge_Discharge_Times3.Text = "-";
                    lbl_Charge_Discharge_Times4.Text = "-";
                    boolchange(false, lbl_1_0);
                    boolchange(false, lbl_1_1);
                    boolchange(false, lbl_1_2);
                    boolchange(false, lbl_1_3);
                    boolchange(false, lbl_1_4);
                    boolchange(false, lbl_1_5);
                    boolchange(false, lbl_1_6);
                    boolchange(false, lbl_1_7);
                    boolchange(false, lbl_1_8);
                    boolchange(false, lbl_1_9);
                    boolchange(false, lbl_1_10);
                    boolchange(false, lbl_1_11);

                    boolchange(false, lbl_2_0);
                    boolchange(false, lbl_2_1);
                    boolchange(false, lbl_2_2);
                    boolchange(false, lbl_2_3);
                    boolchange(false, lbl_2_4);
                    boolchange(false, lbl_2_5);
                    boolchange(false, lbl_2_6);
                    boolchange(false, lbl_2_7);
                    boolchange(false, lbl_2_8);
                    boolchange(false, lbl_2_9);
                    boolchange(false, lbl_2_10);
                    boolchange(false, lbl_2_11);

                    boolchange(false, lbl_3_0);
                    boolchange(false, lbl_3_1);
                    boolchange(false, lbl_3_2);
                    boolchange(false, lbl_3_3);
                    boolchange(false, lbl_3_4);
                    boolchange(false, lbl_3_5);
                    boolchange(false, lbl_3_6);
                    boolchange(false, lbl_3_7);
                    boolchange(false, lbl_3_8);
                    boolchange(false, lbl_3_9);
                    boolchange(false, lbl_3_10);
                    boolchange(false, lbl_3_11);

                    boolchange(false, lbl_4_0);
                    boolchange(false, lbl_4_1);
                    boolchange(false, lbl_4_2);
                    boolchange(false, lbl_4_3);
                    boolchange(false, lbl_4_4);
                    boolchange(false, lbl_4_5);
                    boolchange(false, lbl_4_6);
                    boolchange(false, lbl_4_7);
                    boolchange(false, lbl_4_8);
                    boolchange(false, lbl_4_9);
                    boolchange(false, lbl_4_10);
                    boolchange(false, lbl_4_11);

                    lbl_Total_SOC1.Text = "-";
                    lbl_Total_SOC2.Text = "-";
                    lbl_Total_SOC3.Text = "-";
                    lbl_Total_SOC4.Text = "-";
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionFlag">連線旗標</param>
        /// <param name="label">文字物件</param>
        /// <param name="H">高位元字串</param>
        /// <param name="L">低位元字串</param>
        /// <param name="Status">狀態</param>
        /// <param name="flag">正反向物件 (高位元 true = 紅色 , false = 綠色)</param>
        private void boolchange(bool ConnectionFlag, Label label, string H = "", string L = "", bool Status = false, bool flag = false)
        {
            if (ConnectionFlag)
            {
                if (Status)
                {
                    if (flag)
                    {
                        label.Invoke(new Action(() => { label.Text = $"{H}"; label.ForeColor = Color.Red; }));
                    }
                    else
                    {
                        label.Invoke(new Action(() => { label.Text = $"{H}"; label.ForeColor = Color.Green; }));
                    }
                }
                else
                {
                    if (flag)
                    {
                        label.Invoke(new Action(() => { label.Text = $"{L}"; label.ForeColor = Color.Green; }));
                    }
                    else
                    {
                        label.Invoke(new Action(() => { label.Text = $"{L}"; label.ForeColor = Color.Red; }));
                    }
                }
            }
            else
            {
                label.Invoke(new Action(() => { label.Text = "-"; label.ForeColor = Color.Black; }));
            }
        }
    }
}
