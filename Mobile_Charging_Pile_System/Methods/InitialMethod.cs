using Mobile_Charging_Pile_System.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mobile_Charging_Pile_System.Methods
{
    public class InitialMethod
    {
        /// <summary>
        /// 初始路徑
        /// </summary>
        private static string MyWorkPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 通訊設定讀取/建立
        /// </summary>
        /// <returns></returns>
        public static List<SystemSetting> System_Load()
        {
            List<SystemSetting> setting = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\System.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<List<SystemSetting>>(json);
                }
                else
                {
                    setting = new List<SystemSetting>();
                    setting.Add(new SystemSetting
                    {
                        GatewayNum = 0,
                        GatewayType = 1,
                        GatewayName = "通道名稱",
                        Location = "127.0.0.1",
                        Port = 502,
                    });
                    setting[0].DeviceSettings.Add(new DeviceSetting
                    {
                        DeviceGuid = Guid.NewGuid(),
                        DeviceNum = 0,
                        DeviceType = 0,
                        ID = 1,
                        DeviceName = "充電樁"
                    });
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " 系統資訊設定載入錯誤");
            }
            return setting;
        }
        #region API資訊
        /// <summary>
        /// API資訊讀取/建立
        /// </summary>
        /// <returns></returns>
        public static APISetting API_Load()
        {
            APISetting settings = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string setFile = $"{MyWorkPath}\\stf\\API.json";
            try
            {
                if (File.Exists(setFile))
                {
                    string json = File.ReadAllText(setFile, Encoding.UTF8);
                    settings = JsonConvert.DeserializeObject<APISetting>(json);
                }
                else
                {
                    settings = new APISetting
                    {
                        Flag = true,
                        URL = "https://mobile-charger-backend.azurewebsites.net/"
                    };
                    string output = JsonConvert.SerializeObject(settings, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(setFile, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "讀取API資訊失敗");
            }
            return settings;
        }
        #endregion
    }
}
