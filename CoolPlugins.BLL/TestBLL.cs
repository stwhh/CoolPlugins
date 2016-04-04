using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolPlugins.Public;
using CoolPlugins.Public.Entities;

namespace CoolPlugins.BLL
{
    public class TestBLL
    {
        public static User GetModel()
        {
            var user = DalHelper.SelectModel<User>(1, new SqlNote("孙涛", "查询用户实体信息").AddSqlNote());
            return user;
        }
    }
}
