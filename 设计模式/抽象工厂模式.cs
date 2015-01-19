using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式
{
    public interface Tax
    {
        

    }
    public interface Bonus
    {

    }
    /// <summary>
    ///  计算美国个人所得税
    /// </summary>
    public class AmericanTax : Tax
    {
        public double Calculate()
        {
            return (Constant.BASE_SALARY + (Constant.BASE_SALARY * 0.1)) * 0.4;
        }
    }
    /// <summary>
    /// 计算中国个人所得税
    /// </summary>
    public class ChineseTax : Tax
    {
        public double Calculate()
        {
            return (Constant.BASE_SALARY + (Constant.BASE_SALARY * 0.1)) * 0.4;
        }
    }
    /// <summary>
    /// 计算美国个人奖金
    /// </summary>
    public class AmericanBonus : Bonus
    {
        public double Calculate()
        {
            return Constant.BASE_SALARY * 0.1;
        }
    }
    /// <summary>
    /// 计算中国个人奖金
    /// </summary>
    public class ChineseBonus : Bonus
    {
        public double Calculate()
        {
            return Constant.BASE_SALARY * 0.1;
        }
    }

    public class Factory
    {
        public Tax CreateTax()
        {
            return new AmericanTax();
        }

        public Bonus CreateBonus()
        {
            return new AmericanBonus();
        }
    }

    public abstract class AbstractFactory
    {
        public static AbstractFactory GetInstance()
        {
            string factoryName = "";
            AbstractFactory instance;
            if (factoryName != "")
                instance = (AbstractFactory) Assembly.Load(factoryName).CreateInstance(factoryName);
            else
                instance = null;
            return instance;
        }
        public abstract Tax CreateTax();
        public abstract Bonus CreateBonus();
    }

    /// <summary>
    ///  公用的常量
    /// </summary>
    public class Constant
    {
        public static double BASE_SALARY = 4000;
    }
}
