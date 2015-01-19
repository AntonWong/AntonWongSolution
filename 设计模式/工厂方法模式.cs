using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式
{
    /// <summary>
    /// Log类
    /// </summary>
    public abstract class Log
    {
        public abstract void Write();
    }
    public class EventLog:Log
    {
        public override void Write()
        {
            Console.WriteLine("EventLog Write Success!");
        }
    }
    public class FileLog : Log
    {
        public override void Write()
        {
            Console.WriteLine("FileLog Write Success!");
        }
    }
    public abstract class LogFactory
    {
        public abstract Log Create();
    }
    public class EventFactory : LogFactory
    {
        public override Log Create()
        {
            return new EventLog();
        }
    }
    public class FileFactory : LogFactory
    {
        public override Log Create()
        {
            return new FileLog();
        }
    }
    public static class LogFactoryClint
    {
        public static void LogFactoryMain()
        {
            LogFactory logFactory;
            string no = Console.ReadLine();
            if (no == "1")
                logFactory = (LogFactory)Assembly.Load("设计模式").CreateInstance("设计模式.EventFactory");
            else
                logFactory = (LogFactory)Assembly.Load("设计模式").CreateInstance("设计模式.FileFactory");
           Log log = logFactory.Create();
            log.Write();
        }
    }

}
