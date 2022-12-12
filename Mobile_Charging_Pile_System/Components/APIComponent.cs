using Mobile_Charging_Pile_System.Methods;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace Mobile_Charging_Pile_System.Components
{
    public partial class APIComponent : Field4Component
    {
        public APIComponent(List<Field4Component> field4Components, APIMethod aPIMethod)
        {
            InitializeComponent();
            Field4Components = field4Components;
            APIMethod = aPIMethod;
        }

        public APIComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void AfterMyWorkStateChanged(object sender, EventArgs e)
        {
            if (myWorkState)
            {
                ReadTime = DateTime.Now;
                ReadThread = new Thread(Analysis);
                ReadThread.Start();
            }
            else
            {
                if (ReadThread != null)
                {
                    ReadThread.Abort();
                }
            }
        }
        private void Analysis()
        {
            while (myWorkState)
            {
                TimeSpan ReadSpan = DateTime.Now.Subtract(ReadTime);
                if (ReadSpan.TotalMilliseconds >= 15000)
                {
                    try
                    {
                        if (Field4Components != null)
                        {
                            foreach (var item in Field4Components)
                            {
                                foreach (var dataitem in item.Battery_Datas)
                                {
                                    if (dataitem != null)
                                    {
                                        if (myWorkState)
                                        {
                                            APIMethod.Post_Value(dataitem);
                                            ReadTime = DateTime.Now;
                                            Thread.Sleep(10);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Thread.Sleep(80);
                        }
                    }
                    catch (ThreadAbortException) { }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "API上傳失敗");
                    }
                }
                else
                {
                    Thread.Sleep(80);
                }
            }
        }
    }
}
