using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace MvcApp.Ioc
{
    public interface IUser
    {
        int UserCount();

        String UserName();
    }

    [Export(typeof(IUser))]
    public class UserService : IUser
    {

        public int UserCount()
        {
            return 1000;
        }

        public string UserName()
        {
            return "AntonWang";
        }
    }

    public interface IUser2
    {
        int UserCount();

        String UserName();
    }

    [Export(typeof(IUser2))]
    public class UserService2 : IUser2
    {

        public int UserCount()
        {
            return 1000;
        }

        public string UserName()
        {
            return "AntonWang";
        }
    }
}