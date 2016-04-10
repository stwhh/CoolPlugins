using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolPlugins.Public.Entities
{
    public interface ITableBase<T> where T : class,new()
    {
        /// <summary>
        /// 获取表的名称
        /// </summary>
        /// <returns></returns>
        string GetTableName();

        /// <summary>
        /// 获取表的主键
        /// </summary>
        /// <returns></returns>
        string GetPrimaryKey();

    }
}
