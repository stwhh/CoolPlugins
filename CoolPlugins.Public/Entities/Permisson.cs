
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
    public class Permisson : ITableBase<Permisson>
    {
		public string TableName="Permisson"; //表名
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
        /// 角色权限编号
        /// </summary>        
        public string PermCode { get; set; }
        
         
		/// <summary>
        /// 功能名称
        /// </summary>        
        public string PermName { get; set; }
        
         
		/// <summary>
        /// 权限路径(链接)
        /// </summary>        
        public string PermUrl { get; set; }
        
         
		/// <summary>
        /// 权限顺序
        /// </summary>        
        public int PermSeq { get; set; }
        
         
		/// <summary>
        /// 权限类型
        /// </summary>        
        public string PermType { get; set; }
        
         
		/// <summary>
        /// 父级功能权限编号
        /// </summary>        
        public string ParaentCode { get; set; }
        
         
		/// <summary>
        /// 
        /// </summary>        
        public string PermIcon { get; set; }
        
         
		/// <summary>
        /// 创建时间
        /// </summary>        
        public DateTime? CreateTime { get; set; }
        
         
		/// <summary>
        /// 创建者编号
        /// </summary>        
        public string CreateUserCode { get; set; }
        
         
		/// <summary>
        /// 修改时间
        /// </summary>        
        public DateTime? ModifyTime { get; set; }
        
         
		/// <summary>
        /// 修改者编号
        /// </summary>        
        public string ModifyUserCode { get; set; }
        
         
		/// <summary>
        /// 预留1
        /// </summary>        
        public string Addtion1 { get; set; }
        
         
		/// <summary>
        /// 预留2
        /// </summary>        
        public string Addtion2 { get; set; }
         
    }
}

