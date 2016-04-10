using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolPlugins.Public;
using CoolPlugins.Public.DalLibrary;
using CoolPlugins.Public.Entities;

namespace CoolPlugins.BLL
{
    public class TestBLL
    {
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <returns></returns>
        public static User GetModel()
        {
            //var userModel1 = DalHelper.SelectModel<User>(1, new SqlNote("孙涛", "根据主键查询实体").AddSqlNote());
            //var userModel2 = DalHelper.SelectModel<User>(1,new List<string>{"RealName"}, new SqlNote("孙涛", "根据主键查询指定字段").AddSqlNote());
            //var userModel3 = DalHelper.SelectModel<User>("UserCode","liji" , new SqlNote("孙涛", "根据指定键值查询实体").AddSqlNote());
            var userModel4 = DalHelper.SelectModel<User>("UserCode","liji" ,new List<string>{"RealName"}, new SqlNote("孙涛", "根据指定键值查询指定字段").AddSqlNote());
            return userModel4;
        }

        /// <summary>
        /// 查询list
        /// </summary>
        /// <returns></returns>
        public static List<User> GetList()
        {
            var nameValues = new NameValueCollection {{"Sex", "0"}};
            var userList = DalHelper.SelectList<User>(nameValues, new SqlNote("孙涛", "查询用户实体信息").AddSqlNote(),
                new DataPage {PageSize = 12});
            return userList;
        }
    }
}
