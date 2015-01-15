using System;
using System.Threading;

namespace 设计模式.线程
{
    public static class ThreadPoolDemo
    {
        public static void ThreadPoolDemo_Main()
        {
            Console.WriteLine("我是主线程：Thread Id {0}", Thread.CurrentThread.ManagedThreadId);
            ThreadPool.QueueUserWorkItem(Go);
            Console.ReadLine();
        }
        public static void Go(object data)
        {
            Console.WriteLine("我是另一个线程:Thread Id {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
