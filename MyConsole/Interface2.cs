using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyConsole
{
    class Program
    {
        //声明CancellationTokenSource对象
        //private CancellationTokenSource cancelTokenSource; 
        static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        //程序入口
        static void Main(string[] args)
        {
           
           // cancelTokenSource = new CancellationTokenSource(3000);
            cancelTokenSource.CancelAfter(3000);
            Task.Factory.StartNew(MyTask, cancelTokenSource.Token);

         //   Console.WriteLine("请按回车键(Enter)停止");
            Console.ReadLine();
            //cancelTokenSource.Cancel();
          
            Console.ReadLine();
        }

        //测试方法
        static void MyTask()
        {
            //判断是否取消任务
            while (!cancelTokenSource.IsCancellationRequested)
            {
                Console.WriteLine(DateTime.Now);
                Thread.Sleep(1000);
            }
            Console.WriteLine("已停止");
        }
    }
}
