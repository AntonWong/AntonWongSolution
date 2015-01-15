using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 设计模式.线程
{
    public static class ThreadCreateDemo
    {
       public static void ThreadCreateDemo_Main()
        {
            new Thread(Go).Start();  // .NET 1.0开始就有的
            Task.Factory.StartNew(Go); // .NET 4.0 引入了 TPL
            Task.Run(new Action(Go)); // .NET 4.5 新增了一个Run的方法
        }

        public static void Go()
        {
            Console.WriteLine("我是另一个线程");
        }
    }
}
