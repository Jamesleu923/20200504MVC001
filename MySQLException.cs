using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20210504MVC001
{
    public class MySQLException:Exception
    {
        public override string ToString()
        {
            return " 存檔錯誤";
        }
    }
}