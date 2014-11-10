using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Extension;

namespace MyConsole
{
    class Program
    {
        static void Main()
        {

        }
    }

    #region 属性赋值
    public class CopyProperty1
    {
        public static void Copy()
        {
            A a = new A { Name = "aa", Age = 1 };
            B b = new B();
            a.CopyTo(b);
        }

    }
    public class A
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class B
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
    #endregion

    #region 条件组合
    public class Add
    {
        class CC
        {
            public int A1 { get; set; }
        }
        public static void AndAlso()
        {
            List<CC> list = new List<CC> {new CC {A1 = 1}, new CC {A1 = 2}, new CC {A1 = 3}, new CC {A1 = 4}};
            Expression<Func<CC, bool>> func = a => a.A1 == 1;
            Expression<Func<CC, bool>> fun2 = a => a.A1 == 3;
            //func = func.AndInvoke(fun2);
            func = func.And(fun2);
            var aaaa = list.AsQueryable().Where(func).ToList();
            Console.WriteLine("符合组合条件的数量是："+aaaa.Count);
            Console.ReadKey();
        }
    }
    #endregion
	//窗口
}
