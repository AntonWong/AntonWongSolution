using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.SignalR;
using WebApplication1.SignalRManage;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //声明CancellationTokenSource对象
        //private CancellationTokenSource cancelTokenSource; 
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                Parameter[] dParameter =
                {
                    new Parameter("UserName",DbType.String,"Anton"),
                    new Parameter("Id",DbType.Int32,"1")
                };
                cancelTokenSource.CancelAfter(3000);
                var task = Task.Factory.StartNew(MyTask, "Object参数", cancelTokenSource.Token);
                Response.Write("处理中。。。");
                while (true)
                {
                    if (cancelTokenSource.IsCancellationRequested)
                    {
                        Response.Clear();
                        Response.Write("已终止。时间："+DateTime.Now);
                        GlobalHost.ConnectionManager.GetHubContext<AdminPushHub>().Clients.All.addMessage("会议已结束，请刷新页面");
                        return;
                    }
                    Thread.Sleep(1);
                }
            }
        }
        //测试方法
        void MyTask(object param)
        {
            //判断是否取消任务
            while (!cancelTokenSource.IsCancellationRequested)
            {
                Thread.Sleep(1000);
            }
           //Response.Write("已终止!");
        }
    }
}

      