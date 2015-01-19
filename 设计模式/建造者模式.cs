﻿using System;
using System.Collections;
﻿using System.Reflection;

namespace 设计模式
{

    /*
        建造者模式（Builder Pattern）
        http://terrylee.cnblogs.com/archive/2005/12/19/299878.html
        客户端：顾客。想去买一套套餐（这里面包括汉堡，可乐，薯条），可以有1号和2号两种套餐供顾客选择。
        指导者角色：收银员。知道顾客想要买什么样的套餐，并告诉餐馆员工去准备套餐。
        建造者角色：餐馆员工。按照收银员的要求去准备具体的套餐，分别放入汉堡，可乐，薯条等。
        产品角色：最后的套餐，所有的东西放在同一个盘子里面。
    */

    #region  Food类，即产品类

    /// <summary>
    /// Food类，即产品类
    /// </summary>
    public class Food
    {
        private Hashtable food = new Hashtable();

        /// <summary>
        /// 添加食品
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="price"></param>
        public void AddFood(string strName, string price)
        {
            food.Add(strName, price);
        }

        public void Show()
        {
            IDictionaryEnumerator myEnumerator = food.GetEnumerator();
            Console.WriteLine("Food List:");
            Console.WriteLine("Food List:");
            string strfoodlist = "";
            while (myEnumerator.MoveNext())
            {
                strfoodlist = strfoodlist + "\n\n" + myEnumerator.Key.ToString();
                strfoodlist = strfoodlist + ":\t" + myEnumerator.Value.ToString();
            }
            Console.WriteLine(strfoodlist);
            Console.WriteLine("\n------------------------------");
        }
    }

    #endregion

    #region Builder类，即抽象建造者类，构造套餐

    /// <summary>
    ///  Builder类，即抽象建造者类，构造套餐
    /// </summary>
    public abstract class Builder
    {
        public abstract void BuildHumb();
        public abstract void BuildCoke();
        public abstract void BuildChip();

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <returns>食品对象</returns>
        public abstract Food GetFood();
    }

    #endregion

    #region FoodManager类，即指导者

    /// <summary>
    /// FoodManager类，即指导者
    /// </summary>
    public class FoodManager
    {
        public void Construct(Builder build)
        {
            build.BuildHumb();
            build.BuildCoke();
            build.BuildChip();
        }
    }

    #endregion

    #region NormalBuilder类，具体构造者，普通套餐

    public class NormalBuilder : Builder
    {
        private Food normalFood = new Food();

        public override void BuildHumb()
        {
            normalFood.AddFood("Humb", "5.5$");
        }

        public override void BuildCoke()
        {
            normalFood.AddFood("Coke", "3.5$");
        }

        public override void BuildChip()
        {
            normalFood.AddFood("Chip", "7$");
        }

        public override Food GetFood()
        {
            return normalFood;
        }
    }

    #endregion

    #region GoldBuilder类，具体构造者，黄金套餐

    /// <summary>
    /// GoldBuilder类，具体构造者，黄金套餐
    /// </summary>
    public class GoldBuilder : Builder
    {
        private Food normalFood = new Food();

        public override void BuildHumb()
        {
            normalFood.AddFood("Humb", "15$");
        }

        public override void BuildCoke()
        {
            normalFood.AddFood("Coke", "5$");
        }

        public override void BuildChip()
        {
            normalFood.AddFood("Chip", "20$");
        }

        public override Food GetFood()
        {
            return normalFood;
        }
    }

    #endregion

    #region Client 类

    public static class BuilderPatternMain
    {
        public static void BuilderMain()
        {
            FoodManager foodmanager = new FoodManager();
            Builder instance;
            Console.WriteLine("Please Enter Food No:");
            string no = Console.ReadLine();
            if (no == "1")
            {
                instance = (Builder)Assembly.Load("设计模式").CreateInstance("设计模式.NormalBuilder");
            }
            else
            {
                instance = (Builder)Assembly.Load("设计模式").CreateInstance("设计模式.GoldBuilder");
            }
            foodmanager.Construct(instance);
            Food food = instance.GetFood();
            food.Show();
            Console.ReadLine();
        }


    }

    #endregion
}