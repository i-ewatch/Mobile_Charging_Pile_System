using Mobile_Charging_Pile_System.Configuration;
using Mobile_Charging_Pile_System.Modules;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using Serilog;
using System;
using System.Net;

namespace Mobile_Charging_Pile_System.Methods
{
    public class APIMethod
    {
        private int time = 3000;
        /// <summary>
        /// 主要網址
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string ErrorStr { get; set; } = "NONE";
        /// <summary>
        /// API回應錯誤訊息
        /// </summary>
        public string ResponseErrorMessage { get; set; } = "";
        /// <summary>
        /// 回傳狀態
        /// </summary>
        public HttpStatusCode statusCode { get; set; }
        /// <summary>
        /// API回應數值
        /// </summary>
        public string ResponseDataMessage { get; set; } = "";
        /// <summary>
        /// API連結旗標
        /// </summary>
        public bool ClientFlag { get; set; } = true;
        /// <summary>
        /// API連結物件
        /// </summary>
        private RestClient clinet { get; set; }
        /// <summary>
        /// 版本編號
        /// </summary>
        public string ReleaseNumber { get; set; }
        public APISetting APISetting { get; set; }
        public APIMethod(APISetting aPISetting,string releaseNumber)
        {
            APISetting = aPISetting;
            ReleaseNumber = releaseNumber;
            URL = APISetting.URL;
            post_Status_data = URL + "api/DataReception/upload-status-data";
            post_Battery_data = URL + "api/DataReception/upload-battery-data";
        }
        private string post_Status_data { get; set; }
        private string post_Battery_data { get; set; }
        /*以下API功能----------------------------------------------------------------------------------------*/
        /// <summary>
        /// 上傳狀態資訊
        /// </summary>
        /// <param name="status">狀態資訊</param>
        public void Post_Status(Status_Data status)
        {
            try
            {
                if (!APISetting.Flag) return;
                string value = JsonConvert.SerializeObject(status);
                var option = new RestClientOptions(post_Status_data)
                {
                    MaxTimeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddBody(value, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ResponseMessage(response.Result);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "上傳狀態資訊API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
            }
        }
        /// <summary>
        /// 上傳電池資訊
        /// </summary>
        /// <param name="battery">電池資訊</param>
        public void Post_Value(Battery_Data  battery)
        {
            try
            {
                if (!APISetting.Flag) return;
                string value = JsonConvert.SerializeObject(battery);
                var option = new RestClientOptions(post_Battery_data)
                {
                    MaxTimeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddBody(value, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ResponseMessage(response.Result);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "上傳電池資訊資訊API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
            }
        }
        #region 訊息回傳處理
        /// <summary>
        /// 訊息回傳處理
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private string ResponseMessage(RestResponse response)
        {
            ResponseErrorMessage = "";
            statusCode = response.StatusCode;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ClientFlag = true;
                ResponseDataMessage += response.Content.Replace("\"", "").Replace("\\n", "\r\n");
                return "200";
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ClientFlag = true;
                string error = response.Content;
                ResponseErrorMessage = error.Replace("\r\n", "").Replace("\"", "");
                return ResponseErrorMessage;
            }
            else
            {
                ClientFlag = false;
                return ResponseErrorMessage = response.ErrorMessage;
            }
        }
        #endregion
    }
}
