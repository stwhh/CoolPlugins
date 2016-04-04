using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolPlugins.Public.DalLibrary
{
    public class DataPage
    {
        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 页面索引
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 总记录 
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderField { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DataPage()
        {
            PageSize = 12;
            PageIndex = 1;
        }
    }
}
