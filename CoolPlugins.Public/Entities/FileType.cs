
//-------------------------------------------------------------------
// <auto-generated>
// 此代码由T4模板自动生成
// 生成时间 2016-04-10 21:30:42 by stwhh
// 对此文件的更改可能会导致不正确的行为，如果
// 重新生成代码，这些更改将会丢失。
// </auto-generated>
//-------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CoolPlugins.Public.Entities
{    
    public class FileType : ITableBase<FileType>
    {
		public string TableName="FileType"; //表名
		/// <summary>
        /// 获取表名
        /// </summary>     
		public string GetTableName()
		{
			return TableName ;
		}
        
         
		public string PrimaryKey="ID"; //主键
		/// <summary>
        /// 获取主键
        /// </summary>     
		public string GetPrimaryKey()
		{
			return PrimaryKey ;
		} 
		/// <summary>
        /// 
        /// </summary>        
        public int ID { get; set; }
        
         
		/// <summary>
        /// 文件类型Id
        /// </summary>        
        public string FilesTypeId { get; set; }
        
         
		/// <summary>
        /// 文件类型名称
        /// </summary>        
        public string FilesTypeName { get; set; }
         
    }
}

