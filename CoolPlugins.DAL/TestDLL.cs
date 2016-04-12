using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cool.DalLibrary;
using CoolPlugins.Public.Entities;

namespace CoolPlugins.DAL
{
    public class TestDLL
    {
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <returns></returns>
        public static User GetModel()
        {
            var userModel = DalHelper.SelectModel<User>(1, new SqlNote("孙涛", "根据主键查询实体"));
            return userModel;
        }
    }
}
