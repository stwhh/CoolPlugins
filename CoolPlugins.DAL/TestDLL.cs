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
            //查询
            var userModel = DalHelper.SelectModel<User>(2170, new SqlNote("孙涛", "根据主键查询实体"));

            //更新
            var userUpdate = DalHelper.Update<User>("1", "Addtion1", "孙涛修改数据测试", new SqlNote("孙涛", "修改数据"));
           
            //删除
            var delModel = DalHelper.Del<User>(userModel, new SqlNote("孙涛", "删除实体"));
            return userModel;
        }
    }
}
